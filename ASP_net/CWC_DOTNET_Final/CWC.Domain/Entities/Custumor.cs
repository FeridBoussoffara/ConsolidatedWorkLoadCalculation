using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CWC.Domain.Entities

{
    public class Customer
    {
        public int CustomerId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Photo { get; set; }
        public String Type { get; set; }
        public String Adresse { get; set; }
         public virtual ICollection<OrderSale> OrderSales { get; set; }

        public Customer()
        {
            OrderSales = new List<OrderSale>();
        }

    }
}