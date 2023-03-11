namespace FIT5120_Onboarding.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Garbage
    {
        public int Id { get; set; }

        [Required]
        public string GarbageName { get; set; }

        [Required]
        public string DisposalMethod { get; set; }

        [Required]
        public string Color { get; set; }
    }
}
