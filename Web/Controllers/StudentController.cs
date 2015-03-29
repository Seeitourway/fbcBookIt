using FbcBookIt.Entity;
using FbcBookIt.Repository;
using SecurityGuard.Interfaces;
using SecurityGuard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        public readonly IStudentR _StudentR;
        public readonly IStudentTeacherSchoolR _STSR;
        public readonly ISchoolR _schoolR;
        private IMembershipService membershipService;
        public readonly ITeacherR _teacherR;
        public Guid teacherID;

        public StudentController(IStudentR aStudentR, IStudentTeacherSchoolR aSTSR, ISchoolR aSchoolR, ITeacherR aTeacherR)
        {
            if (aStudentR == null)
            {
                throw new ArgumentNullException("aStudentR");
            }
            if (aSchoolR == null)
            {
                throw new ArgumentNullException("aSchoolR");
            }
            if (aSTSR == null)
            {
                throw new ArgumentNullException("aSTSR");
            }
            if (aTeacherR == null)
            {
                throw new ArgumentNullException("aTeacherR");
            }
            _teacherR = aTeacherR;
            this.membershipService = new MembershipService(Membership.Provider);

            _STSR = aSTSR;
            _StudentR = aStudentR;
            _schoolR = aSchoolR;
        }

        // GET: Student
        [Authorize(Roles="Teacher, Admin, SecurityGuard")]
        public ActionResult Index(Guid? StudentId)
        {
            var mu = membershipService.FindUsersByName(User.Identity.Name);
            string email = "";

            foreach(MembershipUser us in mu)
            {
                if(us.UserName == User.Identity.Name)
                {
                    email = us.Email;
                }

            }

            teacherID = _teacherR.GetByActiveAsList(true).Where(x => x.Email == email).FirstOrDefault().TeacherID;
            Session.Add("TeacherID", teacherID);

            ViewBag.Schools = _schoolR.GetByActiveAsList(true);
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
        [Authorize(Roles = "Teacher, Admin, SecurityGuard")]
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
        [Authorize(Roles = "Teacher, Admin, SecurityGuard")]
        public ActionResult SaveStudent(Student stud)
        {
            // create student/teacher junction record
            if(stud.StudentID.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                stud.Active = true;
                Guid studentGuid = _StudentR.InsertAndReturnPrimaryKey(stud);
                stud.StudentID = studentGuid;
            }
            var teachId = Session["TeacherID"].ToString();
            StudentTeacherSchool sts = new StudentTeacherSchool();
            sts.TeacherID = Guid.Parse(teachId);
            sts.StudentID = stud.StudentID;
            sts.SchoolID = Guid.Parse(stud.School);
            sts.Active = true;
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