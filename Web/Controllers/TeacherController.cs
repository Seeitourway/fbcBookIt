using FbcBookIt.Entity;
using FbcBookIt.Repository;
using SecurityGuard.Interfaces;
using SecurityGuard.Services;
using System;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;

namespace Web.Controllers
{
    public class TeacherController : Controller
    {
        public readonly ITeacherR _teacherR;
        public readonly IStudentR _studentR;
        public readonly IStudentTeacherSchoolR _stsR;
        public readonly IFormatTypeR _formatTypeR;
        private IMembershipService membershipService;

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

            this.membershipService = new MembershipService(Membership.Provider);
            _formatTypeR = aFormatTypeR;
            _teacherR = aTeacherR;
            _studentR = aStudentR;
            _stsR = aSTSR;
        }

        // GET: Teacher
        [Authorize(Roles = "Teacher, Admin, SecurityGuard")]
        public ActionResult Index()
        {            
            if(Session["TeacherID"] == null)
            {
                var mu = membershipService.FindUsersByName(User.Identity.Name);
                string email = "";

                foreach (MembershipUser us in mu)
                {
                    if (us.UserName == User.Identity.Name)
                    {
                        email = us.Email;
                    }

                }

                Session.Add("TeacherID", _teacherR.GetByActiveAsList(true).Where(x => x.Email == email).FirstOrDefault().TeacherID);
            }
            var studs = _stsR.GetStudentSTSByTeacherID(Guid.Parse(Session["TeacherID"].ToString())); // CHANGE THIS
            ViewBag.FormatType = _formatTypeR.GetAll();
            return View(studs);
        }

        [Authorize(Roles = "Teacher, Admin, SecurityGuard")]
        public ActionResult ReleaseStudent(string studentID)
        {
            var stud = _stsR.GetByStudentIDAndTeacherID(Guid.Parse(studentID), Guid.Parse(Session["TeacherID"].ToString())); // CHANGE THIS
            stud.Active = false;
            _stsR.Update(stud);
            return RedirectToAction("Index", new { TeacherID = Guid.Parse(Session["TeacherID"].ToString()) }); // CHANGE THIS
        }
    }
}