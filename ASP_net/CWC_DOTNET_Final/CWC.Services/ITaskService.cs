using CompteServicesPattern;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CWC.Services
{
   public interface ITaskService : IService<Task>
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProjectId(int id);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeId(String id);
        IEnumerable<Task> GetTasksByPriority();
        double GetMeanDurationOfTaskProject(int id);
        IEnumerable<Task> getTasksPerProject(int id);

        IEnumerable<Task> getUndoneTasksPerEmployee(String id);

        IEnumerable<Task> getTasksPerProjectName(String name);

        IEnumerable<Task> getTasksPerEmployee(String id);

        IEnumerable<Task> getdoneTasksPerEmployee(String id);
        IEnumerable<Task> getManyTasks();



    }
}
