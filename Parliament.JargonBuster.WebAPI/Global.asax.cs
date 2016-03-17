using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using Parliament.Common.IoC;
using Parliament.JargonBuster.WebAPI.DependencyResolution;


namespace Parliament.JargonBuster.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            _logger.Info("Application Started");
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = Bootstrapper.Build();

            _logger.Debug(container.WhatDoIHave());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new StructureMapHttpControllerActivator(container));
        }

        protected void Application_Error()
        {
            var error = Server.GetLastError();
            _logger.Error(error);
        }

        protected void Application_Stop()
        {
            _logger.Info("Application Stopped");
        }
    }
}
