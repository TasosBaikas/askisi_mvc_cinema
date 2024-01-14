using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Repositories;
using askisi_mvc_cinema.Services;

namespace askisi_mvc_cinema.Controllers
{
    public class AdminController : Controller
    {
        [ActionName("RegisterContentAdmin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ActionName("RegisterContentAdmin")]
        public ActionResult Index(UserModel model, string returnUrl)
        {

            UserRepository userRepository = new UserRepository(new YourDbContext());
            if (model.EMAIL == null || model.EMAIL.IsEmpty())
            {
                ViewBag.Message = "Δώστε email";
                return View();
            }

            if (model.USERNAME == null || model.USERNAME.IsEmpty())
            {
                ViewBag.Message = "Δώστε username";
                return View();
            }

            if (model.PASSWORD == null || model.PASSWORD.IsEmpty())
            {
                ViewBag.Message = "Δώστε password";
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
            model.SALT = GenerateRandomString(4);
            userRepository.AddUser(model);

            ViewBag.Message = "Success! content-admin registered!";

            return View();
        }

        public static string GenerateRandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }
    }
}