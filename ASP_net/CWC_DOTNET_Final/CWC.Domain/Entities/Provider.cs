using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class Provider
    {

        public int ProviderId { get; set; }
        public String Name { get; set; }

        public String NumTel { get; set; }
        public String Email { get; set; }

        public String Logo { get; set; }
        public String Adresse { get; set; }
        public virtual ICollection<OrderPurchase> OrderPurchases { get; set; }

        public Provider()
        {
            OrderPurchases = new List<OrderPurchase>() ;
        }
    }
}
