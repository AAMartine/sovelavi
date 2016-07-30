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
    public class ReponsesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Operation/Reponses
        public ActionResult Index()
        {
            var tbl_REPONSE = db.tbl_REPONSE.Include(t => t.tbl_TYPE_REPONSE);
            return View(tbl_REPONSE.ToList());
        }

        // GET: Operation/Reponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_REPONSE tbl_REPONSE = db.tbl_REPONSE.Find(id);
            if (tbl_REPONSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_REPONSE);
        }

        // GET: Operation/Reponses/Create
        public ActionResult Create()
        {
            ViewBag.typeId = new SelectList(db.tbl_TYPE_REPONSE, "id", "nom");
            return View();
        }

        // POST: Operation/Reponses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,typeId,heureDecision,heureImpactEffectif,heureImpactEspere,description")] tbl_REPONSE tbl_REPONSE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_REPONSE.Add(tbl_REPONSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeId = new SelectList(db.tbl_TYPE_REPONSE, "id", "nom", tbl_REPONSE.typeId);
            return View(tbl_REPONSE);
        }

        // GET: Operation/Reponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_REPONSE tbl_REPONSE = db.tbl_REPONSE.Find(id);
            if (tbl_REPONSE == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeId = new SelectList(db.tbl_TYPE_REPONSE, "id", "nom", tbl_REPONSE.typeId);
            return View(tbl_REPONSE);
        }

        // POST: Operation/Reponses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,typeId,heureDecision,heureImpactEffectif,heureImpactEspere,description")] tbl_REPONSE tbl_REPONSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_REPONSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeId = new SelectList(db.tbl_TYPE_REPONSE, "id", "nom", tbl_REPONSE.typeId);
            return View(tbl_REPONSE);
        }

        // GET: Operation/Reponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_REPONSE tbl_REPONSE = db.tbl_REPONSE.Find(id);
            if (tbl_REPONSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_REPONSE);
        }

        // POST: Operation/Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_REPONSE tbl_REPONSE = db.tbl_REPONSE.Find(id);
            db.tbl_REPONSE.Remove(tbl_REPONSE);
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
