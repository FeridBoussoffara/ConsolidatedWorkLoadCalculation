using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class EmployeConfiguration: EntityTypeConfiguration<Employee>
    {
        public EmployeConfiguration()
        {
            Map<Administrator>(c =>
            {
                c.Requires("Type").HasValue("Administrator");
            });
            Map<Trainor>(c =>
            {
                c.Requires("Type").HasValue("Trainor");
            });
            Map<TeamLeader>(c =>
            {
                c.Requires("Type").HasValue("TeamLeader");
            });

            HasMany(p => p.Assignements);
        }
    }
}
