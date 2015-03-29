using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class StudentController : Controller
    {
        IStudentR _StudentR;
        public StudentController(IStudentR StudentR)
        {
            if (StudentR == null)
                throw new NullReferenceException("Student repo is null");

            _StudentR = StudentR;
        }

        public virtual ActionResult Index()
        {
            var Students = _StudentR.GetAll();
            return View(Students);
        }

        public virtual ActionResult Details(Guid id)
        {
            var Student = _StudentR.Get(id);
            return View();
        }

        public virtual ActionResult Create()
        {
            var Student = new Student();
            return View(Student);
        }

        [HttpPost]
        public virtual ActionResult Create(Student Student)
        {
            try
            {
                var id = _StudentR.InsertAndReturnPrimaryKey(Student);

                return RedirectToAction(MVC.Student.Details(id));
            }
            catch
            {
                return View(Student);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var Student = _StudentR.Get(id);
            return View(Student);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, Student Student)
        {
            try
            {
                _StudentR.Update(Student);

                return RedirectToAction(MVC.Student.Details(id));
            }
            catch
            {
                return View(Student);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var Student = _StudentR.Get(id);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, bool actuallyDelete)
        {
            try
            {
                if (actuallyDelete)
                    _StudentR.Delete(id);
                else
                    _StudentR.Remove(id);

                return RedirectToAction(MVC.Student.Index());
            }
            catch
            {
                return View(id);
            }
        }
    }
}
