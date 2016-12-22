using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class ERPAppConfiguration : EntityTypeConfiguration<ERPApp>
    {
        public ERPAppConfiguration()
        {
            HasRequired<Employee>(e => e.Administrator).WithOptional(a => a.ERPApp);
        }
    }
}
