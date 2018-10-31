using StaRucati.Context;
using StaRucati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaRucati.Controllers
{
    public class RestoranController : Controller
    {
        StaRucatiContext db = new StaRucatiContext();
        // GET: Restoran
        public ActionResult Index()
        {
            return View(db.Restorani.ToList());
        }        

        // GET: Restoran/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restoran/Create
        [HttpPost]
        public ActionResult Create(Restoran restoran)
        {
            try
            {
                // TODO: Add insert logic here
                db.Restorani.Add(restoran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(restoran);
            }
        }

        // GET: Restoran/Delete/5
        public ActionResult Delete(int id)
        {
            var restoran = db.Restorani.FirstOrDefault(item => item.Id == id);

            if (restoran != null)
            {
                db.Restorani.Remove(restoran);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Restoran/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
