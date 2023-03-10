using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5120_Onboarding.Models
{
    public class AddressQuery
    {
        public string AddressEntered { get; set; }

        public string NextWasteDate { get; set; }

        public string NextRecycleDate { get; set; }

        public string NextGreenDate { get; set; }
    }
}