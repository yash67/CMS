using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Layout_Demo.Areas.Dealer.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealer/Dealer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SelectCity()
        {
            return View();
        }
    }
}