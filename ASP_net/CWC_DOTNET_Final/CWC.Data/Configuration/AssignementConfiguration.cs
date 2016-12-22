using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class AssignementConfiguration : EntityTypeConfiguration<Assignement>
    {
        public AssignementConfiguration()
        {
            HasKey(a => a.AssignementId);
            HasRequired(a => a.Employee).WithMany(e => e.Assignements).HasForeignKey(a => a.EmployeeId).WillCascadeOnDelete(false);
 
           
        }
    }
}
