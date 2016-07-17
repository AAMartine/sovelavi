using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoveLaviUI.Areas.Operation.Controllers
{
    public class IndexController : Controller
    {
        // GET: Operation/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Operation/Index/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Operation/Index/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operation/Index/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Operation/Index/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Operation/Index/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Operation/Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Operation/Index/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
