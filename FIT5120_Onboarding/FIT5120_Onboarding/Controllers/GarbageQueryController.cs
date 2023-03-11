using FIT5120_Onboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5120_Onboarding.Controllers
{
    public class GarbageQueryController : Controller
    {
        private FIT5120_Models db = new FIT5120_Models();

        // GET: GarbageQuery
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchColour(GarbageQuery model)
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