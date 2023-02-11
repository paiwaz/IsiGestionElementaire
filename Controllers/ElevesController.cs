using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsiGestionElementaire.Models;
using System.IO;

namespace IsiGestionElementaire.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class ElevesController : Controller
    {
        private BdElementaireContext db = new BdElementaireContext();
        private BdElementaireEntities _db = new BdElementaireEntities();

        // GET: Eleves
        public ActionResult Index()
        {
            return View(db.Eleve.ToList());
        }

        // GET: Eleves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleve.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // GET: Eleves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eleves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricule,Nom,Prenom,Sexe,DateNaiss,LieuNaiss")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Eleve.Add(eleve);
                db.SaveChanges();
                return RedirectToAction("AddTuteur", new { id = eleve.Id });
            }

            return View(eleve);
        }

        public ActionResult AddTuteur(int? id)
        {
            ViewBag.id = id;
            //ParentEleve parentEleve = db.ParentEleve.Where(a => a.IdEleve == id).ToList();
            ViewBag.parent = _db.VParentEleve.Where(a => a.IdEleve == id).ToList();
            return View(db.Tuteur.ToList());
        }

        public ActionResult Affecter(int? id, int? idEleve)
        {
            ParentEleve pr = new ParentEleve();
            pr.IdEleve = idEleve;
            pr.IdTuteur = id;
            pr.Priorite = "non";
            db.ParentEleve.Add(pr);
            db.SaveChanges();
            return RedirectToAction("AddTuteur", new { id = idEleve });
        }

        public ActionResult AddService(int ?id)
        {
            return View();
        }

        public ActionResult Retirer(int? id, int? idEleve)
        {
            ParentEleve pr = db.ParentEleve.Where(a => a.IdEleve == idEleve && a.IdTuteur == id).FirstOrDefault();
            db.ParentEleve.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("AddTuteur", new { id = idEleve });
        }

        // GET: Eleves/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.id = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleve.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricule,Nom,Prenom,Sexe,DateNaiss,LieuNaiss")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleve.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eleve eleve = db.Eleve.Find(id);
            db.Eleve.Remove(eleve);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public DataTable GetTableEleve(int id)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Matricule", typeof(string));
            table.Columns.Add("Nom", typeof(string));
            table.Columns.Add("Prenom", typeof(string));
            table.Columns.Add("Sexe", typeof(string));
            table.Columns.Add("DateNaiss", typeof(DateTime));
            table.Columns.Add("LieuNaiss", typeof(string));
            Eleve e = db.Eleve.Find(id);

            table.Rows.Add(e.Matricule, e.Nom, e.Prenom, e.Sexe, e.DateNaiss, e.LieuNaiss);

            return table;
        }

        public DataTable GetTableTuteur(int id)
        {
            DataTable table = new DataTable();
            table.Columns.Add("NomTuteur", typeof(string));
            table.Columns.Add("PrenomTuteur", typeof(string));
            table.Columns.Add("AdresseTuteur", typeof(string));
            table.Columns.Add("TelTuteur", typeof(string));
            table.Columns.Add("EmailTuteur", typeof(string));
            var listTuteur = _db.VTuteur.Where(a => a.IdEleve == id).ToList();
            foreach (VTuteur e in listTuteur)
            {
                table.Rows.Add(e.NomTuteur, e.PrenomTuteur, e.AdresseTuteur, e.TelTuteur, e.EmailTuteur);
            }
            return table;
        }

        public ActionResult ReportEleve(int id)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {
                rpt.Load(Server.MapPath("~/Report/rptEleves.rpt"));
                rpt.SetDataSource(GetTableEleve(id));
                Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.AppendHeader("Content-Disposition", "inline");
                return File(stream, "application/pdf");
            }
            finally
            {
                rpt.Dispose();
                rpt.Close();
            }
        }

        public ActionResult RaportEleve(int id)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {
                rpt.Load(Server.MapPath("~/Report/rptInscription.rpt"));
                rpt.SetDataSource(GetTableEleve(id));
                rpt.Subreports[0].SetDataSource(GetTableTuteur(id));
                rpt.Subreports[0].DataSourceConnections.Clear();
                Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.AppendHeader("Content-Disposition", "inline");
                return File(stream, "application/pdf");
            }
            finally
            {
                rpt.Dispose();
                rpt.Close();
            }
        }

        public DataTable GetTableEleveTuteur(int id)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Matricule", typeof(string));
            table.Columns.Add("Nom", typeof(string));
            table.Columns.Add("Prenom", typeof(string));
            table.Columns.Add("Sexe", typeof(string));
            table.Columns.Add("DateNaiss", typeof(DateTime));
            table.Columns.Add("LieuNaiss", typeof(string));
            table.Columns.Add("CNI", typeof(string));
            table.Columns.Add("NomTuteur", typeof(string));
            table.Columns.Add("PrenomTuteur", typeof(string));
            table.Columns.Add("AdresseTuteur", typeof(string));
            table.Columns.Add("TelTuteur", typeof(string));
            var items = _db.VEleveTuteurRPT.Where(a =>a.Id ==id).ToList();
            foreach (var e in items)
            {
                table.Rows.Add(e.Matricule, e.Nom, e.Prenom, e.Sexe, e.DateNaiss, e.LieuNaiss,
                    e.CNI, e.NomTuteur, e.PrenomTuteur, e.AdresseTuteur, e.TelTuteur);
            }

            return table;
        }

        public ActionResult ReportEleveTuteur(int id)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {
                rpt.Load(Server.MapPath("~/Report/rptEleveTuteurs.rpt"));
                rpt.SetDataSource(GetTableEleveTuteur(id));
                Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.AppendHeader("Content-Disposition", "inline");
                return File(stream, "application/pdf");
            }
            finally
            {
                rpt.Dispose();
                rpt.Close();
            }
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
