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
    public class CinemasController : Controller
    {
        CinemaRepository cinemaRepository;
        public CinemasController()
        {
            cinemaRepository = new CinemaRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(cinemaRepository.GetAllCinemas().OrderBy(q => q.ID));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CinemaModel model)
        {
            if (model.NAME == null || model.NAME.IsEmpty())
            {
                ViewBag.Message = "Γράψτε name";
                return View(model);
            }

            cinemaRepository.AddCinema(model);

            ViewBag.Message = "Το cinema διμιουργηθηκέ!";

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                CinemaModel model = cinemaRepository.GetCinemaById((int)id);
                return View(model);
            }
            else
            {
                ViewBag.Message = "Δεν υπάρχει αυτό το cinema. Πρέπει να κάνετε το νέο.";
                return RedirectToAction("Create", "Cinemas");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CinemaModel model)
        {
            if (model.NAME == null || model.NAME.IsEmpty())
            {
                ViewBag.Message = "Γράψτε name";
                return View(model);
            }

            cinemaRepository.UpdateCinema(model);
            ViewBag.Message = "Το cinema άλλαξε!";
            return View();
        }
    }
}