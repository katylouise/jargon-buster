﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parliament.JargonBuster.Core.Services;
using AdminApp.ViewModelBuilders;
using AdminApp.ViewModels;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        private IDefinitionsViewModelBuilder _definitionsViewModelBuilder;

        public HomeController(IDefinitionsViewModelBuilder definitionsViewModelBuilder)
        {
            _definitionsViewModelBuilder = definitionsViewModelBuilder;
        }

        public ActionResult Index()
        {
            var model = _definitionsViewModelBuilder.Build();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _definitionsViewModelBuilder.BuildDefinitionViewModelFromId(id);

            return PartialView("_EditModal", model);
        }

        [HttpPost]
        public ActionResult Edit(DefinitionViewModel model)
        {
            _definitionsViewModelBuilder.UpdateDefinitionViewModel(model);
            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var phrase = _definitionsViewModelBuilder.BuildDefinitionViewModelFromPhrase(searchTerm.Trim());

            //TODO - talk to Jack about what searching should look like
            return Redirect("Index");
        }
    }
}