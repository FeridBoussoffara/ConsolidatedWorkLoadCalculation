using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    public class TasksViewModel
    {
        public int TaskId { get; set; }
        [Required]
        public String Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Deadline Date")]
        public DateTime DeadLine { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Startdate")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Enddate")]
       
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Priority { get; set; }

        public bool State { get; set; }
        [Display(Name = "Project")]
        public int? ProjectId { get; set; }
        public  IEnumerable<SelectListItem>  Project { get; set; }
        [Display(Name = "Project")]
        public String NomProject { get; set; }

        public String EmployeeId { get; set; }
        public IEnumerable<SelectListItem> Employee { get; set; }
        [Display(Name = "Employee")]
        public String NomEmployee { get; set; }
        [Display(Name = "Mean Duration.current project")]
        public double MeanDuration { get; set; }

    }
}