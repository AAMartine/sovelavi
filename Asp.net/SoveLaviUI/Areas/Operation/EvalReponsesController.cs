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
    public class EvalReponsesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Operation/EvalReponses
        public ActionResult Index()
        {
            var tbl_EVAL_REPONSE = db.tbl_EVAL_REPONSE.Include(t => t.tbl_NIVEAU_RESOLUTION).Include(t => t.tbl_REPONSE);
            return View(tbl_EVAL_REPONSE.ToList());
        }

        // GET: Operation/EvalReponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EVAL_REPONSE tbl_EVAL_REPONSE = db.tbl_EVAL_REPONSE.Find(id);
            if (tbl_EVAL_REPONSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_EVAL_REPONSE);
        }

        // GET: Operation/EvalReponses/Create
        public ActionResult Create()
        {
            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_RESOLUTION, "id", "nomNiveau");
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description");
            return View();
        }

        // POST: Operation/EvalReponses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,reponseId,niveauId,commentaires")] tbl_EVAL_REPONSE tbl_EVAL_REPONSE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_EVAL_REPONSE.Add(tbl_EVAL_REPONSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_RESOLUTION, "id", "nomNiveau", tbl_EVAL_REPONSE.niveauId);
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description", tbl_EVAL_REPONSE.reponseId);
            return View(tbl_EVAL_REPONSE);
        }

        // GET: Operation/EvalReponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EVAL_REPONSE tbl_EVAL_REPONSE = db.tbl_EVAL_REPONSE.Find(id);
            if (tbl_EVAL_REPONSE == null)
            {
                return HttpNotFound();
            }
            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_RESOLUTION, "id", "nomNiveau", tbl_EVAL_REPONSE.niveauId);
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description", tbl_EVAL_REPONSE.reponseId);
            return View(tbl_EVAL_REPONSE);
        }

        // POST: Operation/EvalReponses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,reponseId,niveauId,commentaires")] tbl_EVAL_REPONSE tbl_EVAL_REPONSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_EVAL_REPONSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_RESOLUTION, "id", "nomNiveau", tbl_EVAL_REPONSE.niveauId);
            ViewBag.reponseId = new SelectList(db.tbl_REPONSE, "id", "description", tbl_EVAL_REPONSE.reponseId);
            return View(tbl_EVAL_REPONSE);
        }

        // GET: Operation/EvalReponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EVAL_REPONSE tbl_EVAL_REPONSE = db.tbl_EVAL_REPONSE.Find(id);
            if (tbl_EVAL_REPONSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_EVAL_REPONSE);
        }

        // POST: Operation/EvalReponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_EVAL_REPONSE tbl_EVAL_REPONSE = db.tbl_EVAL_REPONSE.Find(id);
            db.tbl_EVAL_REPONSE.Remove(tbl_EVAL_REPONSE);
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
