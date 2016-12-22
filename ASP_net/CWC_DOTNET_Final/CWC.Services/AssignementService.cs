using CompteServicesPattern;
using CWC.Data.Infrastructure;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
    public class AssignementService : Service<Assignement>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        EmployeeService es = new EmployeeService();
        ProjectService service = new ProjectService();
        public AssignementService() : base(ut)
        {

        }
        public IEnumerable<Employee> getGroupEmployees(int id)
        {
            var e = ut.getRepository<Assignement>().GetMany(a => a.Project.ProjectId == id).Select(a => a.EmployeeId).ToList();
            //IEnumerable<Assignement> a= ut.getRepository<Assignement>().GetMany(p=>p.ProjectId==id).ToList();
            //return ut.getRepository<Employee>().GetMany(p => p.Assignements.SelectMany(b=>b.AssignementId==a.Select(a=>a.AssignementId) ).ToList();
            ICollection<Employee> elist = new List<Employee>();
            foreach (var item in e)
            {
                var h = service.GetTeamLeader(item);
                elist.Add(h);
            }
            return elist.AsEnumerable();

        }
        public Employee MostActiveEmployee()
        {
            var e = ut.getRepository<Assignement>().GetAll().Select(a => a.Employee).GroupBy(p => p.Id).OrderByDescending(p => p.Key).First();

            return service.GetSingleEmployee(e.Key);


        }
        public IEnumerable<Project> GetByIdString(String id)
        { List<Project> elist = new List<Project>();
            List<Assignement> m = ut.getRepository<Assignement>().GetAll().Where(p => p.EmployeeId == id).ToList();

            foreach (var item in m)
            {
                var h = service.GetById(item.ProjectId);
                elist.Add(h);
            }
            return elist.AsEnumerable();


        }

        public void AssignProjectToEmployee(String ide, int idp)
        {
            Assignement a = new Assignement
            {
                ProjectId = idp,
                EmployeeId = ide,
                DateIn = DateTime.Now

        };
            ut.getRepository<Assignement>().Add(a);
        }
    }
}
