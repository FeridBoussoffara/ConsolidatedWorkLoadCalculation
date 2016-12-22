using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class Assignement
    {
        public int AssignementId { get; set; }
        public string EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }
}
