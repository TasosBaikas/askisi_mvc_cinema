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
        public ActionResult Index(UserModel model, string returnUrl)
        {
            // Access any field you need by model.FIELD
            // Return in ViewBag.Message if you want to return something in form
            return View();
        }
    }
}