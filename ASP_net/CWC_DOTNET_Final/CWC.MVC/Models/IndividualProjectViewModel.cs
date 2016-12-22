using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CWC.MVC.Models
{
    public class IndividualProjectViewModel
    {
        public int ProjectId { get; set; }
        [Display(Name="Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name ="End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public float Budget { get; set; }
        public String TypeProject { get; set; }
        public String Category { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
        [Display(Name="Employee")]
        public string SingleEmployeeId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public virtual IEnumerable<SelectListItem> Employee { get; set; }
    }
}