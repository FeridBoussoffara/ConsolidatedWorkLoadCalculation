using CompteServicesPattern;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CWC.Services
{
   public interface IProjectService : IService<Project>
    {
        IEnumerable<Employee> getAllEmployees();
        Employee GetTeamLeader(String idt);

        Employee GetSingleEmployee(String idt);
       
        float progressProject(int id);

        IEnumerable<Domain.Entities.Task> doneTasks(int id);

        IEnumerable<Domain.Entities.Task> allTasks(int id);
        IEnumerable<Project> getProjectInDate(DateTime start, DateTime end);
        IEnumerable<Project> getDelivredProject();

        IEnumerable<Project> getNonDelivredProject();


        IEnumerable<Project> getMostExpensiveProject();
        float MeanTaskCompletionByTeamLeader(Employee e);
        IEnumerable<ProjectBudget> Get6MostCostlyProjectsForATeamLeader(Employee e);
    }
}