﻿using AdminApp.Services;
using AdminApp.ViewModelBuilders;
using Parliament.JargonBuster.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace AdminApp.Controllers.ControllerFactory
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IDefinitionsService definitionService = new DefinitionsService();
            IAdminDefinitionsService adminDefinitionsService = new AdminDefinitionsService(definitionService);
            IDefinitionsViewModelBuilder definitionsViewModelBuilder = new DefinitionsViewModelBuilder(definitionService);
            var controller = new HomeController(definitionsViewModelBuilder, adminDefinitionsService);
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}