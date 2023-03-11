using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FIT5120_Onboarding.Models
{
    public partial class FIT5120_Models : DbContext
    {
        public FIT5120_Models()
            : base("name=FIT5120_Models")
        {
        }

        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<Garbage> Garbages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
