using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class Software: Product
    {
        public String Version { get; set; }
        public String Technology { get; set; }

    }
}
