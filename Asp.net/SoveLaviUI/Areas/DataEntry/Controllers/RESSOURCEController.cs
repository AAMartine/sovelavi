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
    public class RESSOURCEController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        private RessourceBs ObjBs;
        public RESSOURCEController()
        {
            ObjBs = new RessourceBs();
        }

        // GET: DataEntry/RESSOURCE
        public ActionResult Index()
        {

            var tbl_RESSOURCE = ObjBs.GetALL();
            return View(tbl_RESSOURCE);
        }

        //public ActionResult Index()
        //{
        //    var tbl_RESSOURCE = db.tbl_RESSOURCE.Include(t => t.tbl_COLLECTIVITE_TERRITORIALE).Include(t => t.tbl_RESSOURCE_TYPE);
        //    return View(tbl_RESSOURCE.ToList());
        //}

        // GET: DataEntry/RESSOURCE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESSOURCE tbl_RESSOURCE = db.tbl_RESSOURCE.Find(id);
            if (tbl_RESSOURCE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RESSOURCE);
        }

        // GET: DataEntry/RESSOURCE/Create
        public ActionResult Create()
        {
            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id");
            ViewBag.typeRessourceId = new SelectList(db.tbl_RESSOURCE_TYPE, "id", "nom");
            return View();
        }

        // POST: DataEntry/RESSOURCE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,typeRessourceId,qteDisponible,qteNecessaire,collectiviteId")] tbl_RESSOURCE tbl_RESSOURCE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_RESSOURCE.Add(tbl_RESSOURCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_RESSOURCE.collectiviteId);
            ViewBag.typeRessourceId = new SelectList(db.tbl_RESSOURCE_TYPE, "id", "nom", tbl_RESSOURCE.typeRessourceId);
            return View(tbl_RESSOURCE);
        }

        // GET: DataEntry/RESSOURCE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESSOURCE tbl_RESSOURCE = db.tbl_RESSOURCE.Find(id);
            if (tbl_RESSOURCE == null)
            {
                return HttpNotFound();
            }
            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_RESSOURCE.collectiviteId);
            ViewBag.typeRessourceId = new SelectList(db.tbl_RESSOURCE_TYPE, "id", "nom", tbl_RESSOURCE.typeRessourceId);
            return View(tbl_RESSOURCE);
        }

        // POST: DataEntry/RESSOURCE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,typeRessourceId,qteDisponible,qteNecessaire,collectiviteId")] tbl_RESSOURCE tbl_RESSOURCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_RESSOURCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_RESSOURCE.collectiviteId);
            ViewBag.typeRessourceId = new SelectList(db.tbl_RESSOURCE_TYPE, "id", "nom", tbl_RESSOURCE.typeRessourceId);
            return View(tbl_RESSOURCE);
        }

        // GET: DataEntry/RESSOURCE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESSOURCE tbl_RESSOURCE = db.tbl_RESSOURCE.Find(id);
            if (tbl_RESSOURCE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RESSOURCE);
        }

        // POST: DataEntry/RESSOURCE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_RESSOURCE tbl_RESSOURCE = db.tbl_RESSOURCE.Find(id);
            db.tbl_RESSOURCE.Remove(tbl_RESSOURCE);
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
