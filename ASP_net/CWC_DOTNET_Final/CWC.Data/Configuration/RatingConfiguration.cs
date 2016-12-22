using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingConfiguration()
        {
            HasRequired<Employee>(e => e.TeamLeader).WithMany(r => r.Ratings).HasForeignKey(e => e.TeamLeaderId);
        }
    }
}
