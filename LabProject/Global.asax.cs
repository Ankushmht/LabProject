using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LabProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        Random rnd = new Random();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            HttpCookie userIdCookie = new HttpCookie("userId");
            userIdCookie.Value = rnd.Next(10000, 100000).ToString();
            Response.SetCookie(userIdCookie);
        }
    }
}
