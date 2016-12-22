using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
 public class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        virtual public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
