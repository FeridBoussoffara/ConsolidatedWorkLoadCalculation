using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class Product
    {
        public int ProductId { get; set; }
        public String Name { get; set; } 
        public String Photo { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
         public virtual ICollection<OrderPurchase> OrderPurchases { get; set; }   
        public virtual ICollection<OrderSale> OrderSales { get; set; }

        public Product()
        {
            OrderSales = new List<OrderSale>();
            OrderPurchases = new List<OrderPurchase>();

        }
    }
    

}
