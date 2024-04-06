using QLBQA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace QLBQA.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private QLBQA_DB db = new QLBQA_DB();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

    }
}