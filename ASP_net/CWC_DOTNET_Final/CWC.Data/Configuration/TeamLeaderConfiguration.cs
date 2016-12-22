using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class TeamLeaderConfiguration : EntityTypeConfiguration<TeamLeader>
    {
        public TeamLeaderConfiguration()
        {
            HasMany(p => p.groupProjects).WithRequired(p => p.TeamLeader).HasForeignKey(p=>p.TeamLeaderId);
        }
    }
}
