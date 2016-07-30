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
    public class MEMBREController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        private MembreBs ObjBs;
        public MEMBREController()
        {
            ObjBs = new MembreBs();
        }

        // GET: DataEntry/MEMBRE
        public ActionResult Index()
        {

            var tbl_MEMBRE = ObjBs.GetALL();
            return View(tbl_MEMBRE);
        }
        //public ActionResult Index()
        //{
        //    var tbl_MEMBRE = db.tbl_MEMBRE.Include(t => t.tbl_CONTACT).Include(t => t.tbl_COU).Include(t => t.tbl_INSTITUTION);
        //    return View(tbl_MEMBRE.ToList());
        //}

        // GET: DataEntry/MEMBRE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MEMBRE tbl_MEMBRE = db.tbl_MEMBRE.Find(id);
            if (tbl_MEMBRE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MEMBRE);
        }

        // GET: DataEntry/MEMBRE/Create
        public ActionResult Create()
        {
            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email");
            ViewBag.couId = new SelectList(db.tbl_COU, "id", "description");
            ViewBag.institutionId = new SelectList(db.tbl_INSTITUTION, "id", "nom");
            return View();
        }

        // POST: DataEntry/MEMBRE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,institutionId,couId,contactId")] tbl_MEMBRE tbl_MEMBRE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_MEMBRE.Add(tbl_MEMBRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email", tbl_MEMBRE.contactId);
            ViewBag.couId = new SelectList(db.tbl_COU, "id", "description", tbl_MEMBRE.couId);
            ViewBag.institutionId = new SelectList(db.tbl_INSTITUTION, "id", "nom", tbl_MEMBRE.institutionId);
            return View(tbl_MEMBRE);
        }

        // GET: DataEntry/MEMBRE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MEMBRE tbl_MEMBRE = db.tbl_MEMBRE.Find(id);
            if (tbl_MEMBRE == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email", tbl_MEMBRE.contactId);
            ViewBag.couId = new SelectList(db.tbl_COU, "id", "description", tbl_MEMBRE.couId);
            ViewBag.institutionId = new SelectList(db.tbl_INSTITUTION, "id", "nom", tbl_MEMBRE.institutionId);
            return View(tbl_MEMBRE);
        }

        // POST: DataEntry/MEMBRE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,institutionId,couId,contactId")] tbl_MEMBRE tbl_MEMBRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_MEMBRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactId = new SelectList(db.tbl_CONTACT, "id", "email", tbl_MEMBRE.contactId);
            ViewBag.couId = new SelectList(db.tbl_COU, "id", "description", tbl_MEMBRE.couId);
            ViewBag.institutionId = new SelectList(db.tbl_INSTITUTION, "id", "nom", tbl_MEMBRE.institutionId);
            return View(tbl_MEMBRE);
        }

        // GET: DataEntry/MEMBRE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MEMBRE tbl_MEMBRE = db.tbl_MEMBRE.Find(id);
            if (tbl_MEMBRE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MEMBRE);
        }

        // POST: DataEntry/MEMBRE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_MEMBRE tbl_MEMBRE = db.tbl_MEMBRE.Find(id);
            db.tbl_MEMBRE.Remove(tbl_MEMBRE);
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
