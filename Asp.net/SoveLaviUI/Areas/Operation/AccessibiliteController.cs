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
    public class AccessibiliteController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Operation/Accessibilite
        public ActionResult Index()
        {
            var tbl_ACCESSIBILITE = db.tbl_ACCESSIBILITE.Include(t => t.tbl_COLLECTIVITE_TERRITORIALE).Include(t => t.tbl_MOYEN_ACCES).Include(t => t.tbl_NIVEAU_ACCES);
            return View(tbl_ACCESSIBILITE.ToList());
        }

        // GET: Operation/Accessibilite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ACCESSIBILITE tbl_ACCESSIBILITE = db.tbl_ACCESSIBILITE.Find(id);
            if (tbl_ACCESSIBILITE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ACCESSIBILITE);
        }

        // GET: Operation/Accessibilite/Create
        public ActionResult Create()
        {
            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id");
            ViewBag.moyenId = new SelectList(db.tbl_MOYEN_ACCES, "id", "moyen");
            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_ACCES, "id", "nom");
            return View();
        }

        // POST: Operation/Accessibilite/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,niveauId,moyenId,collectiviteId,StartDate")] tbl_ACCESSIBILITE tbl_ACCESSIBILITE)
        {
            if (ModelState.IsValid)
               try 
                   {
                    db.tbl_ACCESSIBILITE.Add(tbl_ACCESSIBILITE);
                    db.SaveChanges();
                    TempData["Msg"] = "Accessibilité mise à jour";
                    return RedirectToAction("Index");
                    }
                catch (Exception e1)
                {
                    TempData["Msg"] = "Mise à jour echouée: " + e1.Message;
                    return RedirectToAction("Index");
                }

            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_ACCESSIBILITE.collectiviteId);
            ViewBag.moyenId = new SelectList(db.tbl_MOYEN_ACCES, "id", "moyen", tbl_ACCESSIBILITE.moyenId);
            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_ACCES, "id", "nom", tbl_ACCESSIBILITE.niveauId);
            return View(tbl_ACCESSIBILITE);
        }

        // GET: Operation/Accessibilite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ACCESSIBILITE tbl_ACCESSIBILITE = db.tbl_ACCESSIBILITE.Find(id);
            if (tbl_ACCESSIBILITE == null)
            {
                return HttpNotFound();
            }
            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_ACCESSIBILITE.collectiviteId);
            ViewBag.moyenId = new SelectList(db.tbl_MOYEN_ACCES, "id", "moyen", tbl_ACCESSIBILITE.moyenId);
            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_ACCES, "id", "nom", tbl_ACCESSIBILITE.niveauId);
            return View(tbl_ACCESSIBILITE);
        }

        // POST: Operation/Accessibilite/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,niveauId,moyenId,collectiviteId,StartDate")] tbl_ACCESSIBILITE tbl_ACCESSIBILITE)
        {
            if (ModelState.IsValid)
                try
                    {
                     db.Entry(tbl_ACCESSIBILITE).State = EntityState.Modified;
                     db.SaveChanges();
                    TempData["Msg"] = "Accessibilité mise à jour";
                    return RedirectToAction("Index");
                     }
                catch (Exception e1)
                {
                    TempData["Msg"] = "Mise à jour echouée: " + e1.Message;
                    return RedirectToAction("Index");
                }

            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_ACCESSIBILITE.collectiviteId);
            ViewBag.moyenId = new SelectList(db.tbl_MOYEN_ACCES, "id", "moyen", tbl_ACCESSIBILITE.moyenId);
            ViewBag.niveauId = new SelectList(db.tbl_NIVEAU_ACCES, "id", "nom", tbl_ACCESSIBILITE.niveauId);
            return View(tbl_ACCESSIBILITE);
        }

        // GET: Operation/Accessibilite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ACCESSIBILITE tbl_ACCESSIBILITE = db.tbl_ACCESSIBILITE.Find(id);
            if (tbl_ACCESSIBILITE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ACCESSIBILITE);
        }

        // POST: Operation/Accessibilite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ACCESSIBILITE tbl_ACCESSIBILITE = db.tbl_ACCESSIBILITE.Find(id);
            try
            {
                db.tbl_ACCESSIBILITE.Remove(tbl_ACCESSIBILITE);
                db.SaveChanges();
                TempData["Msg"] = "Suppression réussie";
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
