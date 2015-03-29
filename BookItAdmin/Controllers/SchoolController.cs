using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class SchoolController : Controller
    {
        ISchoolR _SchoolR;
        public SchoolController(ISchoolR SchoolR)
        {
            if (SchoolR == null)
                throw new NullReferenceException("School repo is null");

            _SchoolR = SchoolR;
        }
        public virtual ActionResult Index()
        {
            var Schools = _SchoolR.GetAll();
            return View(Schools);
        }

        public virtual ActionResult Details(Guid id)
        {
            var School = _SchoolR.Get(id);
            return View();
        }

        public virtual ActionResult Create()
        {
            var School = new School();
            return View(School);
        }

        [HttpPost]
        public virtual ActionResult Create(School School)
        {
            try
            {
                var id = _SchoolR.InsertAndReturnPrimaryKey(School);

                return RedirectToAction(MVC.School.Details(id));
            }
            catch
            {
                return View(School);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var School = _SchoolR.Get(id);
            return View(School);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, School School)
        {
            try
            {
                _SchoolR.Update(School);

                return RedirectToAction(MVC.School.Details(id));
            }
            catch
            {
                return View(School);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var School = _SchoolR.Get(id);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, bool actuallyDelete)
        {
            try
            {
                if (actuallyDelete)
                    _SchoolR.Delete(id);
                else
                    _SchoolR.Remove(id);

                return RedirectToAction(MVC.School.Index());
            }
            catch
            {
                return View(id);
            }
        }    }
}
