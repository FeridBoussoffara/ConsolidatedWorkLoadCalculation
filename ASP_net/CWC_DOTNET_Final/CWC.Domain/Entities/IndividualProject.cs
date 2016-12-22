using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class IndividualProject: Project
    {
        [ForeignKey("Employee")]
        public string SingleEmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
