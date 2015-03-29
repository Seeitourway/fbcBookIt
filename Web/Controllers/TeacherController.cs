using FbcBookIt.Repository;
using System;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TeacherController : Controller
    {
        public readonly ITeacherR _teacherR;
        public readonly IStudentR _studentR;
        public readonly IStudentTeacherSchoolR _stsR;

        public TeacherController(ITeacherR aTeacherR, IStudentR aStudentR, IStudentTeacherSchoolR aSTSR)
        {
            if (aTeacherR == null)
            {
                throw new ArgumentNullException("aTeacherR");
            }
            if (aStudentR == null)
            {
                throw new ArgumentNullException("aStudentR");
            }
            if (aSTSR == null)
            {
                throw new ArgumentNullException("aSTSR");
            }

            _teacherR = aTeacherR;
            _studentR = aStudentR;
            _stsR = aSTSR;
        }

        // GET: Teacher
        public ActionResult Index()
        {
            // need all STUDENT records joined with StudentTeacherSchool based on TeacherID
            var studs = _stsR.GetStudentSTSByTeacherID(Guid.Parse("15A950C2-C846-6853-1CEB-000B146A3DF7"));
            return View(studs);
        }

        public ActionResult ReleaseStudent(string studentID)
        {
            var stud = _stsR.GetByStudentIDAndTeacherID(Guid.Parse(studentID), Guid.Parse("15A950C2-C846-6853-1CEB-000B146A3DF7"));
            stud.Active = false;
            _stsR.Update(stud);
            return RedirectToAction("Index", new { TeacherID = Guid.Parse("15A950C2-C846-6853-1CEB-000B146A3DF7") });
        }
    }
}