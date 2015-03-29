using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class BookRequestController : Controller
    {
        IBookRequestR _bookRequestR;
        IBookLoanR _bookLoanR;
        ITitleR _titleR;
        IStudentTeacherSchoolR _studentTeacherSchoolR;
        IFormatTypeR _formatTypeR;
        IStudentR _studentR;
        ITeacherR _teacherR;
        ISchoolR _schoolR;
        IDistrictR _districtR;
        ICopyR _copyR;
        IVolumeR _volumeR;
        public BookRequestController(IBookRequestR BookRequestR, IBookLoanR bookLoanR, ITitleR titleR, IStudentTeacherSchoolR studentTeacherSchoolR, IFormatTypeR formatTypeR, IStudentR studentR, ITeacherR teacherR, ISchoolR schoolR, IDistrictR districtR, ICopyR copyR, IVolumeR volumeR)
        {
            if (BookRequestR == null)
                throw new NullReferenceException("BookRequest repo is null");

            _bookRequestR = BookRequestR;
            _bookLoanR = bookLoanR;
            _titleR = titleR;
            _studentTeacherSchoolR = studentTeacherSchoolR;
            _formatTypeR = formatTypeR;
            _studentR = studentR;
            _teacherR = teacherR;
            _schoolR = schoolR;
            _districtR = districtR;
            _copyR = copyR;
            _volumeR = volumeR;
        }

        int pageSize = 25;
        public virtual ActionResult Index(int? page)
        {
            if (!page.HasValue)
                page = 0;
            ViewBag.Page = page.Value;

            var BookRequests = _bookRequestR.GetAll().Skip(page.Value * pageSize).Take(pageSize).ToList();
            for (int i = 0; i < BookRequests.Count; i++)
            {
                var bookRequest = BookRequests[i];
                LoadStuff(ref bookRequest);
            }
            return View(BookRequests);
        }

        public virtual ActionResult Details(Guid id)
        {
            var BookRequest = _bookRequestR.Get(id);
            LoadStuff(ref BookRequest);
            return View(BookRequest);
        }

        private void LoadStuff(ref BookRequest bookRequest)
        {
            if (bookRequest.FormatTypeID.HasValue)
                bookRequest.FormatType = _formatTypeR.Get(bookRequest.FormatTypeID.Value).FormatDescription;

            var sts = _studentTeacherSchoolR.Get(bookRequest.StudentTeacherSchoolId);
            if (sts != null)
            {
                var student = _studentR.Get(sts.StudentID);
                var teacher = _teacherR.Get(sts.TeacherID);
                var school = _schoolR.Get(sts.SchoolID);
                var district = _districtR.Get(school.DistrictID);
                bookRequest.Student = student.FirstName + " " + student.LastName;
                bookRequest.Teacher = teacher.Name;
                bookRequest.School = school.Name;
                bookRequest.District = district.DistrictName;
            }

            var title = _titleR.Get(bookRequest.TitleID);
            bookRequest.Title = title.Name;

            var loans = _bookLoanR.GetByBookRequestIDAsList(bookRequest.BookRequestId);
            for (var i = 0; i < loans.Count; i++)
            {
                var loan = loans[i];
                loan.Volume = _volumeR.Get(loan.VolumeID);
            }
            bookRequest.Loans = loans.ToList();
        }

        private void LoadStuff(ref BookLoan bookLoan, bool? includeCopies = false)
        {
            var bookRequest = _bookRequestR.Get(bookLoan.BookRequestID);

            if (bookRequest.FormatTypeID.HasValue)
                bookRequest.FormatType = _formatTypeR.Get(bookRequest.FormatTypeID.Value).FormatDescription;
            bookLoan.RequestNumber = bookRequest.RequestNumber;

            var sts = _studentTeacherSchoolR.Get(bookRequest.StudentTeacherSchoolId);
            if (sts != null)
            {
                var student = _studentR.Get(sts.StudentID);
                var teacher = _teacherR.Get(sts.TeacherID);
                var school = _schoolR.Get(sts.SchoolID);
                var district = _districtR.Get(school.DistrictID);
                bookLoan.Student = student.FirstName + " " + student.LastName;
                bookLoan.Teacher = teacher.Name;
                bookLoan.School = school.Name;
                bookLoan.District = district.DistrictName;
            }

            var title = _titleR.Get(bookRequest.TitleID);
            bookLoan.Title = title.Name;

            if (includeCopies.HasValue && includeCopies.Value)
            {
                var copies = _copyR.GetByActiveAndTitleIDAsList(true, title.TitleID);
                var goodCopies = (from copy in copies where copy.CopyStatus == CopyStatusE.Available && copy.FormatTypeID == bookRequest.FormatTypeID select copy).ToList();
                for (int i = 0; i < goodCopies.Count(); i++)
                {
                    var copy = goodCopies[i];
                    var vols = _volumeR.GetByCopyIDAsList(copy.CopyId);
                    var goodVols = from vol in vols where vol.VolumeStatusID.Value == (int)VolumeStatusE.Available select vol;
                    copy.Volumes = goodVols.ToList();
                }
                bookLoan.AvailableCopies = goodCopies;
            }
        }

        public virtual ActionResult Create()
        {
            var BookRequest = new BookRequest();
            return View(BookRequest);
        }

        [HttpPost]
        public virtual ActionResult Create(BookRequest BookRequest)
        {
            try
            {
                var id = _bookRequestR.InsertAndReturnPrimaryKey(BookRequest);

                return RedirectToAction(MVC.BookRequest.Details(id));
            }
            catch
            {
                return View(BookRequest);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var BookRequest = _bookRequestR.Get(id);
            LoadStuff(ref BookRequest);
            return View(BookRequest);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, BookRequest BookRequest)
        {
            try
            {
                _bookRequestR.Update(BookRequest);

                return RedirectToAction(MVC.BookRequest.Details(id));
            }
            catch
            {
                return View(BookRequest);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var BookRequest = _bookRequestR.Get(id);
            LoadStuff(ref BookRequest);
            return View(BookRequest);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _bookRequestR.Delete(id);

                return RedirectToAction(MVC.BookRequest.Index(0));
            }
            catch
            {
                return View(id);
            }
        }

        [HttpPost]
        public virtual ActionResult CheckIn(Guid id, LoanStatusE loanStatus)
        {
            Guid bookRequestId = Guid.Empty;
            var loan = _bookLoanR.Get(id);
            if (loan == null)
            {
                var bookRequest = _bookRequestR.Get(id);
                if (bookRequest != null)
                {
                    bookRequestId = id;
                    var loans = _bookLoanR.GetByBookRequestIDAsList(id);
                    var checkedout = from l in loans where !l.InDate.HasValue && l.LoanStatus == LoanStatusE.Closed orderby l.LoanNumber select l;
                    foreach (var turnedin in checkedout)
                    {
                        turnedin.InDate = DateTime.Now.Date;
                        turnedin.LoanStatus = loanStatus;
                        _bookLoanR.Update(turnedin);
                    }
                }
            }
            else
            {
                bookRequestId = loan.BookRequestID;
                loan.InDate = DateTime.Now.Date;
                loan.LoanStatus = loanStatus;
                _bookLoanR.Update(loan);
            }
            return RedirectToAction(MVC.BookRequest.Details(bookRequestId));
        }
    }
}
