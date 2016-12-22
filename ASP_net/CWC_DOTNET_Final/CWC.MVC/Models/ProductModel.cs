using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public String Name { get; set; } 

        [DataType(DataType.ImageUrl) ]
        public String Photo { get; set; }

         public float Price { get; set; }
        public int Quantity { get; set; }
        public String Brand { get; set; }
        
        public String Material { get; set; }
        public int WheelsNbr { get; set; }
        public int Capacity { get; set; }
        public String VehiculeType { get; set; }
        public float weight { get; set; }
        public string Category { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public String Version { get; set; }
        public String Technology { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)] 
        public DateTime ValidityDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        public string Type { get; set; } 
        public IEnumerable<SelectListItem> Types { get; set; }
        public virtual IEnumerable<Customer> Customer { get; set; }
        public virtual IEnumerable<OrderPurchase> OrderPurchases { get; set; }

        public int nbrCustomers { get; set; }
    }
}
