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
    public class COUController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        private COUBs ObjBs;
        public COUController()
        {
            ObjBs = new COUBs();
        }

        // GET: DataEntry/COU
        public ActionResult Index()
        {

            var tbl_COU = ObjBs.GetALL();
            return View(tbl_COU);
        }

        //public ActionResult Index()
        //{
        //    var tbl_COU = db.tbl_COU.Include(t => t.tbl_COLLECTIVITE_TERRITORIALE).Include(t => t.tbl_USER).Include(t => t.tbl_USER1);
        //    return View(tbl_COU.ToList());
        //}

        // GET: DataEntry/COU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_COU tbl_COU = db.tbl_COU.Find(id);
            if (tbl_COU == null)
            {
                return HttpNotFound();
            }
            return View(tbl_COU);
        }

        // GET: DataEntry/COU/Create
        public ActionResult Create()
        {
            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id");
            ViewBag.activatedBy = new SelectList(db.tbl_USER, "id", "nom");
            ViewBag.closeBy = new SelectList(db.tbl_USER, "id", "nom");
            return View();
        }

        // POST: DataEntry/COU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,isActive,latitude,longitude,lastCloseDate,activationMotif,lastActiveDate,activatedBy,closeBy,collectiviteId")] tbl_COU tbl_COU)
        {
            if (ModelState.IsValid)
            {
                db.tbl_COU.Add(tbl_COU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_COU.collectiviteId);
            ViewBag.activatedBy = new SelectList(db.tbl_USER, "id", "nom", tbl_COU.activatedBy);
            ViewBag.closeBy = new SelectList(db.tbl_USER, "id", "nom", tbl_COU.closeBy);
            return View(tbl_COU);
        }

        // GET: DataEntry/COU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_COU tbl_COU = db.tbl_COU.Find(id);
            if (tbl_COU == null)
            {
                return HttpNotFound();
            }
            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_COU.collectiviteId);
            ViewBag.activatedBy = new SelectList(db.tbl_USER, "id", "nom", tbl_COU.activatedBy);
            ViewBag.closeBy = new SelectList(db.tbl_USER, "id", "nom", tbl_COU.closeBy);
            return View(tbl_COU);
        }

        // POST: DataEntry/COU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,isActive,latitude,longitude,lastCloseDate,activationMotif,lastActiveDate,activatedBy,closeBy,collectiviteId")] tbl_COU tbl_COU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_COU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.collectiviteId = new SelectList(db.tbl_COLLECTIVITE_TERRITORIALE, "id", "id", tbl_COU.collectiviteId);
            ViewBag.activatedBy = new SelectList(db.tbl_USER, "id", "nom", tbl_COU.activatedBy);
            ViewBag.closeBy = new SelectList(db.tbl_USER, "id", "nom", tbl_COU.closeBy);
            return View(tbl_COU);
        }

        // GET: DataEntry/COU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_COU tbl_COU = db.tbl_COU.Find(id);
            if (tbl_COU == null)
            {
                return HttpNotFound();
            }
            return View(tbl_COU);
        }

        // POST: DataEntry/COU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_COU tbl_COU = db.tbl_COU.Find(id);
            db.tbl_COU.Remove(tbl_COU);
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
