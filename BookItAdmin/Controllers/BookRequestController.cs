using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookItAdmin.Controllers
{
    public partial class BookRequestController : Controller
    {
        // GET: BookRequest
        public virtual ActionResult Index()
        {
            return View();
        }

        // GET: BookRequest/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookRequest/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: BookRequest/Create
        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
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

        // GET: BookRequest/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookRequest/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
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

        // GET: BookRequest/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookRequest/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
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
