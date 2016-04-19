﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parliament.JargonBuster.Core.Services;
using AdminApp.ViewModelBuilders;
using AdminApp.ViewModels;
using AdminApp.Services;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        private IDefinitionsViewModelBuilder _definitionsViewModelBuilder;
        private IAdminDefinitionsService _adminDefinitionsService;

        public HomeController(IDefinitionsViewModelBuilder definitionsViewModelBuilder, IAdminDefinitionsService adminDefinitionsService)
        {
            _definitionsViewModelBuilder = definitionsViewModelBuilder;
            _adminDefinitionsService = adminDefinitionsService;
        }

        public ActionResult Index()
        {
            var model = _definitionsViewModelBuilder.Build();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("_EditModal");
        }

        [HttpPost]
        public ActionResult Add(DefinitionViewModel model, string newAlternate)
        {
            var newAlternates = new List<AlternateItemViewModel>();
            newAlternates.Add(new AlternateItemViewModel { AlternateDefinition = newAlternate });
            model.Alternates = newAlternates;
            _adminDefinitionsService.AddDefinitionViewModel(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _definitionsViewModelBuilder.BuildDefinitionViewModelFromId(id);

            return PartialView("_EditModal", model);
        }

        [HttpPost]
        public ActionResult Edit(DefinitionViewModel model, string newAlternate)
        {
            _adminDefinitionsService.UpdateDefinitionViewModel(model);
            return RedirectToAction("Index");
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