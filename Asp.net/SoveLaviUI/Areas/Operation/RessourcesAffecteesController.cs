using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace SoveLaviUI.Areas.Operation
{
    public class RessourcesAffecteesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Operation/RessourcesAffectees
        public ActionResult Index()
        {
            var tbl_RESSOURCES_AFFECTEES = db.tbl_RESSOURCES_AFFECTEES.Include(t => t.tbl_EVENEMENT_TYPE_DEGAT).Include(t => t.tbl_REPONSE).Include(t => t.tbl_RESSOURCE);
            return View(tbl_RESSOURCES_AFFECTEES.ToList());
        }

        // GET: Operation/RessourcesAffectees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESSOURCES_AFFECTEES tbl_RESSOURCES_AFFECTEES = db.tbl_RESSOURCES_AFFECTEES.Find(id);
            if (tbl_RESSOURCES_AFFECTEES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RESSOURCES_AFFECTEES);
        }

        // GET: Operation/RessourcesAffectees/Create
        public ActionResult Create()
        {
            ViewBag.degatID = new SelectList(db.tbl_EVENEMENT_TYPE_DEGAT, "id", "id");
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description");
            ViewBag.sourceId = new SelectList(db.tbl_RESSOURCE, "id", "nom");
            return View();
        }

        // POST: Operation/RessourcesAffectees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,qteAffectee,reponseId,sourceId,degatID")] tbl_RESSOURCES_AFFECTEES tbl_RESSOURCES_AFFECTEES)
        {
            if (ModelState.IsValid)
            {
                db.tbl_RESSOURCES_AFFECTEES.Add(tbl_RESSOURCES_AFFECTEES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degatID = new SelectList(db.tbl_EVENEMENT_TYPE_DEGAT, "id", "id", tbl_RESSOURCES_AFFECTEES.degatID);
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description", tbl_RESSOURCES_AFFECTEES.reponseId);
            ViewBag.sourceId = new SelectList(db.tbl_RESSOURCE, "id", "nom", tbl_RESSOURCES_AFFECTEES.sourceId);
            return View(tbl_RESSOURCES_AFFECTEES);
        }

        // GET: Operation/RessourcesAffectees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESSOURCES_AFFECTEES tbl_RESSOURCES_AFFECTEES = db.tbl_RESSOURCES_AFFECTEES.Find(id);
            if (tbl_RESSOURCES_AFFECTEES == null)
            {
                return HttpNotFound();
            }
            ViewBag.degatID = new SelectList(db.tbl_EVENEMENT_TYPE_DEGAT, "id", "id", tbl_RESSOURCES_AFFECTEES.degatID);
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description", tbl_RESSOURCES_AFFECTEES.reponseId);
            ViewBag.sourceId = new SelectList(db.tbl_RESSOURCE, "id", "nom", tbl_RESSOURCES_AFFECTEES.sourceId);
            return View(tbl_RESSOURCES_AFFECTEES);
        }

        // POST: Operation/RessourcesAffectees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,qteAffectee,reponseId,sourceId,degatID")] tbl_RESSOURCES_AFFECTEES tbl_RESSOURCES_AFFECTEES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_RESSOURCES_AFFECTEES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.degatID = new SelectList(db.tbl_EVENEMENT_TYPE_DEGAT, "id", "id", tbl_RESSOURCES_AFFECTEES.degatID);
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description", tbl_RESSOURCES_AFFECTEES.reponseId);
            ViewBag.sourceId = new SelectList(db.tbl_RESSOURCE, "id", "nom", tbl_RESSOURCES_AFFECTEES.sourceId);
            return View(tbl_RESSOURCES_AFFECTEES);
        }

        // GET: Operation/RessourcesAffectees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESSOURCES_AFFECTEES tbl_RESSOURCES_AFFECTEES = db.tbl_RESSOURCES_AFFECTEES.Find(id);
            if (tbl_RESSOURCES_AFFECTEES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RESSOURCES_AFFECTEES);
        }

        // POST: Operation/RessourcesAffectees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_RESSOURCES_AFFECTEES tbl_RESSOURCES_AFFECTEES = db.tbl_RESSOURCES_AFFECTEES.Find(id);
            db.tbl_RESSOURCES_AFFECTEES.Remove(tbl_RESSOURCES_AFFECTEES);
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
