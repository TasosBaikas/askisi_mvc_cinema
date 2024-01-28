using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using askisi_mvc_cinema.helpers;
using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Repositories;
using askisi_mvc_cinema.Services;

namespace askisi_mvc_cinema.Controllers
{
    public class RegisterClientController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserModel model)
        {

            if (model.EMAIL == null || model.EMAIL.IsEmpty())
            {
                ViewBag.Message = "Γράψτε email";
                return View();
            }

            if (model.USERNAME == null || model.USERNAME.IsEmpty())
            {
                ViewBag.Message = "Γράψτε username";
                return View();
            }

            if (model.PASSWORD == null || model.PASSWORD.IsEmpty())
            {
                ViewBag.Message = "Γράψτε password";
                return View();
            }

            UserRepository userRepository = new UserRepository();

            UserModel modelFromDb = userRepository.GetUserByUsername(model.USERNAME);
            if (modelFromDb != null)
            {
                ViewBag.Message = "User exists";
                return View();
            }

            model.ROLE = UserRoles.Costumer;
            model.CREATE_TIME = DateTime.Now;
            model.SALT = GenerateRandomString.Generate(4);
            model.PASSWORD = AuthenticateUser.HashPassword(model.PASSWORD, model.SALT);

            userRepository.AddUser(model);

            ViewBag.Message = "Success! customer registered!";

            return RedirectToAction("Index", "Home");
        }
    }
}