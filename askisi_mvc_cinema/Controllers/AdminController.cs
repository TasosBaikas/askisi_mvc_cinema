using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using askisi_mvc_cinema.helpers;
using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Repositories;
using askisi_mvc_cinema.Services;

namespace askisi_mvc_cinema.Controllers
{
    public class AdminController : Controller
    {
        [ActionName("RegisterContentAdmin")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ActionName("RegisterContentAdmin")]
        public ActionResult Register(UserModel model, string returnUrl)
        {

            UserRepository userRepository = new UserRepository();
            if (model.EMAIL == null || model.EMAIL.IsEmpty())
            {
                ViewBag.Message = "����� email";
                return View();
            }

            if (model.USERNAME == null || model.USERNAME.IsEmpty())
            {
                ViewBag.Message = "����� username";
                return View();
            }

            if (model.PASSWORD == null || model.PASSWORD.IsEmpty())
            {
                ViewBag.Message = "����� password";
                return View();
            }

            UserModel modelFromDb = userRepository.GetUserByUsername(model.USERNAME);
            if (modelFromDb != null)
            {
                ViewBag.Message = "User exists";
                return View();
            }

            model.ROLE = UserRoles.ContentAdmin;
            model.CREATE_TIME = DateTime.Now;
            model.SALT = GenerateRandomString.Generate(4);
            model.PASSWORD = AuthenticateUser.HashPassword(model.PASSWORD, model.SALT);

            userRepository.AddUser(model);

            ViewBag.Message = "Success! content-admin registered!";

            return View();
        }


        [ActionName("DeleteContentAdmin")]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteContentAdmin")]
        public ActionResult Delete(UserModel model, string returnUrl)
        {

            UserRepository userRepository = new UserRepository();
            if (model.USERNAME == null || model.USERNAME.IsEmpty())
            {
                ViewBag.Message = "����� username";
                return View();
            }

            UserModel modelFromDb = userRepository.GetUserByUsername(model.USERNAME);
            if (modelFromDb == null)
            {
                ViewBag.Message = "User does not exist";
                return View();
            }

            userRepository.DeleteUser(modelFromDb);

            ViewBag.Message = "content-admin deleted!";

            return View();
        }

    }
}