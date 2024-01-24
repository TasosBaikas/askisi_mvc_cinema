using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Repositories;

namespace askisi_mvc_cinema.Controllers
{
    public class MoviesController : Controller
    {
        MovieRepository movieRepository;
        public MoviesController()
        {
            movieRepository = new MovieRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(movieRepository.GetAllMovies().OrderBy(q => q.ID));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieModel model)
        {
            if (model.NAME == null || model.NAME.IsEmpty())
            {
                ViewBag.Message = "Γράψτε name";
                return View(model);
            }

            if (model.CONTENT == null || model.CONTENT.IsEmpty())
            {
                ViewBag.Message = "Γράψτε content";
                return View(model);
            }

            if (model.LENGTH == null || model.LENGTH == 0)
            {
                ViewBag.Message = "Γράψτε length σε λεπτά";
                return View(model);
            }

            if (model.TYPE == null || model.TYPE.IsEmpty())
            {
                ViewBag.Message = "Γράψτε type";
                return View(model);
            }

            if (model.SUMMARY == null || model.SUMMARY.IsEmpty())
            {
                ViewBag.Message = "Γράψτε summary";
                return View(model);
            }

            if (model.DIRECTOR == null || model.DIRECTOR.IsEmpty())
            {
                ViewBag.Message = "Γράψτε director";
                return View(model);
            }

            model.USER_USERNAME = User.Identity.Name;

            movieRepository.AddMovie(model);

            ViewBag.Message = "Η ταινία διμιουργηθηκέ!";

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                MovieModel model = movieRepository.GetMovieById((int)id);
                return View(model);
            }
            else
            {
                ViewBag.Message = "Δεν υπάρχει αυτή η ταινία. Πρέπει να κάνετε η νέα.";
                return RedirectToAction("Create", "Movies");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieModel model)
        {
            if (model.NAME == null || model.NAME.IsEmpty())
            {
                ViewBag.Message = "Γράψτε name";
                return View(model);
            }

            if (model.CONTENT == null || model.CONTENT.IsEmpty())
            {
                ViewBag.Message = "Γράψτε content";
                return View(model);
            }

            if (model.LENGTH == null || model.LENGTH == 0)
            {
                ViewBag.Message = "Γράψτε length σε λεπτά";
                return View(model);
            }

            if (model.TYPE == null || model.TYPE.IsEmpty())
            {
                ViewBag.Message = "Γράψτε type";
                return View(model);
            }

            if (model.SUMMARY == null || model.SUMMARY.IsEmpty())
            {
                ViewBag.Message = "Γράψτε summary";
                return View(model);
            }

            if (model.DIRECTOR == null || model.DIRECTOR.IsEmpty())
            {
                ViewBag.Message = "Γράψτε director";
                return View(model);
            }

            movieRepository.UpdateMovie(model);
            ViewBag.Message = "Η ταινία άλλαξε!";
            return View();
        }
    }
}