using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class CopyController : Controller
    {
        private ITitleR _titleR = null;
        private ICopyR _copyR = null;
        private IVolumeR _volumeR = null;
        public CopyController(ITitleR titleR, ICopyR copyR, IVolumeR volumeR)
        {
            if (titleR == null)
                throw new ArgumentNullException("Title repository cannot be null");
            if (copyR == null)
                throw new ArgumentNullException("Copy repository cannot be null");
            if (volumeR == null)
                throw new ArgumentNullException("Volume repository cannot be null");

            _titleR = titleR;
            _copyR = copyR;
            _volumeR = volumeR;
        }

        public virtual ActionResult Index(Guid id)
        {
            var copy = _copyR.Get(id);
            copy.Volumes = _volumeR.GetByCopyIDAsList(id);

            return View(copy);
        }

        private void LoadParentStuff(Guid titleId)
        {
            var title = _titleR.Get(titleId);
            ViewBag.TitleName = title.Name;
            ViewBag.TitleId = title.TitleID;
        }

        public virtual ActionResult Details(Guid id)
        {
            var copy = _copyR.Get(id);
            LoadParentStuff(copy.TitleID);

            return View(copy);
        }

        public virtual ActionResult Create(Guid titleId)
        {
            var copy = new Copy();
            copy.TitleID = titleId;
            LoadParentStuff(titleId);

            return View(copy);
        }

        [HttpPost]
        public virtual ActionResult Create(Copy copy)
        {
            try
            {
                var id = _copyR.InsertAndReturnPrimaryKey(copy);

                return RedirectToAction(MVC.Copy.Index());
            }
            catch
            {
                return View(copy);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var copy = _copyR.Get(id);
            copy.Volumes = _volumeR.GetByCopyIDAsList(id);
            LoadParentStuff(copy.TitleID);

            return View(copy);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, Copy copy)
        {
            try
            {
                _copyR.Update(copy);

                return RedirectToAction(MVC.Copy.Index());
            }
            catch
            {
                return View(copy);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var copy = _copyR.Get(id);
            LoadParentStuff(copy.TitleID);

            return View(copy);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, bool actuallyRemove)
        {
            try
            {
                if (actuallyRemove)
                    _copyR.Delete(id);
                else
                    _copyR.Remove(id);

                return RedirectToAction(MVC.Copy.Index());
            }
            catch
            {
                var Copy = _copyR.Get(id);
                if (Copy != null)
                    return View(Copy);
                else
                    return RedirectToAction(MVC.Copy.Index());
            }
        }
    }
}
