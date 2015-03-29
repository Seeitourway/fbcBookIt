using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class BookLoanController : Controller
    {
        IBookLoanR _bookLoanR;
        IBookRequestR _bookRequestR;
        ITitleR _titleR;
        ICopyR _copyR;
        IVolumeR _volumeR;
        IStudentTeacherSchoolR _studentTeacherSchoolR;
        IFormatTypeR _formatTypeR;
        IStudentR _studentR;
        ITeacherR _teacherR;
        ISchoolR _schoolR;
        IDistrictR _districtR;
        public BookLoanController(IBookLoanR bookLoanR, IBookRequestR bookRequestR, ITitleR titleR, ICopyR copyR, IVolumeR volumeR, IStudentTeacherSchoolR studentTeacherSchoolR, IFormatTypeR formatTypeR, IStudentR studentR, ITeacherR teacherR, ISchoolR schoolR, IDistrictR districtR)
        {
            if (bookLoanR == null)
                throw new NullReferenceException("Book loan repo is null");

            _bookLoanR = bookLoanR;
            _bookRequestR = bookRequestR;
            _titleR = titleR;
            _copyR = copyR;
            _volumeR = volumeR;
            _studentTeacherSchoolR = studentTeacherSchoolR;
            _formatTypeR = formatTypeR;
            _studentR = studentR;
            _teacherR = teacherR;
            _schoolR = schoolR;
            _districtR = districtR;
        }

        int pageSize = 25;
        public virtual ActionResult Index(int? page)
        {
            if (!page.HasValue)
                page = 0;
            ViewBag.Page = page.Value;

            var bookLoans = _bookLoanR.GetAll().Skip(page.Value * pageSize).Take(pageSize).ToList();
            for (int i = 0; i < bookLoans.Count; i++)
            {
                var bookLoan = bookLoans[i];
                LoadStuff(ref bookLoan);
            }

            return View(bookLoans);
        }

        public virtual ActionResult Details(Guid id)
        {
            var bookLoan = _bookLoanR.Get(id);
            LoadStuff(ref bookLoan);

            return View(bookLoan);
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

        public virtual ActionResult Create(Guid id)
        {
            var bookLoan = new BookLoan();
            bookLoan.BookRequestID = id;
            LoadStuff(ref bookLoan, true);

            return View(bookLoan);
        }

        [HttpPost]
        public virtual ActionResult Create(Guid BookRequestID, string selected)
        {
            var bookLoan = new BookLoan();
            try
            {
                bookLoan.BookRequestID = BookRequestID;
                var selectedVols = selected.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                LoadStuff(ref bookLoan, true);
                //var bookRequest = _bookRequestR.Get(bookLoan.BookRequestID);
                //var loans = _bookLoanR.GetByBookRequestId(bookRequest.BookRequestId);
                //var max = loans.OrderByDesc(l => l.LoanNumber).FirstOrDefault();
                //var i = max.LoanNumber;
                var i = 0;

                foreach (var copy in bookLoan.AvailableCopies)
                {
                    if (copy.Volumes.Any())
                    {
                        foreach (var vol in copy.Volumes)
                        {
                            if (selectedVols.Contains(vol.VolumeID.ToString()))
                            {
                                var loan = new BookLoan();
                                loan.BookRequestID = bookLoan.BookRequestID;
                                loan.LoanNumber = ++i;
                                loan.LoanStatus = LoanStatusE.Active;
                                loan.VolumeID = vol.VolumeID;
                                loan.OutDate = DateTime.Now.Date;
                                _bookLoanR.Insert(loan);
                            }
                        }
                    }
                }

                return RedirectToAction(MVC.BookRequest.Details(bookLoan.BookRequestID));
            }
            catch
            {
                return View(bookLoan);
            }
        }

        public virtual ActionResult Edit(Guid id)
        {
            var bookLoan = _bookLoanR.Get(id);
            LoadStuff(ref bookLoan);
            return View(bookLoan);
        }

        [HttpPost]
        public virtual ActionResult Edit(Guid id, BookLoan bookLoan)
        {
            try
            {
                _bookLoanR.Update(bookLoan);

                return RedirectToAction(MVC.BookLoan.Details(id));
            }
            catch
            {
                return View(bookLoan);
            }
        }

        public virtual ActionResult Delete(Guid id)
        {
            var bookLoan = _bookLoanR.Get(id);
            LoadStuff(ref bookLoan);
            return View(bookLoan);
        }

        [HttpPost]
        public virtual ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _bookLoanR.Delete(id);

                return RedirectToAction(MVC.BookLoan.Index(0));
            }
            catch
            {
                return View(id);
            }
        }
    }
}
