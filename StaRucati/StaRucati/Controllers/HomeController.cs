using StaRucati.Context;
using StaRucati.Models;
using StaRucati.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaRucati.Controllers
{
    public class HomeController : Controller
    {
        StaRucatiContext db = new StaRucatiContext();
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Predlozi()
        {
            var svaJela = db.Jela.ToList();
            var restorani = db.Restorani.ToList();
            Random rnd = new Random();
            int r = rnd.Next(svaJela.Count);
            Restoran restoran = new Restoran();
            foreach(Restoran re in restorani) {
                if (re.Id == svaJela[r].RestoranId)
                    restoran = re;
            }
            RandomJeloViewModel randomJelo = new RandomJeloViewModel
            {
                Jelo = svaJela[r],
                Restoran = restoran
            };
            return View(randomJelo);
        }
    }
}