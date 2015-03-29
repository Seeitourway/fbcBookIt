using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class BookLoanController : Controller
    {
        IBookLoanR _bookLoanR;
        public BookLoanController(IBookLoanR bookLoan)
        {
            if (bookLoan == null)
                throw new NullReferenceException("Book loan repo is null");

            _bookLoanR = bookLoan;
        }

        public virtual ActionResult Index()
        {
            var bookLoan = _bookLoanR.GetAll();
            return View(bookLoan);
        }

        public virtual ActionResult Details(Guid id)
        {
            var bookLoan = _bookLoanR.Get(id);
            return View(bookLoan);
        }

        public virtual ActionResult Create(Guid id)
        {
            var bookLoan = new BookLoan();
            bookLoan.BookRequestID = id;
            return View(bookLoan);
        }

        [HttpPost]
        public virtual ActionResult Create(BookLoan bookLoan)
        {
            try
            {
                var id = _bookLoanR.InsertAndReturnPrimaryKey(bookLoan);

                return RedirectToAction(MVC.BookLoan.Details(id));
            }
            catch
            {
                return View(bookLoan);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var bookLoan = _bookLoanR.Get(id);
            return View(bookLoan);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, BookLoan bookLoan)
        {
            try
            {
                _bookLoanR.Update(bookLoan);

                return RedirectToAction(MVC.BookLoan.Details(id));
            }
            catch
            {
                return View(bookLoan);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var bookLoan = _bookLoanR.Get(id);
            return View(bookLoan);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _bookLoanR.Delete(id);

                return RedirectToAction(MVC.BookLoan.Index());
            }
            catch
            {
                return View(id);
            }
        }
    }
}
