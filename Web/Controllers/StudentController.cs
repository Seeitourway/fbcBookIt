using FbcBookIt.Entity;
using FbcBookIt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        public readonly IStudentR _StudentR;
        public readonly IStudentTeacherSchoolR _STSR;

        public StudentController(IStudentR aStudentR, IStudentTeacherSchoolR aSTSR)
        {
            if (aStudentR == null)
            {
                throw new ArgumentNullException("aStudentR");
            }
            if (aSTSR == null)
            {
                throw new ArgumentNullException("aSTSR");
            }
            _StudentR = aStudentR;
            _STSR = aSTSR;
        }

        // GET: Student
        public ActionResult Index(Guid? StudentId)
        {
            Session.Add("TeacherID", "818dc049-0fde-417d-9158-cd3f1ee08e9c");

            if (StudentId == null)
            {
                return View(new Student());
            }
            var stud = _StudentR.Get((Guid)StudentId);

            if (stud != null)
                return View(stud);
            else
                return View(new Student());
        }

        [HttpGet]
        public ActionResult getStudentByNameAndDOB(string FirstName, string LastName, string dob)
        {
            // get a list of students matching criteria
            List<Student> studs = _StudentR.GetAll();
            DateTime dateofbirth = DateTime.Parse(dob);

            var q = studs.Where(x => x.DateOfBirth == dateofbirth);
            var w = q.Where(x => x.FirstName == FirstName);
            var y = w.Where(x => x.LastName == LastName);

            return PartialView("_studentList", y.ToList());
        }

        [HttpPost]
        public ActionResult SaveStudent(Student stud)
        {
            // create student/teacher junction record
            var teachId = Session["TeacherID"].ToString();
            StudentTeacherSchool sts = new StudentTeacherSchool();
            sts.TeacherID = Guid.Parse(teachId);
            sts.StudentID = stud.StudentID;
            var key = _STSR.InsertAndReturnPrimaryKey(sts);
            if (key != null)
            {
                return RedirectToAction("Index", "Teacher");
            }
            else
                throw new Exception("StudentTeacherSchool Insert Failed.");
        }
    }
}