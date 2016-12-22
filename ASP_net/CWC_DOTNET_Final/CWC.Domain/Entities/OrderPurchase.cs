using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class OrderPurchase
    {
        public int quantity { get; set; }
        public DateTime DateOrder { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
