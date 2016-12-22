using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public String Name { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public bool State { get; set; }
        public virtual Project Project { get; set; }
        public int? ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public String EmployeeId { get; set; }
    }
}
