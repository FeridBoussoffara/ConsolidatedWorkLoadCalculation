using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class TaskConfiguration : EntityTypeConfiguration<Domain.Entities.Task>
    {
        public TaskConfiguration()
        {
            Property(p => p.EndDate).IsOptional();
            HasRequired<Project>(p => p.Project).WithMany(t => t.Tasks).HasForeignKey(p => p.ProjectId);
            HasOptional<Employee>(p => p.Employee).WithMany(e => e.Tasks).HasForeignKey(p=>p.EmployeeId);
        }
    }
}
