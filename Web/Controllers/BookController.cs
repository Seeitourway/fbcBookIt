using FbcBookIt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BookController : Controller
    {
        public readonly ICopyR _copyR;
        public BookController(ICopyR aCopyR)
        {
            if (aCopyR == null)
            {
                throw new ArgumentNullException("aStudentR");
            }
            _copyR = aCopyR;
        }

        // GET: Book
        public ActionResult Index(Guid TeacherId)
        {
            // get all students by teacher

            return View();
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
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
    }
}
