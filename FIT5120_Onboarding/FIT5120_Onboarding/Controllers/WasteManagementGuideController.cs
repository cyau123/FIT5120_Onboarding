using FIT5120_Onboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5120_Onboarding.Controllers
{
    public class WasteManagementGuideController : Controller
    {
        private FIT5120_Models db = new FIT5120_Models();

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

        [HttpPost]
        public ActionResult SearchBin(GarbageQuery model)
        {
            if (ModelState.IsValid)
            {
                string Name = model.GarbageEntered;
                var garbage = db.Garbages
                              .Where(s => s.GarbageName == Name)
                              .FirstOrDefault<Garbage>();

                if (garbage != null)
                {
                    model.BinColour = garbage.Color;
                    if (model.BinColour.ToUpper().Equals("YELLOW"))
                    {
                        return RedirectToAction("YellowBin");
                    }
                    else if (model.BinColour.ToUpper().Equals("GREEN"))
                    {
                        return RedirectToAction("GreenBin");
                    }
                    else
                    {
                        return RedirectToAction("RedBin");
                    }
                }
                else
                {
                    model.BinColour = "Type of garbage cannot be found";
                }
            }
            return View("Index", model);
        }
    }
}