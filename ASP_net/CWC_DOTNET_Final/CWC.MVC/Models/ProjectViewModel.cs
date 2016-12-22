using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    [DataContract(IsReference =true)]
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DataMember]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public float Budget { get; set; }
        public String TypeProject { get; set; }
        [DataMember]
        public String Category { get; set; }
        [DataMember]
        public String Name { get; set; }
        public String State { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
    }
}