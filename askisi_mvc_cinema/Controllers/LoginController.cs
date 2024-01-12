using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using askisi_mvc_cinema.Models;

namespace askisi_mvc_cinema.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserModel login, string returnUrl)
        {
            // Access any field by login.FIELD
            ViewBag.Message = login.USERNAME + '|' + login.PASSWORD;
            // Check if logged in and return to home page
            return View();
        }
    }
}