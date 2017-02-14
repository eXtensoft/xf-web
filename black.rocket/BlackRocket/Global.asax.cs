using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BlackRocket.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using XF.WebApi;
using XF.WebApi.Core;

namespace BlackRocket
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiRegistrar.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new eXtensibleMessageHandler() { CreateClaimsPrincipal = () => { return new eXtensibleClaimsPrincipal<WebApiCaller>(new ClaimsIdentity()); } });
            var handler = new eXtensibleMessageHandler();
            GlobalConfiguration.Configuration.MessageHandlers.Add(new eXtensibleMessageHandler());
            GlobalConfiguration.Configuration.MessageHandlers.Add(new BlackRocketMessageHandler());

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var xmlFormatter = formatters.XmlFormatter;
            formatters.Remove(xmlFormatter);
            var jsonFormatter = formatters.JsonFormatter;
            Newtonsoft.Json.Formatting formatting = Formatting.None;
            formatting = Formatting.Indented;

            var settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Formatting = formatting,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            jsonFormatter.SerializerSettings = settings;

        }
    }
}
