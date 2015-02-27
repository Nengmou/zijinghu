using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZiJingHu.Models;

namespace ZiJingHu.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Client/
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        #region Login
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                this.Session.Clear();
                if (Request.IsAuthenticated)
                {
                    //WebSecurity.Logout();
                    FormsAuthentication.SignOut();
                    ViewBag.ReturnUrl = null;
                }
                else
                {
                    ViewBag.ReturnUrl = returnUrl;
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", String.Format("Unable to Login."));
            }

            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            if (model.Username == "admin" && model.Password == "111111")
            {
                this.Session.Add("IsLogin", true);
                if (returnUrl != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(model.Username, false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect, or password is not set.");
            return View(model);
        }
        #endregion

        #region LogOff
        [HttpPost]
        [Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            try
            {
                //WebSecurity.Logout();
                FormsAuthentication.SignOut();
                this.Session.Clear();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", String.Format("Unable to log off."));
            }

            return RedirectToAction("Index", "Home");

        }
        #endregion
	}
}