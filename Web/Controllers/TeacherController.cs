using FbcBookIt.Entity;
using FbcBookIt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            List<Student> studs =_studentR.GetAll();
            return View(studs);
        }

        public ActionResult ReleaseStudent(string studentID)
        {
            
            return null;
        }
    }
}
