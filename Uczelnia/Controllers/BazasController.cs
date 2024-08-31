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
using System.Linq;

namespace Uczelnia.Controllers
{
    public class BazasController : Controller
    {
        private UczelniaContext db = new UczelniaContext();

        // GET: Bazas
        public ActionResult Index()
        {
            var baza = db.Baza.Include(b => b.Prowadzacy).Include(b => b.Przedmiot).Include(b => b.Student).Include(b => b.Ocena).Include(b => b.Jaka);
            return View(baza.ToList());
        }

  

        // GET: Bazas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baza baza = db.Baza.Find(id);
            if (baza == null)
            {
                return HttpNotFound();
            }
            return View(baza);
        }

        // GET: Bazas/Create
        public ActionResult Create()
        {
            ViewBag.ProwadzacyId = new SelectList(db.Prowadzacy, "ProwadzacyId", "Identyfikator");
            ViewBag.PrzedmiotId = new SelectList(db.Przedmioty, "PrzedmiotId", "NazwaPrzemiotu");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "index");
            ViewBag.OcenaId = new SelectList(db.Ocena, "OcenaId", "ocenka");
            ViewBag.JakaId = new SelectList(db.Jaka, "JakaId", "jakatoocena");
            return View();
        }

        // POST: Bazas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BazaId,StudentId,PrzedmiotId,ProwadzacyId,OcenaId,JakaId")] Baza baza)
        {
            if (ModelState.IsValid)
            {
                db.Baza.Add(baza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProwadzacyId = new SelectList(db.Prowadzacy, "ProwadzacyId", "Identyfikator", baza.ProwadzacyId);
            ViewBag.PrzedmiotId = new SelectList(db.Przedmioty, "PrzedmiotId", "NazwaPrzemiotu", baza.PrzedmiotId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "index", baza.StudentId);
            ViewBag.OcenaId = new SelectList(db.Ocena, "OcenaId", "ocenka", baza.OcenaId);
            ViewBag.JakaId = new SelectList(db.Jaka, "JakaId", "jakatoocena", baza.JakaId);
            return View(baza);
        }

        // GET: Bazas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baza baza = db.Baza.Find(id);
            if (baza == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProwadzacyId = new SelectList(db.Prowadzacy, "ProwadzacyId", "Identyfikator", baza.ProwadzacyId);
            ViewBag.PrzedmiotId = new SelectList(db.Przedmioty, "PrzedmiotId", "NazwaPrzemiotu", baza.PrzedmiotId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "index", baza.StudentId);
            ViewBag.OcenaId = new SelectList(db.Ocena, "OcenaId", "ocenka", baza.OcenaId);
            ViewBag.JakaId = new SelectList(db.Jaka, "JakaId", "jakatoocena", baza.JakaId);
            return View(baza);
        }

        // POST: Bazas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BazaId,StudentId,PrzedmiotId,ProwadzacyId,OcenaId,JakaId")] Baza baza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProwadzacyId = new SelectList(db.Prowadzacy, "ProwadzacyId", "Identyfikator", baza.ProwadzacyId);
            ViewBag.PrzedmiotId = new SelectList(db.Przedmioty, "PrzedmiotId", "NazwaPrzemiotu", baza.PrzedmiotId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "index", baza.StudentId);
            ViewBag.OcenaId = new SelectList(db.Ocena, "OcenaId", "ocenka", baza.OcenaId);
            ViewBag.JakaId = new SelectList(db.Jaka, "JakaId", "jakatoocena", baza.JakaId);
            return View(baza);
        }

        // GET: Bazas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baza baza = db.Baza.Find(id);
            if (baza == null)
            {
                return HttpNotFound();
            }
            return View(baza);
        }

        // POST: Bazas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Baza baza = db.Baza.Find(id);
            db.Baza.Remove(baza);
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
