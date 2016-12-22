using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    public class OrderPurchaseModels
    {
        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOrder { get; set; }

        [Display(Name = "Provider Name")]
        public String ProviderName { get; set; }

        [Display(Name = "Product Name")]
        public String ProductName { get; set; }

        public int ProviderId { get; set; }

        public int ProductId { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> Providers { get; set; }

    }
}