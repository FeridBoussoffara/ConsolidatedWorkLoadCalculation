using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class LeaveConfiguration : EntityTypeConfiguration<Leave>
    {
        public LeaveConfiguration()
        {
            HasRequired<Employee>(e => e.Employee).WithMany(l => l.Leaves).HasForeignKey(e => e.EmployeeId);
        }
    }
}
