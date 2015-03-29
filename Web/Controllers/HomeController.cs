namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using FbcBookIt.Entity;
    using FbcBookIt.Repository;

    public class HomeController: Controller
    {
        private readonly IBookLoanR _BookLoanR;

        public HomeController(IBookLoanR aBookLoanR)
        {
            if (aBookLoanR == null)
            {
                throw new ArgumentNullException("aBookLoanR");
            }
            _BookLoanR = aBookLoanR;
        }

        [Authorize]
        public ActionResult Index()
        {
            List<BookLoan> vList = _BookLoanR.GetAll();
            
            return View();
        }
    }
}