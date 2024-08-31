using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uczelnia.Context;
using Uczelnia.Models;

namespace Uczelnia.Controllers
{
    public class OcenasController : Controller
    {
        private UczelniaContext db = new UczelniaContext();

        // GET: Ocenas
        public ActionResult Index()
        {
            return View(db.Ocena.ToList());
        }

        // GET: Ocenas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena ocena = db.Ocena.Find(id);
            if (ocena == null)
            {
                return HttpNotFound();
            }
            return View(ocena);
        }

        // GET: Ocenas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ocenas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OcenaId,ocenka")] Ocena ocena)
        {
            if (ModelState.IsValid)
            {
                db.Ocena.Add(ocena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ocena);
        }

        // GET: Ocenas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena ocena = db.Ocena.Find(id);
            if (ocena == null)
            {
                return HttpNotFound();
            }
            return View(ocena);
        }

        // POST: Ocenas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OcenaId,ocenka")] Ocena ocena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ocena);
        }

        // GET: Ocenas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena ocena = db.Ocena.Find(id);
            if (ocena == null)
            {
                return HttpNotFound();
            }
            return View(ocena);
        }

        // POST: Ocenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ocena ocena = db.Ocena.Find(id);
            db.Ocena.Remove(ocena);
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
