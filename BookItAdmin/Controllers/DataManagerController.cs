using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookItAdmin.Controllers
{
    public partial class DataManagerController : Controller
    {
        // GET: DataManager
        public virtual ActionResult Index()
        {
            return View();
        }

        // GET: DataManager/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: DataManager/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: DataManager/Create
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

        // GET: DataManager/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataManager/Edit/5
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

        // GET: DataManager/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataManager/Delete/5
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
