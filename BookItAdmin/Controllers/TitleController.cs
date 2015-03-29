using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class TitleController : Controller
    {
        private ITitleR _titleR = null;
        private ICopyR _copyR = null;
        public TitleController(FbcBookIt.Repository.ITitleR titleR, ICopyR copyR)
        {
            if (titleR == null)
                throw new ArgumentNullException("Title repository cannot be null");
            if (copyR == null)
                throw new ArgumentNullException("Copy repository cannot be null");

            _titleR = titleR;
            _copyR = copyR;
        }

        public virtual ActionResult Index()
        {
            var titles = _titleR.GetAll();
            return View(titles);
        }

        public virtual ActionResult Details(Guid id)
        {
            var title = _titleR.Get(id);
            title.Copies = _copyR.GetByActiveAndTitleIDAsList(true, id);
            return View(title);
        }

        public virtual ActionResult Create()
        {
            var title = new Title();
            return View(title);
        }

        [HttpPost]
        public virtual ActionResult Create(Title title)
        {
            try
            {
                var id = _titleR.InsertAndReturnPrimaryKey(title);

                return RedirectToAction(MVC.Title.Index());
            }
            catch
            {
                return View(title);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var title = _titleR.Get(id);
            title.Copies = _copyR.GetByActiveAndTitleIDAsList(true, id);
            return View(title);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, Title title)
        {
            try
            {
                _titleR.Update(title);

                return RedirectToAction(MVC.Title.Index());
            }
            catch
            {
                return View(title);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var title = _titleR.Get(id);
            return View(title);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, bool actuallyRemove)
        {
            try
            {
                if (actuallyRemove)
                    _titleR.Delete(id);
                else
                    _titleR.Remove(id);

                return RedirectToAction(MVC.Title.Index());
            }
            catch
            {
                var title = _titleR.Get(id);
                if (title != null)
                    return View(title);
                else
                    return RedirectToAction(MVC.Title.Index());
            }
        }
    }
}
