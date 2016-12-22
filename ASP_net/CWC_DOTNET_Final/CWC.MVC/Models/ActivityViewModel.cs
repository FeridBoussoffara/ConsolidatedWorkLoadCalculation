using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    public class ActivityViewModel
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateActivity { get; set; }
        public string TrainerId { get; set; }
        public IEnumerable<SelectListItem> Trainers;

    }
}