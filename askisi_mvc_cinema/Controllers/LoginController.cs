using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Services;

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
            AuthenticateUser authenticateUser = new AuthenticateUser();

            try
            {
                UserModel userModel = authenticateUser.AuthenticateAndReturnUser(model.USERNAME, model.PASSWORD);

                return RedirectToAction("Index", "Home");
            }
            catch (UnauthorizedAccessException ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}