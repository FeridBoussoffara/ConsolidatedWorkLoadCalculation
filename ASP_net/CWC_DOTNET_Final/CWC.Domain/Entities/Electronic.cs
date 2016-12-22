using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
  public  class Electronic: Product
    {
        public String Brand { get; set; } 
        public float weightElec { get; set; }
    }
}
