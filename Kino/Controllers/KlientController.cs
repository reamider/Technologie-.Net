using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kino.Models;

namespace Kino.Controllers
{
    public class KlientController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: /Klient/
        public ActionResult Index()
        {
            var klienci = db.Klienci.Include(k => k.Bilet);
            return View(klienci.ToList());
        }

        // GET: /Klient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klienci.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // GET: /Klient/Create
        public ActionResult Create()
        {
            ViewBag.bilet_id = new SelectList(db.Bilety, "bilet_id", "rodzaj");
            return View();
        }

        // POST: /Klient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="klient_id,imie,nazwisko,data_zak,bilet_id")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Klienci.Add(klient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bilet_id = new SelectList(db.Bilety, "bilet_id", "rodzaj", klient.bilet_id);
            return View(klient);
        }

        // GET: /Klient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klienci.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            ViewBag.bilet_id = new SelectList(db.Bilety, "bilet_id", "rodzaj", klient.bilet_id);
            return View(klient);
        }

        // POST: /Klient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="klient_id,imie,nazwisko,data_zak,bilet_id")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bilet_id = new SelectList(db.Bilety, "bilet_id", "rodzaj", klient.bilet_id);
            return View(klient);
        }

        // GET: /Klient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klienci.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: /Klient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klient klient = db.Klienci.Find(id);
            db.Klienci.Remove(klient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
