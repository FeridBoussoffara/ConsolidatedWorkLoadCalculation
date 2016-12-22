using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class PaySlip
    {
        public int PaySlipId { get; set; }
        public float GrossPay { get; set; }
        public float NetPay { get; set; }
        public float Prime { get; set; }
        public virtual Employee Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
