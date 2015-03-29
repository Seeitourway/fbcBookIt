using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbcBookIt.Repository;
using FbcBookIt.Entity;

namespace BookItAdmin.Controllers
{
    public partial class DataManagerController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
