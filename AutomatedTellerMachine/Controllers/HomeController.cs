using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            //throw new Exception();
            var userid = User.Identity.GetUserId();
            var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var AppUser = UserManager.FindById(userid);

            //get app db context
            var db = new ApplicationDbContext();
            CheckingAccount ca = db.CheckingAccounts.First(cd => cd.ApplicationUserId == userid);
            var CheckingAccountId = ca.Id;

            ViewBag.CheckingAccountId = CheckingAccountId;
            ViewBag.Pin = AppUser.Pin;

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            ViewBag.Toto = "the toto";

            // return PartialView("_ContactThanks");
            return View();
        }

        //get post data from the form
        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = message;

            // return View();
            return PartialView("_ContactThanks");
        }

        public ActionResult foo()
        {
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVCATM1";

            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            else if(letterCase!="upper"){
                //return HttpNotFound();
                // return Json(new{toto=20, kaka="bobo"}, JsonRequestBehavior.AllowGet);
                return RedirectToRoute("Default", new { controller = "Home", action = "Index" });
            }
            return Content(serial);

        }
    }
}