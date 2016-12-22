using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class AttendenceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendenceConfiguration()
        {
            HasOptional<Employee>(e => e.Employee).WithMany(a => a.Attendances).HasForeignKey(e => e.EmployeeId);
        }
    }
}
