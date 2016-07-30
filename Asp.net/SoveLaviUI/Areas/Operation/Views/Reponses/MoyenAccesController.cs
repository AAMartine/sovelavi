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
    public class MoyenAccesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Operation/MoyenAcces
        public ActionResult Index()
        {
            return View(db.tbl_MOYEN_ACCES.ToList());
        }

        // GET: Operation/MoyenAcces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MOYEN_ACCES tbl_MOYEN_ACCES = db.tbl_MOYEN_ACCES.Find(id);
            if (tbl_MOYEN_ACCES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MOYEN_ACCES);
        }

        // GET: Operation/MoyenAcces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operation/MoyenAcces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,moyen")] tbl_MOYEN_ACCES tbl_MOYEN_ACCES)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tbl_MOYEN_ACCES.Add(tbl_MOYEN_ACCES);
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


            return View(tbl_MOYEN_ACCES);
        }

        // GET: Operation/MoyenAcces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MOYEN_ACCES tbl_MOYEN_ACCES = db.tbl_MOYEN_ACCES.Find(id);
            if (tbl_MOYEN_ACCES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MOYEN_ACCES);
        }

        // POST: Operation/MoyenAcces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,moyen")] tbl_MOYEN_ACCES tbl_MOYEN_ACCES)
        {
            if (ModelState.IsValid)
                            {
                try
                {
                    db.Entry(tbl_MOYEN_ACCES).State = EntityState.Modified;
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
            return View(tbl_MOYEN_ACCES);
        }

        // GET: Operation/MoyenAcces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MOYEN_ACCES tbl_MOYEN_ACCES = db.tbl_MOYEN_ACCES.Find(id);
            if (tbl_MOYEN_ACCES == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MOYEN_ACCES);
        }

        // POST: Operation/MoyenAcces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_MOYEN_ACCES tbl_MOYEN_ACCES = db.tbl_MOYEN_ACCES.Find(id);
                db.tbl_MOYEN_ACCES.Remove(tbl_MOYEN_ACCES);
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
