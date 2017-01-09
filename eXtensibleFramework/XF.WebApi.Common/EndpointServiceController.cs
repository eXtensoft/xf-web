using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using XF.Common;

namespace XF.WebApi
{
    [InheritedExport(typeof(IEndpointController))]
    public abstract class EndpointServiceController : ApiController, IEndpointController
    {

        private IModelRequestService _Service = null;
        protected IModelRequestService Service
        {
            get
            {
                if (_Service == null)
                {
                    _Service = new PassThroughModelRequestService(
                        new DataRequestService(new XF.DataServices.ModelDataGatewayDataService())
                        );
                }
                return _Service;
            }
            set
            {
                _Service = value;
            }
        }

        public abstract string GetDescription();
        public abstract Guid GetId();
        public abstract string GetName();

        public virtual int GetVersion() { return 1; }

        public abstract string GetWhitelistPattern();

        public abstract string GetRouteTablePattern();

        public virtual void Register(HttpConfiguration config)
        {
            string assemblyName = this.GetType().AssemblyQualifiedName.Split(new char[]{','})[0];
            
            string endpointName = ((IEndpointController)this).Name;
            string versionName = ((IEndpointController)this).Version.ToString();
            string registerName = String.Format("{0}-{1}-v{2}",assemblyName , endpointName,versionName);

            config.Routes.MapHttpRoute(
                    name: registerName,
                    routeTemplate: ((IEndpointController)this).RouteTablePattern,
                    defaults: new { controller = ControllerName }
                );
        }

        string IEndpointController.Description
        {
            get
            {
                return GetDescription();
            }
        }

        Guid IEndpointController.Id
        {
            get
            {
                return GetId();
            }
        }

        string IEndpointController.Name
        {
            get
            {
                return GetName();
            }
        }

        int IEndpointController.Version
        {
            get
            {
                return GetVersion();
            }
        }

        string IEndpointController.WhitelistPattern
        {
            get
            {
                return GetWhitelistPattern();
            }
        }

        string IEndpointController.RouteTablePattern
        {
            get
            {
                return GetRouteTablePattern();
            }
        }

        void IEndpointController.RegisterApiRoute(HttpConfiguration config)
        {
            Register(config);
        }

        protected string ControllerName
        {
            get
            {
                string output = string.Empty;
                string typename = this.GetType().Name;
                if (!String.IsNullOrWhiteSpace(typename) && typename.Contains("Controller"))
                {
                    int len = typename.IndexOf("Controller");
                    output = typename.Substring(0, len);
                }
                return output;
            }
        }

    }
}
