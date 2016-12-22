using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public enum TypeProject
    {
        Individual,
        Group
    }
    public enum CategoryProject
    {
        IT,
        Agriculture,
        Construction,
        Business,
        Finance
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Budget { get; set; }
        public TypeProject TypeProject { get; set; }
        public CategoryProject Category { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
       
        public virtual ICollection<Task> Tasks { get; set; }

       



    }
}
