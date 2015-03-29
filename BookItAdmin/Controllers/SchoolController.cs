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
            var schools = _SchoolR.GetAll();
            return View(schools);
        }

        public virtual ActionResult Details(Guid id)
        {
            var school = _SchoolR.Get(id);
            return View(school);
        }

        public virtual ActionResult Create()
        {
            var school = new School();
            school.Active = true;
            return View(school);
        }

        [HttpPost]
        public virtual ActionResult Create(School school)
        {
            try
            {
                var id = _SchoolR.InsertAndReturnPrimaryKey(school);

                return RedirectToAction(MVC.School.Details(id));
            }
            catch
            {
                return View(school);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var school = _SchoolR.Get(id);
            return View(school);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, School school)
        {
            try
            {
                _SchoolR.Update(school);

                return RedirectToAction(MVC.School.Details(id));
            }
            catch
            {
                return View(school);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var school = _SchoolR.Get(id);
            return View(school);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _SchoolR.Remove(id);

                return RedirectToAction(MVC.School.Index());
            }
            catch
            {
                return View(id);
            }
        }    }
}
