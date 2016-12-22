using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CWC.MVC.Models
{
    public class ProviderModels
    {
        public int ProviderId { get; set; }
        public String Name { get; set; }

        [Display(Name = "Numero Telephone")]
        public String NumTel { get; set; }
        public String Email { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public String Logo { get; set; }
        public String Adresse { get; set; }
    }
}