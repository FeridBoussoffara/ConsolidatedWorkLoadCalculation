using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class Rating
    {
        public int RatingId { get; set; }
        public float Number { get; set; }
        public DateTime DateRating { get; set; }
        public virtual Employee TeamLeader { get; set; }
        public string TeamLeaderId { get; set; }
    }
}
