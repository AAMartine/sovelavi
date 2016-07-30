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
    public class INSTITUTIONController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        private InstitutionBs ObjBs;
        public INSTITUTIONController()
        {
            ObjBs = new InstitutionBs();
        }

        // GET: DataEntry/INSTITUTION
        public ActionResult Index()
        {

            var tbl_INSTITUTION = ObjBs.GetALL();
            return View(tbl_INSTITUTION);
        }
        //public ActionResult Index()
        //{
        //    var tbl_INSTITUTION = db.tbl_INSTITUTION.Include(t => t.tbl_CONTACT).Include(t => t.tbl_TYPE_INSTITUTION);
        //    return View(tbl_INSTITUTION.ToList());
        //}

        // GET: DataEntry/INSTITUTION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_INSTITUTION tbl_INSTITUTION = db.tbl_INSTITUTION.Find(id);
            if (tbl_INSTITUTION == null)
            {
                return HttpNotFound();
            }
            return View(tbl_INSTITUTION);
        }

        // GET: DataEntry/INSTITUTION/Create
        public ActionResult Create()
        {
            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email");
            ViewBag.type = new SelectList(db.tbl_TYPE_INSTITUTION, "id", "nom");
            return View();
        }

        // POST: DataEntry/INSTITUTION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,type,contactId")] tbl_INSTITUTION tbl_INSTITUTION)
        {
            if (ModelState.IsValid)
            {
                db.tbl_INSTITUTION.Add(tbl_INSTITUTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email", tbl_INSTITUTION.contactId);
            ViewBag.type = new SelectList(db.tbl_TYPE_INSTITUTION, "id", "nom", tbl_INSTITUTION.type);
            return View(tbl_INSTITUTION);
        }

        // GET: DataEntry/INSTITUTION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_INSTITUTION tbl_INSTITUTION = db.tbl_INSTITUTION.Find(id);
            if (tbl_INSTITUTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email", tbl_INSTITUTION.contactId);
            ViewBag.type = new SelectList(db.tbl_TYPE_INSTITUTION, "id", "nom", tbl_INSTITUTION.type);
            return View(tbl_INSTITUTION);
        }

        // POST: DataEntry/INSTITUTION/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,type,contactId")] tbl_INSTITUTION tbl_INSTITUTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_INSTITUTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email", tbl_INSTITUTION.contactId);
            ViewBag.type = new SelectList(db.tbl_TYPE_INSTITUTION, "id", "nom", tbl_INSTITUTION.type);
            return View(tbl_INSTITUTION);
        }

        // GET: DataEntry/INSTITUTION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_INSTITUTION tbl_INSTITUTION = db.tbl_INSTITUTION.Find(id);
            if (tbl_INSTITUTION == null)
            {
                return HttpNotFound();
            }
            return View(tbl_INSTITUTION);
        }

        // POST: DataEntry/INSTITUTION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_INSTITUTION tbl_INSTITUTION = db.tbl_INSTITUTION.Find(id);
            db.tbl_INSTITUTION.Remove(tbl_INSTITUTION);
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
