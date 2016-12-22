using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public enum TypeApp { Banking , Agriculture,ComputerServices ,Company}
    public class ERPApp
    {
        public int ERPAppId { get; set; }
        public String Name { get; set; }
        public String fonder { get; set; }
        public String logo { get; set; }
        public TypeApp type { get; set; }
        public virtual Employee Administrator { get; set; }
    }
}
