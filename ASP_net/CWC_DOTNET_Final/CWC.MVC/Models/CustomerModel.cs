using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CWC.MVC.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Photo { get; set; }
        public String Type { get; set; }
        public String Adresse { get; set; }
        public virtual IEnumerable<OrderSale> OrderSales { get; set; }

    }
}