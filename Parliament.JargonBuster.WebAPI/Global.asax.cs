using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Parliament.Common.IoC;
using Parliament.JargonBuster.WebAPI.DependencyResolution;
using StructureMap.Graph;
using WebApi.StructureMap;

namespace Parliament.JargonBuster.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = Bootstrapper.Build();
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new StructureMapHttpControllerActivator(container));
        }
    }
}
