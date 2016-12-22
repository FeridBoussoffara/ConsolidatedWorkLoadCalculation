using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class Leave
    {
        public int LeaveId { get; set; }
        public String Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool State { get; set; }
        public virtual Employee Employee { get; set; }
        public string EmployeeId { get; set; }

    }
}
