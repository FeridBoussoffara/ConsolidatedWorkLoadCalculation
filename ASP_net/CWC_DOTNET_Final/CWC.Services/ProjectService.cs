using CompteServicesPattern;
using CWC.Data.Infrastructure;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
   public class ProjectService :Service<Project>, IProjectService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ProjectService() : base(ut)
        {

        }

       public IEnumerable<Employee> getAllEmployees()
        {
            return ut.getRepository<Employee>().GetAll().ToList();
        }
        public Employee GetTeamLeader(String idt)
        {
            return ut.getRepository<Employee>().GetMany(p => p.Id.Equals(idt)).FirstOrDefault();
        }
        public Employee GetSingleEmployee(String idt)
        {
            return ut.getRepository<Employee>().GetMany(p => p.Id.Equals(idt)).FirstOrDefault();
        }

        public float progressProject(int id)
        {
            float pt = ut.getRepository<Domain.Entities.Task>().GetMany(p => p.ProjectId == id).Count();
            float pp = ut.getRepository<Domain.Entities.Task>().GetMany(p => p.ProjectId == id && p.EndDate<DateTime.Now).Count();
            var po =(pp / pt) * 100;
            return po;

        }
        public IEnumerable<Domain.Entities.Task> doneTasks(int id)
        {
            return ut.getRepository<Domain.Entities.Task>().GetMany(p => p.ProjectId == id && p.EndDate < DateTime.Now).ToList();
        }
        public IEnumerable<Domain.Entities.Task> allTasks(int id)
        {
            return ut.getRepository<Domain.Entities.Task>().GetMany(p => p.ProjectId == id).ToList();
        }

        public IEnumerable<Project> getProjectInDate(DateTime start, DateTime end)
        {
            return ut.getRepository<Project>().GetMany(p => p.StartDate >= start && p.EndDate <= end).ToList();
        }
        public IEnumerable<Project> getDelivredProject()
        {
            return ut.getRepository<Project>().GetMany(p => p.EndDate <= DateTime.Now).ToList();
        }
        public IEnumerable<Project> getNonDelivredProject()
        {
            return ut.getRepository<Project>().GetMany(p => p.EndDate > DateTime.Now).ToList();

        }
        public IEnumerable<Project> getMostExpensiveProject()
        {
            return ut.getRepository<Project>().GetAll().OrderByDescending(p => p.Budget).Take(3).ToList();
        }
        public float MeanTaskCompletionByTeamLeader(Employee e)
        {
            var tasks = GetAll()
                .Cast<GroupProject>()
                .Select(GP => GP)
                .ToList()
                .Where(GP => GP.TeamLeaderId == e.Id)
                .ToList()
                .SelectMany(GP => GP.Tasks)
                .ToList();
            float fini = tasks.Where(T => T.State).Count();
            float total = tasks.Count();
            float pourcentage = (fini / total) * 100;
            return pourcentage;
        }
        public IEnumerable<ProjectBudget> Get6MostCostlyProjectsForATeamLeader(Employee e)
        {
            return GetAll()
                .Cast<GroupProject>()
                .Where(GP => GP.TeamLeaderId == e.Id)
                .ToList()
                .OrderByDescending(GP => GP.Budget)
                .Take(6)
                .Select(GP => new ProjectBudget
                {
                    ProjectName = GP.Name,
                    Budget = GP.Budget
                }).ToList();
        }
    }
    [DataContract(IsReference = true)]
    public class ProjectBudget
    {
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public float Budget { get; set; }
    }
}
