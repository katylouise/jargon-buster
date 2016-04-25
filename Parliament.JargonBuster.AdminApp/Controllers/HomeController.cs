using System.Web.Mvc;
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
                return RedirectToAction("Index");
            }
            return PartialView("_FormModal", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _definitionsViewModelBuilder.BuildDefinitionViewModelFromId(id);
            return PartialView("_FormModal", model);
        }

        [HttpPost]
        public ActionResult Edit(DefinitionViewModel model)
        {
            if (ModelState.IsValidField("Phrase") && ModelState.IsValidField("Definition"))
            {
                _adminDefinitionsService.UpdateDefinitionItem(model);
                return RedirectToAction("Index");
            }
            return PartialView("_FormModal", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _definitionsViewModelBuilder.BuildDefinitionViewModelFromId(id);
            return PartialView("_DeleteModal", model);
        }

        [HttpPost]
        public ActionResult Delete(DefinitionViewModel model)
        {
            _adminDefinitionsService.DeleteDefinitionItem(model);
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