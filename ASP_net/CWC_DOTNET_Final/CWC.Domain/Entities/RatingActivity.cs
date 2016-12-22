using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class RatingActivity
    {
        public string EmployeId { get; set; }
        public int ActivityId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Activity Activity { get; set; }
        public float Note { get; set; }
    }
}
