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
        public readonly IFormatTypeR _formatTypeR;

        public TeacherController(ITeacherR aTeacherR, IStudentR aStudentR, IStudentTeacherSchoolR aSTSR, IFormatTypeR aFormatTypeR)
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
            if (aFormatTypeR == null)
            {
                throw new ArgumentNullException("aFormatTypeR");
            }
            
            _formatTypeR = aFormatTypeR;
            _teacherR = aTeacherR;
            _studentR = aStudentR;
            _stsR = aSTSR;
        }

        // GET: Teacher
        [Authorize(Roles = "Teacher, Admin, SecurityGuard")]
        public ActionResult Index()
        {
            var studs = _stsR.GetByTeacherIdWithStudentAsList(Guid.Parse("C49623B4-380D-46BE-9D2B-7C7E1CAA9C00"));
            ViewBag.FormatType = _formatTypeR.GetAll();
            return View(studs);
        }

        [Authorize(Roles = "Teacher, Admin, SecurityGuard")]
        public ActionResult ReleaseStudent(string studentID)
        {
            var stud = _stsR.GetByStudentIDAndTeacherID(Guid.Parse(studentID), Guid.Parse("C49623B4-380D-46BE-9D2B-7C7E1CAA9C00"));
            stud.Active = false;
            _stsR.Update(stud);
            return RedirectToAction("Index", new { TeacherID = Guid.Parse("C49623B4-380D-46BE-9D2B-7C7E1CAA9C00") });
        }
    }
}