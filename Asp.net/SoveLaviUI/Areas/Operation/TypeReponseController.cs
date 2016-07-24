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
    public class TypeReponseController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        //GET: Operation/TypeReponse
        public ActionResult Index()
        {
            return View(db.tbl_TYPE_REPONSE.ToList());
        }

        // GET: Operation/TypeReponse/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_TYPE_REPONSE tbl_TYPE_REPONSE = db.tbl_TYPE_REPONSE.Find(id);
        //    if (tbl_TYPE_REPONSE == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_TYPE_REPONSE);
        //}

        // GET: Operation/TypeReponse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operation/TypeReponse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom")] tbl_TYPE_REPONSE tbl_TYPE_REPONSE)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tbl_TYPE_REPONSE.Add(tbl_TYPE_REPONSE);
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
            return View(tbl_TYPE_REPONSE);
        }

        // GET: Operation/TypeReponse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TYPE_REPONSE tbl_TYPE_REPONSE = db.tbl_TYPE_REPONSE.Find(id);
            if (tbl_TYPE_REPONSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TYPE_REPONSE);
        }

        // POST: Operation/TypeReponse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom")] tbl_TYPE_REPONSE tbl_TYPE_REPONSE)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_TYPE_REPONSE).State = EntityState.Modified;
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
            return View(tbl_TYPE_REPONSE);
        }

        // GET: Operation/TypeReponse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
                tbl_TYPE_REPONSE tbl_TYPE_REPONSE = db.tbl_TYPE_REPONSE.Find(id);
                if (tbl_TYPE_REPONSE == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_TYPE_REPONSE);
            
        }

        // POST: Operation/TypeReponse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_TYPE_REPONSE tbl_TYPE_REPONSE = db.tbl_TYPE_REPONSE.Find(id);
                
            try
            {
                db.tbl_TYPE_REPONSE.Remove(tbl_TYPE_REPONSE);
                db.SaveChanges();
                TempData["Msg"] = "Supprimé avec succès";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
                {
                TempData["Msg"] = "Suppression echouée: " +e1.Message;
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
