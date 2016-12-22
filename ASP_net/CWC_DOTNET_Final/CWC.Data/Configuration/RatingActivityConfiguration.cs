using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class RatingActivityConfiguration : EntityTypeConfiguration<RatingActivity>
    {
        public RatingActivityConfiguration()
        {
            HasRequired<Activity>(a => a.Activity).WithMany(b => b.RatingActivity).HasForeignKey(a => a.ActivityId).WillCascadeOnDelete(false);
            HasRequired<Employee>(a => a.Employee).WithMany(b => b.RatingActivity).HasForeignKey(a => a.EmployeId).WillCascadeOnDelete(false);

            HasKey(r => new { r.ActivityId, r.EmployeId });
        }

    }
}
