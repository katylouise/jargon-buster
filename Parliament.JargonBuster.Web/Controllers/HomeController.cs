﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Domain.Context;

namespace Parliament.JargonBuster.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EUReferendum_Demo()
        {
            return View();
        }
    }
}