using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Models.notentity;
using askisi_mvc_cinema.Models.viewmodels;
using askisi_mvc_cinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace askisi_mvc_cinema.Controllers
{
    public class ProvolesController : Controller
    {
        ProvoliRepository provoliRepository;
        ReservationRepository reservationRepository;


        public ProvolesController()
        {
            provoliRepository = new ProvoliRepository();
            reservationRepository = new ReservationRepository();

        }

        [HttpGet]
        public ActionResult Index(ProvoliViewModel provoliViewModel)
        {
            if (provoliViewModel.PROVOLI_REQUEST == null)
            {
                provoliViewModel.PROVOLI_REQUEST = new ProvoliRequest
                {
                    DATE_FROM = DateTime.Now,
                    DATE_TO = DateTime.Now.AddDays(7),
                };
            }

            List<ProvoliModel> provoliList = provoliRepository.GetAllProvolisThatAreInSpecificTime(provoliViewModel.PROVOLI_REQUEST.DATE_FROM, provoliViewModel.PROVOLI_REQUEST.DATE_TO);

            provoliViewModel.PROVOLI_LIST = provoliList;

            // Pass the modified model to the view
            return View(provoliViewModel);
        }

        [HttpPost]
        public ActionResult ReserveSeats(ReservationModel reservationModel)
        {

            object result;
            if (reservationModel.USER_USERNAME == null || reservationModel.USER_USERNAME.Length == 0)
            {
                result = new { success = false, message = "Δεν έχετε κάνει login" };
                return Json(result);
            }

            ProvoliModel provoli = provoliRepository.GetProvoliById(reservationModel.PROVOLES_ID);
            var seatsAfterTheReservation = provoli.NUMBER_OF_FREE_SEATS - reservationModel.NUMBER_OF_SEATS;
            if (seatsAfterTheReservation < 0)
            {
                result = new { success = false, message = "Δεν υπάρχουν τόσες κενές θέσεις" };
                return Json(result);
            }

            ReservationModel reservationIfExist =  reservationRepository.GetReservationById(reservationModel.PROVOLES_ID,reservationModel.USER_USERNAME);
            if (reservationIfExist != null)
            {
                result = new { success = false, message = "Έχετε κάνει ήδη κράτηση" };
                return Json(result);
            }

            reservationRepository.AddReservation(reservationModel);

            provoli.NUMBER_OF_FREE_SEATS = seatsAfterTheReservation;
            provoliRepository.UpdateProvoli(provoli);


            result = new { success = true, message = "Επιτυχής κράτηση"};
            return Json(result);
        }



        [HttpGet]
        public ActionResult History(HistoryViewModel historyViewModel)
        {

            if (historyViewModel.USER_USERNAME == null)
            {
                return View();
            }

            if (historyViewModel.USER_USERNAME == "TheUserHasNoName...")
            {
                return View(historyViewModel);
            }

            List<ReservationModel> reservationModels = reservationRepository.getReservationsByUsername(historyViewModel.USER_USERNAME);

            List<int> provolesIds = reservationModels.Select(reservation => reservation.PROVOLES_ID).ToList();

            List<ProvoliModel> provoliList = provoliRepository.GetProvolisByIds(provolesIds);

            historyViewModel.RESERVE_SEATS_LIST = reservationModels;
            historyViewModel.PROVOLI_LIST = provoliList;

            // Pass the modified model to the view
            return View(historyViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Reserve()
        {
            return View();
        }
    }
}