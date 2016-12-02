using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class GimController : Controller
    {
        // GET: Gim
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gim/Create
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

        // GET: Gim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gim/Edit/5
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

        // GET: Gim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gim/Delete/5
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
