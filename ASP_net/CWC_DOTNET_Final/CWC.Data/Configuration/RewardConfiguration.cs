using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class RewardConfiguration : EntityTypeConfiguration<Reward>
    {
        public RewardConfiguration()
        {
            HasOptional<Employee>(e => e.Employee).WithMany(r => r.Rewards).HasForeignKey(e => e.EmployeeId);
        }
    }
}
