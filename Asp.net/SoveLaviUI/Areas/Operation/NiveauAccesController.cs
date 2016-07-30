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
    public class NiveauAccesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Operation/NiveauAcces
        public ActionResult Index()
        {
            return View(db.tbl_NIVEAU_ACCES.ToList());
        }

        // GET: Operation/NiveauAcces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NIVEAU_ACCES tbl_NIVEAU_ACCES = db.tbl_NIVEAU_ACCES.Find(id);
            if (tbl_NIVEAU_ACCES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NIVEAU_ACCES);
        }

        // GET: Operation/NiveauAcces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operation/NiveauAcces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom")] tbl_NIVEAU_ACCES tbl_NIVEAU_ACCES)
        {
            if (ModelState.IsValid)
            {
                db.tbl_NIVEAU_ACCES.Add(tbl_NIVEAU_ACCES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_NIVEAU_ACCES);
        }

        // GET: Operation/NiveauAcces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NIVEAU_ACCES tbl_NIVEAU_ACCES = db.tbl_NIVEAU_ACCES.Find(id);
            if (tbl_NIVEAU_ACCES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NIVEAU_ACCES);
        }

        // POST: Operation/NiveauAcces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom")] tbl_NIVEAU_ACCES tbl_NIVEAU_ACCES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_NIVEAU_ACCES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_NIVEAU_ACCES);
        }

        // GET: Operation/NiveauAcces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NIVEAU_ACCES tbl_NIVEAU_ACCES = db.tbl_NIVEAU_ACCES.Find(id);
            if (tbl_NIVEAU_ACCES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NIVEAU_ACCES);
        }

        // POST: Operation/NiveauAcces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_NIVEAU_ACCES tbl_NIVEAU_ACCES = db.tbl_NIVEAU_ACCES.Find(id);
            db.tbl_NIVEAU_ACCES.Remove(tbl_NIVEAU_ACCES);
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
