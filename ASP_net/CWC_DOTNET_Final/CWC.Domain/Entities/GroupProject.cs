using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class GroupProject: Project
    {
        public virtual ICollection<Assignement> Assignements { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
       
        [ForeignKey("TeamLeader")]
        public string TeamLeaderId { get; set; }

        public virtual TeamLeader TeamLeader { get; set; }
    }
}
