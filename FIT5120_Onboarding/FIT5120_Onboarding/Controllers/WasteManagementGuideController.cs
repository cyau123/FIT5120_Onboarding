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
            ViewBag.Message = "The landfill bin (red lid) is for any items that cannot be recycled through your recycling bin, food and garden waste bin or other recycling services.";
            return View();
        }

        public ActionResult GreenBin()
        {
            ViewBag.Message = "The organic bin (green lid) is for food scraps, garden prunings and some organic material. The bin is collected every week.";
            return View();
        }

        public ActionResult YellowBin()
        {
            ViewBag.Message = "The recycling bin (yellow lid) is for common household packaging items typically bought at a supermarket and found in your kitchen, bathroom or laundry.";
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
                    model.BinColour = "Item cannot be found";
                }
            }
            return View("Index", model);
        }
    }
}