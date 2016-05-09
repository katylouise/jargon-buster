using System.Web.Mvc;
using System.Web.Security;
using AdminApp.Models;

namespace AdminApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, true);
                }

                ModelState.AddModelError("", "Incorrect username and/or password");
            }

            return View("Login");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            return PartialView("_LogOut");
        }

        [HttpPost]
        [ActionName("LogOut")]
        [AllowAnonymous]
        public ActionResult LogOutPost()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}