using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Repositories;

namespace askisi_mvc_cinema.Controllers
{
    public class MoviesController : Controller
    {
        private List<UserModel> CurrentUsers = new List<UserModel>();


        [HttpGet]
        public ActionResult Index()
        {

            MovieRepository movieRepository = new MovieRepository();

            return View(movieRepository.GetAllMovies());
        }

        [HttpGet]
        public ActionResult Create()
        {

            UserRepository userRepository = new UserRepository();
            ViewBag.users = userRepository.GetAllUsers();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieModel model)
        {
            MovieRepository movieRepository = new MovieRepository();
            movieRepository.AddMovie(model);

            ViewBag.Message = "Success!";

            UserRepository userRepository = new UserRepository();
            ViewBag.users = userRepository.GetAllUsers();

            // Access any field you need by model.FIELD
            // Return in ViewBag.Message if you want to return something in form

            return View();
        }
    }
}