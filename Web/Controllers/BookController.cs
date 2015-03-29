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
        public readonly IBookRequestR _bookRequestR;
        public readonly IBookLoanR _bookLoanR;

        public BookController(ICopyR aCopyR, IBookRequestR aBookRequestR, IBookLoanR aBookLoanR)
        {
            if (aCopyR == null)
            {
                throw new ArgumentNullException("aStudentR");
            }
            if (aBookRequestR == null)
            {
                throw new ArgumentNullException("aBookRequestR");
                
            }
            if (aBookLoanR == null)
            {
                throw new ArgumentNullException("aBookLoanR");
            }

            _copyR = aCopyR;
            _bookRequestR = aBookRequestR;
            _bookLoanR = aBookLoanR;
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

        [HttpPost]
        public ActionResult CreateRequest(FormCollection collection)
        {
            // create BookRequest based on teacher id in Session, and StudentID

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
