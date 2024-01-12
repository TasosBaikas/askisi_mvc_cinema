using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using askisi_mvc_cinema.Models;

namespace askisi_mvc_cinema.Controllers
{
    public class MoviesController : Controller
    {
        private List<UserModel> CurrentUsers = new List<UserModel>();

        private void getUsers()
        {
            var elements = new List<UserModel>();

            var element = new UserModel
            {
                USERNAME = "test",
                EMAIL = "test@test.com",
                PASSWORD = "test",
                CREATE_TIME = DateTime.Now,
                SALT = "Very salty",
                ROLE = "MY ROLE IS AMAZING"
            };
            elements.Add(element);
            var element1 = new UserModel
            {
                USERNAME = "test1",
                EMAIL = "test@test.com",
                PASSWORD = "test",
                CREATE_TIME = DateTime.Now,
                SALT = "Very salty",
                ROLE = "MY ROLE IS AMAZING"
            };
            elements.Add(element1);

            this.CurrentUsers = elements;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var elements = new List<MovieModel>();

            var element = new MovieModel
            {
                ID = 0,
                LENGTH = 175,
                NAME = "The Godfather",
                SUMMARY = "The story of one man's reluctance to be drawn into the murky family business,and his gradual change through circumstance",
                TYPE = "Criminal",
                CONTENT = "The Godfather is a 1972 American epic crime film directed by Francis Ford Coppola, who co-wrote the screenplay with Mario Puzo, based on Puzo's best-selling 1969 novel of the same title."
            };
            elements.Add(element);
            var element2 = new MovieModel
            {
                ID = 0,
                LENGTH = 175,
                NAME = "The Godfather123",
                SUMMARY = "The story of one man's reluctance to be drawn into the murky family business,and his gradual change through circumstance",
                TYPE = "Criminal",
                CONTENT = "The Godfather is a 1972 American epic crime film directed by Francis Ford Coppola, who co-wrote the screenplay with Mario Puzo, based on Puzo's best-selling 1969 novel of the same title."
            };
            elements.Add(element2);
            var element3 = new MovieModel
            {
                ID = 0,
                LENGTH = 175,
                NAME = "The Godfather421",
                SUMMARY = "The story of one man's reluctance to be drawn into the murky family business,and his gradual change through circumstance",
                TYPE = "Criminal",
                CONTENT = "The Godfather is a 1972 American epic crime film directed by Francis Ford Coppola, who co-wrote the screenplay with Mario Puzo, based on Puzo's best-selling 1969 novel of the same title."
            };
            elements.Add(element3);

            return View(elements);
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.getUsers();
            ViewBag.users = this.CurrentUsers;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieModel newMovie)
        {
            this.getUsers();
            ViewBag.users = this.CurrentUsers;

            // Access any field you need by newMovie.FIELD

            return View();
        }
    }
}