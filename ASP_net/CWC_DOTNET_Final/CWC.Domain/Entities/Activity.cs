using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        public DateTime DateActivity { get; set; }
        public virtual Employee Trainor { get; set; }
        public string TrainerId { get; set; }

        public virtual ICollection<RatingActivity> RatingActivity { get; set; }
    }
}
