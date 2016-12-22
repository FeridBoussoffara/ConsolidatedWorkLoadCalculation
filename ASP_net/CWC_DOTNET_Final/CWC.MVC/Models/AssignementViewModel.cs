using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Models
{
    public class AssignementViewModel
    {
        public int AssignementId { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<SelectListItem> nomsEmp { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }
}