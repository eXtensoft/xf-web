﻿// <copyright company="eXtensoft, LLC" file="DelegatingMessageHandler.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.WebApi.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using XF.Common;

    public sealed class eXtensibleMessageHandler : DelegatingHandler
    {
        private static Dictionary<string, int> errorCodeMapsReverse = new Dictionary<string, int>() { { "Conflict", 409 }, { "Not Found", 404 } };

        public IApiRequestProvider RequestProvider { get; private set; }

        static eXtensibleMessageHandler()
        {

            foreach (ApiHttpStatusCode hsc in ResponseConfiguration.MessageProvider.ErrorCodeWhitelist)
            {

            }
        }

        #region Claims Principal Factory Delegate
        private Func<ClaimsPrincipal> _CreateClaimsPrincipal;
        public Func<ClaimsPrincipal> CreateClaimsPrincipal
        {

            get
            {
                if (_CreateClaimsPrincipal == null)
                {
                    _CreateClaimsPrincipal = CreateDefaultPrincipal;
                }
                return _CreateClaimsPrincipal;
            }
            set { _CreateClaimsPrincipal = value; }
        }
        #endregion


        public eXtensibleMessageHandler()
        {
            RequestProvider = new SqlServerApiRequestProvider();
        }

        #region Writer (Func<string,List<object>>)

        private Action<Dictionary<string, object>> _Writer;

        /// <summary>
        /// Gets or sets the Func<string,List<object>> value for Writer
        /// </summary>
        /// <value> The Func<string,List<object>> value.</value>

        public Action<Dictionary<string, object>> Writer
        {
            get
            {
                if (_Writer == null)
                {
                    _Writer = Write;
                }
                return _Writer;
            }
            set
            {
                if (_Writer != value)
                {
                    _Writer = value;
                }
            }
        }

        #endregion

        private void Write(Dictionary<string, object> requestProperties)
        {
            List<TypedItem> list = requestProperties.ToTypedItems();
            if (eXtensibleWebApiConfig.LogTo.Equals(LoggingStrategyOption.Datastore))
            {
                try
                {
                    ApiRequest request = new ApiRequest(requestProperties);
                    RequestProvider.Post(request);
                    //ApiRequestSqlAccess.Post(request);
                }
                catch (Exception ex)
                {
                    EventWriter.Write(EventTypeOption.Custom, list);
                    string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    var properties = eXtensibleConfig.GetProperties();
                    properties.Add("xf.explanation", "An error occurred while trying to POST an ApiRequest to a SqlServer datastore. " +
                        " Ensure that a valid SqlServer database exists with the proper schema, and that a valid connectionstring and connectionstring key");
                    EventWriter.WriteError(message, SeverityType.Error, "eXtensibleMessageHandler", properties);
                }
            }
            else if (eXtensibleWebApiConfig.LogTo.Equals(LoggingStrategyOption.WindowsEventLog))
            {
                EventWriter.Write(EventTypeOption.Custom, list);
            }

        }


        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage errorMessage = null;

            Guid xfId = Guid.Empty;

            var principal = CreateClaimsPrincipal();
            eXtensibleClaimsPrincipal exPrincipal = principal as eXtensibleClaimsPrincipal;
            if (exPrincipal != null)
            {
                exPrincipal.Start(request);
            }

            Thread.CurrentPrincipal = exPrincipal;
            var currentContext = System.Web.HttpContext.Current;
            if (currentContext != null)
            {
                currentContext.User = exPrincipal;
            }


            // create new 
            HttpResponseMessage resultMessage = ((errorMessage != null) ? errorMessage : await base.SendAsync(request, cancellationToken));

            // now perform any required profiling
            if (exPrincipal != null)
            {
                exPrincipal.Stop(request);

                var d = exPrincipal.Items.ToDictionary().Merge(eXtensibleConfig.GetProperties());

                HttpStatusCode statuscode = resultMessage.StatusCode;
                var reason = resultMessage.ReasonPhrase;

                if (!resultMessage.IsSuccessStatusCode)
                {
                    if (!d.ContainsKey("xf-id"))
                    {
                        d.Add("xf-id", Guid.NewGuid());
                    }

                    if (((HttpContent)resultMessage.Content).GetType().GetGenericArguments()[0].Name.Equals("HttpError"))
                    {
                        var httpError = ((ObjectContent<HttpError>)resultMessage.Content).Value as HttpError;
                        if (httpError != null)
                        {
                            if (httpError.ContainsKey("message"))
                            {
                                reason = httpError["message"].ToString();
                            }

                            if (errorCodeMapsReverse.ContainsKey(resultMessage.StatusCode.ToString()))
                            {
                                int code = errorCodeMapsReverse[resultMessage.StatusCode.ToString()];
                                if (d.ContainsKey("xf-request.response.status-code"))
                                {
                                    d["xf-request.response.status-code"] = code.ToString();
                                }
                                else
                                {
                                    d.Add("xf-request.response.status-code", code.ToString());
                                }
                            }
                            if (d.ContainsKey("xf-request.response.status-description"))
                            {
                                d["xf-request.response.status-description"] = reason;
                            }
                            else
                            {
                                d.Add("xf-request.response.status-description", reason);
                            }

                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    string responsemessage = resultMessage.StatusCode.ToString();
                    int code = (int)resultMessage.StatusCode;
                    if (d.ContainsKey("xf-request.response.status-code"))
                    {
                        d["xf-request.response.status-code"] = code.ToString();
                    }
                    else
                    {
                        d.Add("xf-request.response.status-code", code.ToString());
                    }

                    if (d.ContainsKey("xf-request.response.status-description"))
                    {
                        d["xf-request.response.status-description"] = responsemessage;
                    }
                    else
                    {
                        d.Add("xf-request.response.status-description", responsemessage);
                    }
                }

                d.Add("api.extensible.list", "xf.api.request");

                string basicToken;
                string bearerToken;
                if (!d.ContainsKey("xf-request.message.basic-token") && exPrincipal.Identity.TryGetValue<string>("source", out basicToken))
                {
                    d.Add("xf-request.message.basic-token", basicToken);
                }
                if (!d.ContainsKey("xf-request.message.bearer-token") && exPrincipal.Identity.TryGetValue<string>(ClaimTypes.Authentication, out bearerToken))
                {
                    d.Add("xf-request.message.bearer-token", bearerToken);
                }
                bool b = eXtensibleWebApiConfig.LoggingMode != LoggingModeOption.None || d.ContainsKey("xf-id");
                if (b)
                {
                    xfId = d.Get<Guid>("xf-id");
                    Writer.Invoke(d);
                }

            }

            resultMessage.Headers.Add(eXtensibleWebApiConfig.MessageIdHeaderKey, xfId.ToString());

            return resultMessage;
        }


        private ClaimsPrincipal CreateDefaultPrincipal()
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            eXtensibleClaimsPrincipal principal = new eXtensibleClaimsPrincipal(identity);

            if (eXtensibleWebApiConfig.LoggingMode == LoggingModeOption.All)
            {
                principal.Items.Add(new TypedItem("xf-id", Guid.NewGuid()));
            }
            return principal;
        }

        private ClaimsPrincipal InitializeIdentity()
        {
            var identity = CreateDefaultPrincipal();

            return identity;
        }
    }

}
