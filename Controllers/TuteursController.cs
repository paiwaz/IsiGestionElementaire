using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsiGestionElementaire.Models;
using PagedList;

namespace IsiGestionElementaire.Controllers
{
    [Authorize]
    public class TuteursController : Controller
    {
        private BdElementaireContext db = new BdElementaireContext();
        private const int pageSize = 25;
        // GET: Tuteurs
        public ActionResult Index(string NumCNI, int? page)
        {
            ViewBag.NumCNI = String.IsNullOrEmpty(NumCNI) ? "" : "par Numèro CNI";
            if (NumCNI == "par Numèro CNI")
            { NumCNI = ""; }
            else if (NumCNI != null)
            {
                ViewBag.NumCNI = NumCNI;
            }
            else
            {
                ViewBag.NumCNI = "par Numèro CNI";
            }
            int pageNumber = page.HasValue ? page.Value : 1;
            List<Tuteur> tuteurs = db.Tuteur.ToList();
            if (!string.IsNullOrWhiteSpace(NumCNI))
            {
                tuteurs = tuteurs.Where(a => a.CNI != null).ToList();
                tuteurs = tuteurs.Where(a => a.CNI.ToUpper().Contains(NumCNI.ToUpper())).ToList();
            }
            PagedList<Tuteur> model = new PagedList<Tuteur>(tuteurs, pageNumber, pageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int? page, string NumCNI)
        {
            ViewBag.NumCNI = String.IsNullOrEmpty(NumCNI) ? "" : "par Numèro CNI";
            if (NumCNI == "par Numèro CNI")
            { NumCNI = ""; }
            else if (NumCNI != null)
            {
                ViewBag.NumCNI = NumCNI;
            }
            else
            {
                ViewBag.NumCNI = "par Numèro CNI";
            }
            int pageNumber = page.HasValue ? page.Value : 1;
            List<Tuteur> tuteurs = db.Tuteur.ToList();
            if (!string.IsNullOrWhiteSpace(NumCNI))
            {
                tuteurs = tuteurs.Where(a => a.CNI != null).ToList();
                tuteurs = tuteurs.Where(a => a.CNI.ToUpper().Contains(NumCNI.ToUpper())).ToList();
            }
            PagedList<Tuteur> model = new PagedList<Tuteur>(tuteurs, pageNumber, pageSize);
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult ListTuteur (int? id)
        {
            ViewBag.id = id;
            return PartialView(db.Tuteur.ToList());
        }

        // GET: Tuteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuteur tuteur = db.Tuteur.Find(id);
            if (tuteur == null)
            {
                return HttpNotFound();
            }
            return View(tuteur);
        }

        // GET: Tuteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tuteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CNI,NomTuteur,PrenomTuteur,AdresseTuteur,TelTuteur,EmailTuteur,CiviliteTuteur,Parente")] Tuteur tuteur)
        {
            if (ModelState.IsValid)
            {
                db.Tuteur.Add(tuteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuteur);
        }

        // GET: Tuteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuteur tuteur = db.Tuteur.Find(id);
            if (tuteur == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = id;
            return View(tuteur);
        }

        public ActionResult AddTuteurToEleve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuteur tuteur = db.Tuteur.Find(id);
            if (tuteur == null)
            {
                return HttpNotFound();
            }
            return PartialView(tuteur);
        }

        // POST: Tuteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CNI,NomTuteur,PrenomTuteur,AdresseTuteur,TelTuteur,EmailTuteur,CiviliteTuteur,Parente")] Tuteur tuteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuteur);
        }

        // GET: Tuteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuteur tuteur = db.Tuteur.Find(id);
            if (tuteur == null)
            {
                return HttpNotFound();
            }
            return View(tuteur);
        }

        // POST: Tuteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tuteur tuteur = db.Tuteur.Find(id);
            db.Tuteur.Remove(tuteur);
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
