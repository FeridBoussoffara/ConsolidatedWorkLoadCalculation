using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    public class EarningModel
    {
        public int monthNum { get; set; }
        public IEnumerable<SelectListItem> months { get; set; }

    }
}