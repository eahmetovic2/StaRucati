using StaRucati.Context;
using StaRucati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaRucati.Controllers
{
    public class JeloController : Controller
    {
        StaRucatiContext db = new StaRucatiContext();
        // GET: Jelo
        public ActionResult Index()
        {
            return View(db.Jela.ToList());
        }

        // GET: Jelo/Restoran/5
        public ActionResult JelaIzRestorana(int id)
        {
            var jela = from j in db.Jela
                       where j.RestoranId == id
                       select j;
            ViewBag.RestoranId = id;
            var restoran = db.Restorani.FirstOrDefault(item => item.Id == id);
            ViewBag.Restoran = restoran.Naziv;
            return View(jela);
        }       

        // GET: Jelo/Create
        public ActionResult Create()
        {
            ViewBag.Restorani = new SelectList(db.Restorani.Select(o => o.Id).ToList());
            return View();
        }

        // POST: Jelo/Create
        [HttpPost]
        public ActionResult Create(Jelo jelo)
        {
            try
            {
                // TODO: Add insert logic here
                db.Jela.Add(jelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(jelo);
            }
        }

        // GET: Jelo/CreateForThisRestourant/5
        public ActionResult CreateForThisRestourant(int id)
        {
            ViewBag.RestoranId = id;
            Jelo jelo = new Jelo();
            jelo.RestoranId = id;
            var restoran = db.Restorani.FirstOrDefault(item => item.Id == id);
            ViewBag.Restoran = restoran.Naziv;
            return View(jelo);
        }

        // POST: Jelo/CreateForThisRestourant
        [HttpPost]
        public ActionResult CreateForThisRestourant(Jelo jelo)
        {
            //Jelo jelo = new Jelo();
            try
            {
                // TODO: Add insert logic here
                db.Jela.Add(jelo);
                db.SaveChanges();
                int id = jelo.RestoranId;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(jelo);
            }
        }

        // GET: Jelo/Delete/5
        public ActionResult Delete(int id)
        {
            var jelo = db.Jela.FirstOrDefault(item => item.Id == id);

            if (jelo != null)
            {
                db.Jela.Remove(jelo);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
