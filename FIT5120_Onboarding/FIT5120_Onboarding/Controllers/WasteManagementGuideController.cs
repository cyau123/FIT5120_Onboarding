using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5120_Onboarding.Controllers
{
    public class WasteManagementGuideController : Controller
    {
        // GET: WasteManagementGuide
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RedBin()
        {
            return View();
        }

        public ActionResult GreenBin()
        {
            return View();
        }

        public ActionResult YellowBin()
        {
            return View();
        }
    }
}