using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LMS.Web.UI
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("API Default", "lmsapi/{controller}/{action}/{id}",
            new { id = RouteParameter.Optional });
        }
    }
}