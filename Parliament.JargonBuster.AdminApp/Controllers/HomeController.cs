﻿using System.Web.Mvc;
using AdminApp.ViewModelBuilders;
using AdminApp.ViewModels;
using AdminApp.Services;
using System.Web.Security;
using AdminApp.Models;
using System.Collections.Generic;

namespace AdminApp.Controllers
{
    [Authorize]
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
            return PartialView("_FormModal");
        }

        [HttpPost]
        public ActionResult Add(DefinitionViewModel model)
        {
            if (ModelState.IsValidField("Phrase") && ModelState.IsValidField("Definition"))
            {
                _adminDefinitionsService.AddDefinitionItem(model);
                TempData["Message"] = "You have successfully added a definition.";
                return RedirectToAction("Index");
            }
            return PartialView("_FormModal", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (User.Identity.Name != null)
            {
                var model = _definitionsViewModelBuilder.BuildDefinitionViewModelFromId(id);
                return PartialView("_FormModal", model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Edit(DefinitionViewModel model)
        {
            if (ModelState.IsValidField("Phrase") && ModelState.IsValidField("Definition"))
            {
                _adminDefinitionsService.UpdateDefinitionItem(model);
                TempData["Message"] = "You have successfully updated the definition.";
                return RedirectToAction("Index");
            }
            return PartialView("_FormModal", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.Identity.Name != null)
            {
                var model = _definitionsViewModelBuilder.BuildDefinitionViewModelFromId(id);
                return PartialView("_DeleteModal", model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Delete(DefinitionViewModel model)
        {
            _adminDefinitionsService.DeleteDefinitionItem(model);
            TempData["Message"] = "You have successfully deleted the definition.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ValidateDefinition(string phrase)
        {
            var isValid = _adminDefinitionsService.ValidateDefinition(phrase);
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }
    }
}