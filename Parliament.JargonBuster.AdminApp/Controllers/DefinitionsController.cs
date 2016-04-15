﻿using Parliament.JargonBuster.Core.Services;
using System.Web.Mvc;

namespace Parliament.JargonBuster.AdminApp.Controllers
{
    public class DefinitionsController : Controller
    {
        private readonly IDefinitionsService _definitionsService;
        public DefinitionsController(IDefinitionsService DefinitionsService)
        {
            _definitionsService = DefinitionsService;
        }
        public ActionResult Index()
        {
            var model = _definitionsService.GetDefinitions();
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View("Create");
        //}

        //[HttpPost]
        //public ActionResult Create()
        //{
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    return View("Edit");
        //}

        //[HttpPost]
        //public ActionResult Edit()
        //{
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    return View("Delete");
        //}

        //[HttpPost]
        //public ActionResult Delete()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}