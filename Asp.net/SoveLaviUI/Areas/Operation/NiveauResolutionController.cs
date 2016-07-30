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
    public class NiveauResolutionController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Operation/NiveauResolution
        public ActionResult Index()
        {
            return View(db.tbl_NIVEAU_RESOLUTION.ToList());
        }

        // GET: Operation/NiveauResolution/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NIVEAU_RESOLUTION tbl_NIVEAU_RESOLUTION = db.tbl_NIVEAU_RESOLUTION.Find(id);
            if (tbl_NIVEAU_RESOLUTION == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NIVEAU_RESOLUTION);
        }

        // GET: Operation/NiveauResolution/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operation/NiveauResolution/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nomNiveau,description")] tbl_NIVEAU_RESOLUTION tbl_NIVEAU_RESOLUTION)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     db.tbl_NIVEAU_RESOLUTION.Add(tbl_NIVEAU_RESOLUTION);
                     db.SaveChanges();
                     TempData["Msg"] = "Créé avec succès";
                     return RedirectToAction("Index");
                }
                catch (Exception e1)
                {
                    TempData["Msg"] = "Création echouée: " + e1.Message;
                    return RedirectToAction("Index");
                }
            }

            return View(tbl_NIVEAU_RESOLUTION);
        }

        // GET: Operation/NiveauResolution/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NIVEAU_RESOLUTION tbl_NIVEAU_RESOLUTION = db.tbl_NIVEAU_RESOLUTION.Find(id);
            if (tbl_NIVEAU_RESOLUTION == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NIVEAU_RESOLUTION);
        }

        // POST: Operation/NiveauResolution/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nomNiveau,description")] tbl_NIVEAU_RESOLUTION tbl_NIVEAU_RESOLUTION)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_NIVEAU_RESOLUTION).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "Modifié avec succès";
                    return RedirectToAction("Index");
                }
                catch (Exception e1)
                {
                    TempData["Msg"] = "Modification echouée: " + e1.Message;
                    return RedirectToAction("Index");
                }

            }
            return View(tbl_NIVEAU_RESOLUTION);
        }

        // GET: Operation/NiveauResolution/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NIVEAU_RESOLUTION tbl_NIVEAU_RESOLUTION = db.tbl_NIVEAU_RESOLUTION.Find(id);
            if (tbl_NIVEAU_RESOLUTION == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NIVEAU_RESOLUTION);
        }

        // POST: Operation/NiveauResolution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_NIVEAU_RESOLUTION tbl_NIVEAU_RESOLUTION = db.tbl_NIVEAU_RESOLUTION.Find(id);
                db.tbl_NIVEAU_RESOLUTION.Remove(tbl_NIVEAU_RESOLUTION);
                db.SaveChanges();
                TempData["Msg"] = "Supprimé avec succès";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Suppression echouée: " + e1.Message;
                return RedirectToAction("Index");
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
