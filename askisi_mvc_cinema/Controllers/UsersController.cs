using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Models.notentity;
using askisi_mvc_cinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace askisi_mvc_cinema.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

       
        
    }
}