using HLT.Web.RegisterAutofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HLT.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //初始化日志
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/Config/log4net.config")));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Models.Config.Init();
            //Auto注册
            RegisterAutofacForSingle.RegisterAutofac();
        }

        protected void Application_Error()
        {
            RouteData rdata = new RouteData();
            rdata.Values["Controller"] = "";
            rdata.Values["Action"] = "";
            rdata.Values["Msg"] = "";
        }
    }
}
