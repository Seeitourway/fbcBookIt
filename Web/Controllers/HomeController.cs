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

        public ActionResult Index()
        {
            List<BookLoan> vList = _BookLoanR.GetAll();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}