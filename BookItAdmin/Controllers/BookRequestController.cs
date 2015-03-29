using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class BookRequestController : Controller
    {
        IBookRequestR _BookRequestR;
        public BookRequestController(IBookRequestR BookRequestR)
        {
            if (BookRequestR == null)
                throw new NullReferenceException("BookRequest repo is null");

            _BookRequestR = BookRequestR;
        }
        public virtual ActionResult Index()
        {
            var BookRequests = _BookRequestR.GetAll();
            return View(BookRequests);
        }

        public virtual ActionResult Details(Guid id)
        {
            var BookRequest = _BookRequestR.Get(id);
            LoadStuff(ref BookRequest);
            return View(BookRequest);
        }

        private void LoadStuff(ref BookRequest bookRequest)
        {

        }

        public virtual ActionResult Create()
        {
            var BookRequest = new BookRequest();
            return View(BookRequest);
        }

        [HttpPost]
        public virtual ActionResult Create(BookRequest BookRequest)
        {
            try
            {
                var id = _BookRequestR.InsertAndReturnPrimaryKey(BookRequest);

                return RedirectToAction(MVC.BookRequest.Details(id));
            }
            catch
            {
                return View(BookRequest);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var BookRequest = _BookRequestR.Get(id);
            return View(BookRequest);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, BookRequest BookRequest)
        {
            try
            {
                _BookRequestR.Update(BookRequest);

                return RedirectToAction(MVC.BookRequest.Details(id));
            }
            catch
            {
                return View(BookRequest);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var BookRequest = _BookRequestR.Get(id);
            return View(BookRequest);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _BookRequestR.Delete(id);

                return RedirectToAction(MVC.BookRequest.Index());
            }
            catch
            {
                return View(id);
            }
        }
    }
}
