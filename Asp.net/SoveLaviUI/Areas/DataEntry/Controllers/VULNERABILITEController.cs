using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace SoveLaviUI.Areas.DataEntry.Controllers
{
    public class VULNERABILITEController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        private VulnerabilteBs ObjBs;
        public VULNERABILITEController()
        {
            ObjBs = new VulnerabilteBs();
        }

        // GET: DataEntry/VULNERABILITE
        public ActionResult Index()
        {

            var tbl_VULNERABILITE = ObjBs.GetALL();
            return View(tbl_VULNERABILITE);
        }

        //public ActionResult Index()
        //{
        //    var tbl_VULNERABILITE = db.tbl_VULNERABILITE.Include(t => t.tbl_COLLECTIVITE_TERRITORIALE).Include(t => t.tbl_MENACE).Include(t => t.tbl_VULNERABILITE_NIVEAU);
        //    return View(tbl_VULNERABILITE.ToList());
        //}

        // GET: DataEntry/VULNERABILITE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_VULNERABILITE tbl_VULNERABILITE = db.tbl_VULNERABILITE.Find(id);
            if (tbl_VULNERABILITE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_VULNERABILITE);
        }

        // GET: DataEntry/VULNERABILITE/Create
        public ActionResult Create()
        {
            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id");
            ViewBag.menaceId = new SelectList(db.tbl_MENACE, "id", "nom");
            ViewBag.niveauVulnerabiliteID = new SelectList(db.tbl_VULNERABILITE_NIVEAU, "id", "nom");
            return View();
        }

        // POST: DataEntry/VULNERABILITE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,collectiviteId,menaceId,niveauVulnerabiliteID,startDate")] tbl_VULNERABILITE tbl_VULNERABILITE)
        {
            if (ModelState.IsValid)
            {
                tbl_VULNERABILITE.collectiviteId = 1;
                db.tbl_VULNERABILITE.Add(tbl_VULNERABILITE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_VULNERABILITE.collectiviteId);
            ViewBag.menaceId = new SelectList(db.tbl_MENACE, "id", "nom", tbl_VULNERABILITE.menaceId);
            ViewBag.niveauVulnerabiliteID = new SelectList(db.tbl_VULNERABILITE_NIVEAU, "id", "nom", tbl_VULNERABILITE.niveauVulnerabiliteID);
            return View(tbl_VULNERABILITE);
        }

        // GET: DataEntry/VULNERABILITE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_VULNERABILITE tbl_VULNERABILITE = db.tbl_VULNERABILITE.Find(id);
            if (tbl_VULNERABILITE == null)
            {
                return HttpNotFound();
            }
            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_VULNERABILITE.collectiviteId);
            ViewBag.menaceId = new SelectList(db.tbl_MENACE, "id", "nom", tbl_VULNERABILITE.menaceId);
            ViewBag.niveauVulnerabiliteID = new SelectList(db.tbl_VULNERABILITE_NIVEAU, "id", "nom", tbl_VULNERABILITE.niveauVulnerabiliteID);
            return View(tbl_VULNERABILITE);
        }

        // POST: DataEntry/VULNERABILITE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,collectiviteId,menaceId,niveauVulnerabiliteID,startDate")] tbl_VULNERABILITE tbl_VULNERABILITE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_VULNERABILITE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_VULNERABILITE.collectiviteId);
            ViewBag.menaceId = new SelectList(db.tbl_MENACE, "id", "nom", tbl_VULNERABILITE.menaceId);
            ViewBag.niveauVulnerabiliteID = new SelectList(db.tbl_VULNERABILITE_NIVEAU, "id", "nom", tbl_VULNERABILITE.niveauVulnerabiliteID);
            return View(tbl_VULNERABILITE);
        }

        // GET: DataEntry/VULNERABILITE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_VULNERABILITE tbl_VULNERABILITE = db.tbl_VULNERABILITE.Find(id);
            if (tbl_VULNERABILITE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_VULNERABILITE);
        }

        // POST: DataEntry/VULNERABILITE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_VULNERABILITE tbl_VULNERABILITE = db.tbl_VULNERABILITE.Find(id);
            db.tbl_VULNERABILITE.Remove(tbl_VULNERABILITE);
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
