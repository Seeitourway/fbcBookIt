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
        public TeacherController(ITeacherR aTeacherR, IStudentR aStudentR)
        {
            if (aTeacherR == null)
            {
                throw new ArgumentNullException("aTeacherR");
            }
            if (aStudentR == null)
            {
                throw new ArgumentNullException("aStudentR");
            }

            _teacherR = aTeacherR;
            _studentR = aStudentR;
        }

        // GET: Teacher
        public ActionResult Index()
        {
            List<Student> studs =_studentR.GetAll();
            return View(studs);
        }      
    }
}
