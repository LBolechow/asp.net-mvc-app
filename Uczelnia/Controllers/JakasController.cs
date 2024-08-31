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
    public class JakasController : Controller
    {
        private UczelniaContext db = new UczelniaContext();

        // GET: Jakas
        public ActionResult Index()
        {
            return View(db.Jaka.ToList());
        }

        // GET: Jakas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaka jaka = db.Jaka.Find(id);
            if (jaka == null)
            {
                return HttpNotFound();
            }
            return View(jaka);
        }

        // GET: Jakas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jakas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JakaId,jakatoocena")] Jaka jaka)
        {
            if (ModelState.IsValid)
            {
                db.Jaka.Add(jaka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jaka);
        }

        // GET: Jakas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaka jaka = db.Jaka.Find(id);
            if (jaka == null)
            {
                return HttpNotFound();
            }
            return View(jaka);
        }

        // POST: Jakas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JakaId,jakatoocena")] Jaka jaka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jaka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jaka);
        }

        // GET: Jakas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaka jaka = db.Jaka.Find(id);
            if (jaka == null)
            {
                return HttpNotFound();
            }
            return View(jaka);
        }

        // POST: Jakas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jaka jaka = db.Jaka.Find(id);
            db.Jaka.Remove(jaka);
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
