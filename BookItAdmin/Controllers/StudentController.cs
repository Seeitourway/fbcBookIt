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
        IStudentTeacherSchoolR _studentTeacherSchoolR;
        ITeacherR _teacherR;
        IBookRequestR _bookRequestR;
        public StudentController(IStudentR StudentR, IStudentTeacherSchoolR studentTeacherSchoolR, ITeacherR teacherR, IBookRequestR bookRequestR)
        {
            if (StudentR == null)
                throw new NullReferenceException("Student repo is null");

            _StudentR = StudentR;
            _studentTeacherSchoolR = studentTeacherSchoolR;
            _teacherR = teacherR;
            _bookRequestR = bookRequestR;
        }

        public virtual ActionResult Index()
        {
            var student = _StudentR.GetAll();
            return View(student);
        }

        public virtual ActionResult Details(Guid id)
        {
            var student = _StudentR.Get(id);
            LoadStuff(ref student);
            return View(student);
        }

        private void LoadStuff(ref Student student)
        {
            //var request = _bookRequestR.GetByActiveAndStudent(true, student.StudentID);
        }

        public virtual ActionResult Create()
        {
            var student = new Student();
            student.Active = true;
            return View(student);
        }

        [HttpPost]
        public virtual ActionResult Create(Student student)
        {
            try
            {
                student.Active = true;
                var id = _StudentR.InsertAndReturnPrimaryKey(student);

                return RedirectToAction(MVC.Student.Details(id));
            }
            catch
            {
                return View(student);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var student = _StudentR.Get(id);
            return View(student);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, Student student)
        {
            try
            {
                _StudentR.Update(student);

                return RedirectToAction(MVC.Student.Details(id));
            }
            catch
            {
                return View(student);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var student = _StudentR.Get(id);
            return View(student);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
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
