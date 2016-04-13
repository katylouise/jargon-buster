using System.Web.Mvc;

namespace Parliament.JargonBuster.AdminApp.Controllers
{
    public class DefinitionsController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
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