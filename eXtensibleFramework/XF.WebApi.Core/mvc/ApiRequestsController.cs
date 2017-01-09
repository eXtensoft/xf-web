

namespace XF.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using XF.WebApi.Core;

    public class ApiRequestsController : Controller
    {
        [HttpGet]
        public ActionResult Index(Nullable<int> id)
        {
            string token = String.Empty;
            //int pageSize = 10;
            //int pageIndex = 0;
            IEnumerable<ApiRequest> data = null;
            if (id.HasValue)
            {
                data = ApiRequestSqlAccess.Get(id.Value);
            }
            else
            {
                //data = ApiRequestSqlAccess.Get(pageSize, pageIndex, token);
                data = ApiRequestSqlAccess.Get(10);
            }

            return View(data);
        }


    }
}
