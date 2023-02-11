using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsiGestionElementaire.Models;

namespace IsiGestionElementaire.Controllers
{
    public class ExercicesController : Controller
    {
        private BdElementaireContext db = new BdElementaireContext();

        // GET: Exercices
        public ActionResult Index()
        {
            return View(db.Exercice.ToList());
        }

        // GET: Exercices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercice.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // GET: Exercices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Annee")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                db.Exercice.Add(exercice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercice);
        }

        // GET: Exercices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercice.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // POST: Exercices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Annee")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exercice);
        }

        // GET: Exercices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercice.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // POST: Exercices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercice exercice = db.Exercice.Find(id);
            db.Exercice.Remove(exercice);
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
