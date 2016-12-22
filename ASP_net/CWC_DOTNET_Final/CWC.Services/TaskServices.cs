using CompteServicesPattern;
using CWC.Data.Infrastructure;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CWC.Services
{
   public  class TaskServices : Service<Task>, ITaskService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public TaskServices(): base(ut)
        {
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return ut.getRepository<Employee>().GetAll().ToList();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return ut.getRepository<Project>().GetAll().ToList();
        }

        public IEnumerable<Task> getdoneTasksPerEmployee(string id)
        {
            return ut.getRepository<Task>().GetMany().Where(p => p.EmployeeId == id).Where(p => p.EndDate < DateTime.Now).ToList();

        }

        public Employee GetEmployeeId(string id)
        {
            return ut.getRepository<Employee>().GetById(id);
        }

        public IEnumerable<Task> getManyTasks()
        {
            return ut.getRepository<Task>().GetAll();
        }

        public double GetMeanDurationOfTaskProject(int id)
        {
            return ut.getRepository<Task>().GetMany().Where(p => p.ProjectId.Value == id).Average((p => (p.EndDate - p.StartDate).TotalHours));

        }

        public Project GetProjectId(int id)
        {
            return ut.getRepository<Project>().GetById(id);
        }

        public IEnumerable<Task> GetTasksByPriority()
        {
            return ut.getRepository<Task>().GetAll().OrderByDescending(p => p.Priority).ToList();
        }

        public IEnumerable<Task> getTasksPerEmployee(string id)
        {
            return ut.getRepository<Task>().GetMany(p => p.EmployeeId == id).ToList();
        }

        public IEnumerable<Task> getTasksPerProject(int id)
        {
            return ut.getRepository<Task>().GetMany().Where(p => p.ProjectId.Value == id).ToList();
        }

        public IEnumerable<Task> getTasksPerProjectName(string name)
        {
            //  List<int> a 
            // return ut.getRepository<Task>().GetMany().Where(p => p.Project.Name == name).ToList();
            return ut.getRepository<Task>().GetMany(p => p.Project.Name.Contains(name)).ToList();
        }

        public IEnumerable<Task> getUndoneTasksPerEmployee(string id)
        {
            return ut.getRepository<Task>().GetMany().Where(p => p.EmployeeId == id).Where(p => p.EndDate > DateTime.Now | p.EndDate == null).ToList();
        }
    }

    public class TaskEmployee
    {
       public  String nom { get; set; }
        public double duree { get; set; }

        public double moyenne { get; set; }
    }
}
