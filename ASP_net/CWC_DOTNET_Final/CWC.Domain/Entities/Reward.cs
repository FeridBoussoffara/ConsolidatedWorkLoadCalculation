using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class Reward
    {
        public int RewardId { get; set; }
        public String RewardType { get; set; }
        public DateTime DateReward { get; set; }

        public virtual Employee Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
