using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class TeacherController : Controller
    {
        ITeacherR _teacherR;
        public TeacherController(ITeacherR teacherR)
        {
            if (teacherR == null)
                throw new NullReferenceException("Teacher repo is null");

            _teacherR = teacherR;
        }

        public virtual ActionResult Index()
        {
            var teachers = _teacherR.GetAll();
            return View(teachers);
        }

        public virtual ActionResult Details(Guid id)
        {
            var teacher = _teacherR.Get(id);
            return View();
        }

        public virtual ActionResult Create()
        {
            var teacher = new Teacher();
            return View(teacher);
        }

        [HttpPost]
        public virtual ActionResult Create(Teacher teacher)
        {
            try
            {
                var id = _teacherR.InsertAndReturnPrimaryKey(teacher);

                return RedirectToAction(MVC.Teacher.Details(id));
            }
            catch
            {
                return View(teacher);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var teacher = _teacherR.Get(id);
            return View(teacher);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, Teacher teacher)
        {
            try
            {
                _teacherR.Update(teacher);

                return RedirectToAction(MVC.Teacher.Details(id));
            }
            catch
            {
                return View(teacher);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var teacher = _teacherR.Get(id);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, bool actuallyDelete)
        {
            try
            {
                if (actuallyDelete)
                    _teacherR.Delete(id);
                else
                    _teacherR.Remove(id);

                return RedirectToAction(MVC.Teacher.Index());
            }
            catch
            {
                return View(id);
            }
        }
    }
}
