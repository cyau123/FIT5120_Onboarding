using FIT5120_Onboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5120_Onboarding.Controllers
{
    public class AddressQueryController : Controller
    {
        private FIT5120_Models db = new FIT5120_Models();
        // GET: AddressQuery
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(AddressQuery model)
        {
            if (ModelState.IsValid)
            {
                Schedule schedule = db.Schedules.Find(1);
                if (model.AddressEntered.Equals(schedule.Address))
                {
                    string NextWaste = GetNextFornightly(schedule.NextWaste);
                    string NextRecycle = GetNextFornightly(schedule.NextRecycle);
                    string NextGreen = GetNextWeekly(schedule.NextGreen);

                    model.NextWasteDate = NextWaste;
                    model.NextRecycleDate = NextRecycle;
                    model.NextGreenDate = NextGreen;
                }
                else
                {
                    model.NextWasteDate = "Address not found";
                    model.NextRecycleDate = "Address not found";
                    model.NextGreenDate = "Address not found";
                  
                }
            }

            return View("Index", model);
        }
       
        public string GetNextWeekly(DateTime givenDate)
        {
            DateTime dateOfToday = DateTime.Now.Date;
            var diff = dateOfToday - givenDate;
            double daysDiff = diff.TotalDays;
            DateTime nextDate = dateOfToday;
            if (daysDiff >= 0) //if today is after given date
            {
                if (daysDiff % 7 != 0) //if it is not today
                {
                    int diffInDays = (int)diff.TotalDays;
                    int numOfDays = 7;
                    var division = diffInDays / numOfDays; //integer division
                    int addedDays = 7 * (division + 1);
                    nextDate = givenDate.AddDays(addedDays);
                }
            }
            else
            {
                nextDate = givenDate;
            }
            return nextDate.ToString();
        }

        public string GetNextFornightly(DateTime givenDate)
        {
            DateTime dateOfToday = DateTime.Now.Date;
            var diff = dateOfToday - givenDate;
            double daysDiff = diff.TotalDays;
            DateTime nextDate = dateOfToday;
            if (daysDiff >= 0) //if today is after given date
            {
                if (daysDiff % 14 != 0) //if it is not today
                {
                    int diffInDays = (int)diff.TotalDays;
                    int numOfDays = 14;
                    var division = diffInDays / numOfDays; //integer division
                    int addedDays = 14 * (division + 1);
                    nextDate = givenDate.AddDays(addedDays);
                }
            }
            else
            {
                nextDate = givenDate;
            }
            return nextDate.ToString();
        }

    }


}