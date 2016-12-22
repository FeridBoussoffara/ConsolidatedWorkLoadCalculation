using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class PayslipConfiguration : EntityTypeConfiguration<PaySlip>
    {
        public PayslipConfiguration()
        {
            HasRequired<Employee>(e => e.Employee).WithMany(p => p.PaySlips).HasForeignKey(e => e.EmployeeId);

        }
    }
}
