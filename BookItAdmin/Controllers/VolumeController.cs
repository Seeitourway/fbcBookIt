using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class VolumeController : Controller
    {
        private ITitleR _titleR = null;
        private ICopyR _copyR = null;
        private IVolumeR _volumeR = null;
        public VolumeController(ITitleR titleR, ICopyR copyR, IVolumeR volumeR)
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
            var volume = _volumeR.Get(id);
            if (volume.CopyID.HasValue)
                LoadParentStuff(volume.CopyID.Value);

            return View(volume);
        }

        private void LoadParentStuff(Guid copyId)
        {
            var copy = _copyR.Get(copyId);
            var title = _titleR.Get(copy.TitleID);
            ViewBag.AccessionNumber = copy.AccessionNumber;
            ViewBag.CopyId = copy.CopyId;
            ViewBag.TitleName = title.Name;
            ViewBag.TitleId = title.TitleID;
        }

        public virtual ActionResult Details(Guid id)
        {
            var volume = _volumeR.Get(id);
            if (volume.CopyID.HasValue)
                LoadParentStuff(volume.CopyID.Value);
            return View(volume);
        }

        public virtual ActionResult Create(Guid copyId)
        {
            var volume = new Volume();
            volume.CopyID = copyId;
            LoadParentStuff(copyId);
            return View(volume);
        }

        [HttpPost]
        public virtual ActionResult Create(Volume volume)
        {
            try
            {
                var id = _volumeR.InsertAndReturnPrimaryKey(volume);

                return RedirectToAction(MVC.Volume.Index(id));
            }
            catch
            {
                return View(volume);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var volume = _volumeR.Get(id);
            if (volume.CopyID.HasValue)
                LoadParentStuff(volume.CopyID.Value);
            return View(volume);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, Volume volume)
        {
            try
            {
                _volumeR.Update(volume);

                return RedirectToAction(MVC.Volume.Index(volume.VolumeID));
            }
            catch
            {
                return View(volume);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var volume = _volumeR.Get(id);
            if (volume.CopyID.HasValue)
                LoadParentStuff(volume.CopyID.Value);
            return View(volume);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, bool actuallyRemove)
        {
            try
            {
                var volume = _volumeR.Get(id);
                var copyId = volume.CopyID;

                _volumeR.Delete(id);

                if (copyId.HasValue)
                {
                    return RedirectToAction(MVC.Copy.Details(copyId.Value));
                }
                return RedirectToAction(MVC.Copy.Index());
            }
            catch
            {
                var volume = _volumeR.Get(id);
                if (volume != null)
                    return View(volume);
                else
                    return RedirectToAction(MVC.Copy.Index());
            }
        }
    }
}
