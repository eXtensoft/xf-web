using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using XF.Common;
using XF.WebApi;

namespace BlackRocket.WebApi
{
    public class ToDoController : EndpointServiceController
    {

        #region abstract class implementations

        public override string GetDescription()
        {
            return "This controller provides actions to create, get, remove, and update 'ToDo' items";
        }

        public override Guid GetId()
        {
            return new Guid("00F1224A-24AD-43B5-9A8C-6439A506EE76");
        }

        public override string GetName()
        {
            return "ToDo Controller";
        }

        public override string GetRouteTablePattern()
        {
            return "v{version}/todos/{id}";
        }

        public override string GetWhitelistPattern()
        {
            return "v{version}/todos/{id}";
        }
        #endregion

        private static string todoRoute = "v{version}/todos/{id}";

        public override void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "todo-route",
                routeTemplate: todoRoute,
                defaults: new { controller = "ToDo",  id = RouteParameter.Optional  }
                );
        }


        #region http endpoints

        [HttpGet]
        public HttpResponseMessage Get(int version, string id)
        {
            HttpResponseMessage message = null;

            ICriterion criterion = new Criterion();
            criterion.AddItem("Id", id);
            var response = Service.Get<ToDo>(criterion);
            if (response.IsOkay)
            {
                message = Request.GenerateResponse(HttpStatusCode.OK, response.Model);
            }
            else
            {
                message = Request.GenerateErrorResponse(HttpStatusCode.NotFound,"");
            }

            return message;
        }


            #endregion


        }
}
