using FbcBookIt.Entity;
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
        public readonly IStudentTeacherSchoolR _stsR;
        public readonly ITitleR _titleR;
        public readonly IFormatTypeR _formatTypeR;

        public BookController(ICopyR aCopyR, IBookRequestR aBookRequestR,
                                IBookLoanR aBookLoanR,
                                IStudentTeacherSchoolR aSTSR,
                                ITitleR aTitleR,
                                IFormatTypeR aFormatTypeR)
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
            if (aSTSR == null)
            {
                throw new ArgumentNullException("aSTSR");
            }
            if (aTitleR == null)
            {
                throw new ArgumentNullException("aTitleR");
            }
            if (aFormatTypeR == null)
            {
                throw new ArgumentNullException("aFormatTypeR");
            }
            _formatTypeR = aFormatTypeR;
            _titleR = aTitleR;
            _copyR = aCopyR;
            _bookRequestR = aBookRequestR;
            _bookLoanR = aBookLoanR;
            _stsR = aSTSR;
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
            BookRequest brq = new BookRequest();
            StudentTeacherSchool sts = _stsR.GetByActiveAndStudentID(true, Guid.Parse(collection[1].ToString()));
            Title tit = new Title();
            TryUpdateModel<Title>(tit, collection.ToValueProvider());
            tit.Active = true;
            _titleR.Add(tit);
            FormatType ft = _formatTypeR.Get(int.Parse(collection[7].ToString()));
            brq.TitleID = tit.TitleID;
            brq.StudentTeacherSchoolId = sts.ID;
            brq.FormatTypeID = ft.FormatTypeId;
            brq.RequestDate = DateTime.Now;
            brq.RequestStatusId = 1;
            if(TryUpdateModel<BookRequest>(brq, collection.ToValueProvider()))
            {
                _bookRequestR.Add(brq);
            }

            return RedirectToAction("Index", "Teacher", new { TeacherID = sts.TeacherID });
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
