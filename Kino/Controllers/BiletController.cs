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
    public class BiletController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: /Bilet/
        public ActionResult Index()
        {
            return View(db.Bilety.ToList());
        }

        // GET: /Bilet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilety.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // GET: /Bilet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Bilet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="bilet_id,rodzaj,opis,cena")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                db.Bilety.Add(bilet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bilet);
        }

        // GET: /Bilet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilety.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // POST: /Bilet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="bilet_id,rodzaj,opis,cena")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilet);
        }

        // GET: /Bilet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilety.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // POST: /Bilet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilet bilet = db.Bilety.Find(id);
            db.Bilety.Remove(bilet);
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
