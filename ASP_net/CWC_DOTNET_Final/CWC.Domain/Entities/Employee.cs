using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace CWC.Domain.Entities
{
    public class Employee : IdentityUser
    {
        public String CIN { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime HireDate { get; set; }
        public String Photo { get; set; }
        public String Adresse { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<IndividualProject> individualProjects { get; set; }
        public virtual ICollection<Assignement> Assignements { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<PaySlip> PaySlips { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<RatingActivity> RatingActivity { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
        public virtual ERPApp ERPApp { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Employee> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
