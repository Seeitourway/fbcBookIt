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
            Session.Add("TeacherID", "15a950c2-c846-6853-1ceb-000b146a3df7");

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
        public ActionResult getStudentByNameAndDOB(string FirstName, string LastName, string DateOfBirth)
        {
            // get a list of students matching criteria

            List<Student> studs = _StudentR.GetAll();
            DateTime dateofbirth = DateTime.Parse(DateOfBirth);

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
            sts.SchoolID = _STSR.GetByStudentIDAndTeacherID(sts.StudentID, sts.TeacherID).SchoolID;
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