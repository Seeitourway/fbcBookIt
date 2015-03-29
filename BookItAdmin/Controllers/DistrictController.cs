using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class DistrictController : Controller
    {
        IDistrictR _DistrictR;
        public DistrictController(IDistrictR DistrictR)
        {
            if (DistrictR == null)
                throw new NullReferenceException("District repo is null");

            _DistrictR = DistrictR;
        }
        public virtual ActionResult Index()
        {
            var Districts = _DistrictR.GetAll();
            return View(Districts);
        }

        public virtual ActionResult Details(Guid id)
        {
            var District = _DistrictR.Get(id);
            return View();
        }

        public virtual ActionResult Create()
        {
            var District = new District();
            return View(District);
        }

        [HttpPost]
        public virtual ActionResult Create(District District)
        {
            try
            {
                var id = _DistrictR.InsertAndReturnPrimaryKey(District);

                return RedirectToAction(MVC.District.Details(id));
            }
            catch
            {
                return View(District);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var District = _DistrictR.Get(id);
            return View(District);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, District District)
        {
            try
            {
                _DistrictR.Update(District);

                return RedirectToAction(MVC.District.Details(id));
            }
            catch
            {
                return View(District);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var District = _DistrictR.Get(id);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, bool actuallyDelete)
        {
            try
            {
                if (actuallyDelete)
                    _DistrictR.Delete(id);
                else
                    _DistrictR.Remove(id);

                return RedirectToAction(MVC.District.Index());
            }
            catch
            {
                return View(id);
            }
        }
    }
}
