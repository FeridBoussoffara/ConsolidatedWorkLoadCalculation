using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class TeamLeader: Employee
    {
     public ICollection<GroupProject> groupProjects { get; set; }
}
}
