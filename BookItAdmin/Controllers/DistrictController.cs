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
            var districts = _DistrictR.GetAll();
            return View(districts);
        }

        public virtual ActionResult Details(Guid id)
        {
            var district = _DistrictR.Get(id);
            return View(district);
        }

        public virtual ActionResult Create()
        {
            var district = new District();
            district.Active = true;
            return View(district);
        }

        [HttpPost]
        public virtual ActionResult Create(District district)
        {
            try
            {
                district.Active = true;
                var id = _DistrictR.InsertAndReturnPrimaryKey(district);

                return RedirectToAction(MVC.District.Details(id));
            }
            catch
            {
                return View(district);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var district = _DistrictR.Get(id);
            return View(district);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, District district)
        {
            try
            {
                _DistrictR.Update(district);

                return RedirectToAction(MVC.District.Details(id));
            }
            catch
            {
                return View(district);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var district = _DistrictR.Get(id);
            return View(district);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
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
