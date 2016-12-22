using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            Map<IndividualProject>(c =>
            {
                c.Requires("Type").HasValue("IndividualProject");
            });
            Map<GroupProject>(c =>
            {
                c.Requires("Type").HasValue("GroupProject");
            });

        }
    }
}
