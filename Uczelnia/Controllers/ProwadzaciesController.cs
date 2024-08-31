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
    public class ProwadzaciesController : Controller
    {
        private UczelniaContext db = new UczelniaContext();

        // GET: Prowadzacies
        public ActionResult Index()
        {
            return View(db.Prowadzacy.ToList());
        }

        // GET: Prowadzacies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prowadzacy prowadzacy = db.Prowadzacy.Find(id);
            if (prowadzacy == null)
            {
                return HttpNotFound();
            }
            return View(prowadzacy);
        }

        // GET: Prowadzacies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prowadzacies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProwadzacyId,Imie,Nazwisko,Identyfikator")] Prowadzacy prowadzacy)
        {
            if (ModelState.IsValid)
            {
                db.Prowadzacy.Add(prowadzacy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prowadzacy);
        }

        // GET: Prowadzacies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prowadzacy prowadzacy = db.Prowadzacy.Find(id);
            if (prowadzacy == null)
            {
                return HttpNotFound();
            }
            return View(prowadzacy);
        }

        // POST: Prowadzacies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProwadzacyId,Imie,Nazwisko,Identyfikator")] Prowadzacy prowadzacy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prowadzacy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prowadzacy);
        }

        // GET: Prowadzacies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prowadzacy prowadzacy = db.Prowadzacy.Find(id);
            if (prowadzacy == null)
            {
                return HttpNotFound();
            }
            return View(prowadzacy);
        }

        // POST: Prowadzacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prowadzacy prowadzacy = db.Prowadzacy.Find(id);
            db.Prowadzacy.Remove(prowadzacy);
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
