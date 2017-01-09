// <copyright company="eXtensoft, LLC" file="ApiRequestController.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.WebApi
{
    using System;
    using System.Net.Http;
    using System.Web.Http;


    [AdministratorAccessAuthorizationFilter]
    public sealed class ApiRequestController : EndpointController
    {
        IApiRequestProvider RequestProvider { get; set; }

        #region local fields
        private const string description = "This controller serves up Api Request logging detail";
        private const string id = "882E9322-253B-46A6-A146-AA18001748C0";
        private const string name = "Api Request Controller";
        private const string routePattern = "webapi/{token}";
        private const string whitelistPattern = "webapi/{id}";
        #endregion

        #region do not alter
        public override string GetDescription()
        {
            return description;
        }

        public override Guid GetId()
        {
            return new Guid(id);
        }

        public override string GetName()
        {
            return name;
        }

        public override string GetRouteTablePattern()
        {
            return routePattern;
        }

        public override string GetWhitelistPattern()
        {
            return whitelistPattern;
        }

        #endregion

        public override void RegisterApiRoute(HttpConfiguration config)
        {

            base.RegisterApiRoute(config);
        }

        public ApiRequestController()
        {
            RequestProvider = new SqlServerApiRequestProvider();
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {

            //NameValueCollection nvc = Request.GetApiParameters(new FacetEndpointMediaSettings());
            HttpResponseMessage message = null;
            int pageSize; 
            Guid g; // either basic token or apirequest messageid
            if (String.IsNullOrEmpty(id) ) // if absent, set pageSize
            {
                pageSize = 10;
                var data = RequestProvider.Get(pageSize);
                message = Request.CreateResponse(data);
            }
            else if(Int32.TryParse(id, out pageSize))
            {
                var data = RequestProvider.Get(pageSize);
                message = Request.CreateResponse(data);
            }
            else if(Guid.TryParse(id, out g))
            {
                var data = RequestProvider.Get(g);
                message = Request.CreateResponse(data);
            }
            else
            {
                var data = RequestProvider.Get(id);
                message = Request.CreateResponse(data);
            }

            return message;
        }

        //private bool IsMongoId(string id)
        //{
        //    bool b =  Regex.IsMatch(id, "^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        //    return b;
        //}
    }

}
