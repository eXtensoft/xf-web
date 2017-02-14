

namespace BlackRocket.WebApi
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using XF.Common;
    using XF.WebApi;

    public class DebugController : EndpointController
    {

        #region do not alter

        private const string id = "66AA8780-3EA8-47E2-A9D5-6F00213A200D";
        private const string name = "Debug Controller";
        private const string description = "This endpoint captures invalid api url calls";
        private const int version = 1;
        private const string whitelistPattern = "{*tokens}";
        private const string routeTablePattern = "v{version}/debug/{token}/{message}";

        public override string Description
        {
            get
            {
                return description;
            }
        }


        public override Guid Id
        {
            get
            {
                return new Guid(id);
            }
        }

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override string WhitelistPattern
        {
            get
            {
                return whitelistPattern;
            }
        }

        public override string RouteTablePattern
        {
            get
            {
                return routeTablePattern;
            }
        }

        #endregion



        #region endpoint actions

        [HttpPost]
        public HttpResponseMessage Post(int version, string token, string message, bool log = false)
        {
            HttpResponseMessage response = null;
            var logmessage = String.Format("test {0} token={1} log={2} message={3}", "POST", token, log, message);
            if (log)
            {
                var props = eXtensibleConfig.GetProperties();
                EventWriter.WriteError(logmessage, SeverityType.Error, "TEST", props);
            }
            int i;
            HttpStatusCode statusCode;
            if (Int32.TryParse(token, out i) && Enum.TryParse<HttpStatusCode>(token, out statusCode))
            {
                response = (statusCode.IsOkay()) ? Request.GenerateResponse(statusCode, logmessage) : Request.GenerateErrorResponse(statusCode, logmessage);
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, logmessage);
            }
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(int version, string token, string message, bool log = false)
        {
            HttpResponseMessage response = null;
            var logmessage = String.Format("test {0} token={1} log={2} message={3}", "GET", token, log, message);
            if (log)
            {
                var props = eXtensibleConfig.GetProperties();
                EventWriter.WriteError(logmessage, SeverityType.Error, "TEST", props);
            }
            int i;
            HttpStatusCode statusCode;
            if (Int32.TryParse(token, out i) && Enum.TryParse<HttpStatusCode>(token, out statusCode))
            {
                response = (statusCode.IsOkay()) ? Request.GenerateResponse(statusCode, logmessage) : Request.GenerateErrorResponse(statusCode, logmessage);
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, logmessage);
            }
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(int version, string token, string message, bool log = false)
        {
            HttpResponseMessage response = null;
            var logmessage = String.Format("test {0} token={1} log={2} message={3}", "PUT", token, log, message);
            if (log)
            {
                var props = eXtensibleConfig.GetProperties();
                EventWriter.WriteError(logmessage, SeverityType.Error, "TEST", props);
            }
            int i;
            HttpStatusCode statusCode;
            if (Int32.TryParse(token, out i) && Enum.TryParse<HttpStatusCode>(token, out statusCode))
            {
                response = (statusCode.IsOkay()) ? Request.GenerateResponse(statusCode, logmessage) : Request.GenerateErrorResponse(statusCode, logmessage);
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, logmessage);
            }
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int version, string token, string message, bool log = false)
        {
            HttpResponseMessage response = null;
            var logmessage = String.Format("test {0} token={1} log={2} message={3}", "DELETE", token, log, message);
            if (log)
            {
                var props = eXtensibleConfig.GetProperties();
                EventWriter.WriteError(logmessage, SeverityType.Error, "TEST", props);
            }
            int i;
            HttpStatusCode statusCode;
            if (Int32.TryParse(token, out i) && Enum.TryParse<HttpStatusCode>(token, out statusCode))
            {
                response = (statusCode.IsOkay()) ? Request.GenerateResponse(statusCode, logmessage) : Request.GenerateErrorResponse(statusCode, logmessage);
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, logmessage);
            }
            return response;
        }


        #endregion


    }
}
