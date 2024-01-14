using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using askisi_mvc_cinema.Models;

namespace askisi_mvc_cinema.Controllers
{
    public class ReservationsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var elements = new List<ReservationModel>();

            var element = new ReservationModel
            {
                PROVOLES_ID = 1,
                NUMBER_OF_SEATS = 1,
                USER_USERNAME = "TEST"
            };
            elements.Add(element);
            var element1 = new ReservationModel
            {
                PROVOLES_ID = 2,
                NUMBER_OF_SEATS = 2,
                USER_USERNAME = "TEST"
            };
            elements.Add(element1);

            return View(elements);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var provoles = new List<ProvoliModel>();
            var provoliElement = new ProvoliModel
            {
                MOVIES_ID = 1,
                MOVIES_NAME = "Godfather",
                CINEMAS_ID = 1,
                USER_USERNAME = "TEST"
            };
            provoles.Add(provoliElement);
            ViewBag.Provoles = provoles;

            var cinemas = new List<CinemaModel>();
            var cinemaElement = new CinemaModel
            {
                ID = 1,
                NAME = "TEST",
                SEATS = 160,
                _3D = "IMAX 3D"
            };
            cinemas.Add(cinemaElement);
            ViewBag.Cinemas = cinemas;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ReservationModel model)
        {
            var provoles = new List<ProvoliModel>();
            var provoliElement = new ProvoliModel
            {
                MOVIES_ID = 1,
                MOVIES_NAME = "Godfather",
                CINEMAS_ID = 1,
                USER_USERNAME = "TEST"
            };
            provoles.Add(provoliElement);
            ViewBag.Provoles = provoles;

            var cinemas = new List<CinemaModel>();
            var cinemaElement = new CinemaModel
            {
                ID = 1,
                NAME = "TEST",
                SEATS = 160,
                _3D = "IMAX 3D"
            };
            cinemas.Add(cinemaElement);
            ViewBag.Cinemas = cinemas;
            // Access any field you need by model.FIELD
            // Return in ViewBag.Message if you want to return something in form
            return View();
        }
    }
}