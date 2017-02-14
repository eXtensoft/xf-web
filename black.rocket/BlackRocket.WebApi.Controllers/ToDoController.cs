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

       

        private const string description =  "This controller provides actions to create, get, remove, and update 'ToDo' items";


        private const string id = "00F1224A-24AD-43B5-9A8C-6439A506EE76";


        private const string name = "ToDo Controller";


        private const string routetablepattern =  "v{version}/todos/{id}";


        private const string whitelistpattern =  "v{version}/todos/{id}";

        #region abstract class implementations
       

        private static string todoRoute = "v{version}/todos/{id}";

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
                return whitelistpattern;
            }
        }

        public override string RouteTablePattern
        {
            get
            {
                return routetablepattern;
            }
        }

        public override void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "todo-route",
                routeTemplate: todoRoute,
                defaults: new { controller = "ToDo",  id = RouteParameter.Optional  }
                );
        }
        #endregion

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
