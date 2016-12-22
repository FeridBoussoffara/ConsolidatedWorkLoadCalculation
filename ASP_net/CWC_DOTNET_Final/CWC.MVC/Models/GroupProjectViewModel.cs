using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    public enum TypeProject
    {
        Individual,
        Group
    }
    
    public class GroupProjectViewModel
    {
        public int ProjectId { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public float Budget { get; set; }
        public String TypeProject { get; set; }
        public String Category { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
     

        public virtual ICollection<Employee> Employees { get; set; }

        public string TeamLeaderId { get; set; }

        [Display(Name = "Team Leader")]
        public virtual TeamLeader TeamLeader { get; set; }
        public virtual IEnumerable<SelectListItem> Employee { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}