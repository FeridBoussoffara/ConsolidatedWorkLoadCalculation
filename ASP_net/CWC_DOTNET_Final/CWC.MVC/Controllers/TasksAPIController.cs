using CWC.Domain.Entities;
using CWC.MVC.Models;
using CWC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CWC.MVC.Controllers
{
    public class TasksAPIController : ApiController
    {
        TaskServices Service = new TaskServices();




        // GET: api/TasksAPI
        public List<TasksViewModel> Get()
        {
            var ta = Service.GetAll();
            List<TasksViewModel> tvm = new List<TasksViewModel>();
            foreach (var item in ta)
            {

                Project c = Service.GetProjectId(item.ProjectId.Value);
                List<Employee> le = Service.GetAllEmployee().ToList();
                // foreach (var test in le  ) { if (test.Id==item.EmployeeId) {  n = test.FirstName + " " + test.LastName; } }

                Employee e = Service.GetEmployeeId(item.EmployeeId);
                tvm.Add(
                    new TasksViewModel
                    {
                        TaskId = item.TaskId,
                        DeadLine = item.DeadLine,
                        StartDate = item.StartDate,
                        Name = item.Name,
                        Priority = item.Priority,
                        EndDate = item.EndDate,
                        State = item.State,
                        ProjectId = item.ProjectId,
                        NomProject = c.Name,
                        NomEmployee = e.FirstName + " " + e.LastName,
                        MeanDuration = Service.GetMeanDurationOfTaskProject(item.ProjectId.Value),
                        EmployeeId = e.Id
                    }
                    );


            }
            return tvm;
        }

        // GET: api/TasksAPI/5
        public TasksViewModel Get(int id)
        {
         
            Task t = Service.GetById(id);
            Project c = Service.GetProjectId(t.ProjectId.Value);
            Employee e = Service.GetEmployeeId(t.EmployeeId);
            TasksViewModel ts = new TasksViewModel
            {
                DeadLine = t.DeadLine,
                EndDate = t.EndDate,
                Name = t.Name,
                Priority = t.Priority,
                State = t.State,
                StartDate = t.StartDate,
                TaskId = t.TaskId,
                NomProject = c.Name,
                 NomEmployee = e.FirstName + " " + e.LastName,
                MeanDuration = Service.GetMeanDurationOfTaskProject(t.ProjectId.Value),
                EmployeeId=t.EmployeeId,
                ProjectId=t.ProjectId




            };
          
            return ts;
        }

        // POST: api/TasksAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TasksAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TasksAPI/5
        public void Delete(int id)
        {
        }

        public List<TasksViewModel> getTasksPerEmployee(String id)
        {
            String idd = id.ToString();


            var ta = Service.getTasksPerEmployee(idd);
          


            List<TasksViewModel> tvm = new List<TasksViewModel>();
            foreach (var item in ta)
            {

                Project c = Service.GetProjectId(item.ProjectId.Value);
                //  List<Employee> le = Service.GetAllEmployee().ToList();
                // foreach (var test in le  ) { if (test.Id==item.EmployeeId) {  n = test.FirstName + " " + test.LastName; } }

                Employee e = Service.GetEmployeeId(item.EmployeeId);
                tvm.Add(
                    new TasksViewModel
                    {
                        TaskId = item.TaskId,
                        DeadLine = item.DeadLine,
                        StartDate = item.StartDate,
                        Name = item.Name,
                        Priority = item.Priority,
                        EndDate = item.EndDate,
                        State = item.State,
                        ProjectId = item.ProjectId,
                        NomProject = c.Name,
                        NomEmployee = e.FirstName + " " + e.LastName,
                        MeanDuration = Service.GetMeanDurationOfTaskProject(item.ProjectId.Value)
                        
                    }
                    );
                //te.nom = item.Name;
                //te.duree = (item.EndDate - item.StartDate).TotalHours;
             


            }
        

            return tvm;

        }

        public List<TasksViewModel> getTasksPerProject(int id)
        {
            


            var ta = Service.getTasksPerProject(id);



            List<TasksViewModel> tvm = new List<TasksViewModel>();
            foreach (var item in ta)
            {

                Project c = Service.GetProjectId(item.ProjectId.Value);
                //  List<Employee> le = Service.GetAllEmployee().ToList();
                // foreach (var test in le  ) { if (test.Id==item.EmployeeId) {  n = test.FirstName + " " + test.LastName; } }

                Employee e = Service.GetEmployeeId(item.EmployeeId);
                tvm.Add(
                    new TasksViewModel
                    {
                        TaskId = item.TaskId,
                        DeadLine = item.DeadLine,
                        StartDate = item.StartDate,
                        Name = item.Name,
                        Priority = item.Priority,
                        EndDate = item.EndDate,
                        State = item.State,
                        ProjectId = item.ProjectId,
                        NomProject = c.Name,
                        NomEmployee = e.FirstName + " " + e.LastName,
                        MeanDuration = Service.GetMeanDurationOfTaskProject(item.ProjectId.Value)

                    }
                    );
                //te.nom = item.Name;
                //te.duree = (item.EndDate - item.StartDate).TotalHours;



            }


            return tvm;

        }


        public List<TasksViewModel> getTasksPerProjectName(string name)
        {



            var ta = Service.getTasksPerProjectName(name);



            List<TasksViewModel> tvm = new List<TasksViewModel>();
            foreach (var item in ta)
            {

                Project c = Service.GetProjectId(item.ProjectId.Value);
                //  List<Employee> le = Service.GetAllEmployee().ToList();
                // foreach (var test in le  ) { if (test.Id==item.EmployeeId) {  n = test.FirstName + " " + test.LastName; } }

                Employee e = Service.GetEmployeeId(item.EmployeeId);
                tvm.Add(
                    new TasksViewModel
                    {
                        TaskId = item.TaskId,
                        DeadLine = item.DeadLine,
                        StartDate = item.StartDate,
                        Name = item.Name,
                        Priority = item.Priority,
                        EndDate = item.EndDate,
                        State = item.State,
                        ProjectId = item.ProjectId,
                        NomProject = c.Name,
                        NomEmployee = e.FirstName + " " + e.LastName,
                        MeanDuration = Service.GetMeanDurationOfTaskProject(item.ProjectId.Value)

                    }
                    );
                //te.nom = item.Name;
                //te.duree = (item.EndDate - item.StartDate).TotalHours;



            }


            return tvm;

        }

        public double GetMeanDurationTasksPerProject(int id )
        {

            return Service.GetMeanDurationOfTaskProject(id);
        }
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public List<TasksViewModel> OrderTasksByPriority()
        {
            var ta = Service.GetTasksByPriority();
            List<TasksViewModel> tvm = new List<TasksViewModel>();
            foreach (var item in ta)
            {

                Project c = Service.GetProjectId(item.ProjectId.Value);
                List<Employee> le = Service.GetAllEmployee().ToList();
                // foreach (var test in le  ) { if (test.Id==item.EmployeeId) {  n = test.FirstName + " " + test.LastName; } }

                Employee e = Service.GetEmployeeId(item.EmployeeId);
                tvm.Add(
                    new TasksViewModel
                    {
                        TaskId = item.TaskId,
                        DeadLine = item.DeadLine,
                        StartDate = item.StartDate,
                        Name = item.Name,
                        Priority = item.Priority,
                        EndDate = item.EndDate,
                        State = item.State,
                        ProjectId = item.ProjectId,
                        NomProject = c.Name,
                        NomEmployee = e.FirstName + " " + e.LastName,
                        MeanDuration = Service.GetMeanDurationOfTaskProject(item.ProjectId.Value),
                        EmployeeId = e.Id
                    }
                    );


            }
            return tvm;
        }

        public List<TasksViewModel> getUndoneTasksPerEmployee(String id)
        {
            String idd = id.ToString();


            var ta = Service.getUndoneTasksPerEmployee(idd);



            List<TasksViewModel> tvm = new List<TasksViewModel>();
            foreach (var item in ta)
            {

                Project c = Service.GetProjectId(item.ProjectId.Value);
                //  List<Employee> le = Service.GetAllEmployee().ToList();
                // foreach (var test in le  ) { if (test.Id==item.EmployeeId) {  n = test.FirstName + " " + test.LastName; } }

                Employee e = Service.GetEmployeeId(item.EmployeeId);
                tvm.Add(
                    new TasksViewModel
                    {
                        TaskId = item.TaskId,
                        DeadLine = item.DeadLine,
                        StartDate = item.StartDate,
                        Name = item.Name,
                        Priority = item.Priority,
                        EndDate = item.EndDate,
                        State = item.State,
                        ProjectId = item.ProjectId,
                        NomProject = c.Name,
                        NomEmployee = e.FirstName + " " + e.LastName,
                        MeanDuration = Service.GetMeanDurationOfTaskProject(item.ProjectId.Value)

                    }
                    );
                //te.nom = item.Name;
                //te.duree = (item.EndDate - item.StartDate).TotalHours;



            }


            return tvm;

        }


        public List<TasksViewModel> getdoneTasksPerEmployee(String id)
        {
            String idd = id.ToString();


            var ta = Service.getdoneTasksPerEmployee(idd);



            List<TasksViewModel> tvm = new List<TasksViewModel>();
            foreach (var item in ta)
            {

                Project c = Service.GetProjectId(item.ProjectId.Value);
                //  List<Employee> le = Service.GetAllEmployee().ToList();
                // foreach (var test in le  ) { if (test.Id==item.EmployeeId) {  n = test.FirstName + " " + test.LastName; } }

                Employee e = Service.GetEmployeeId(item.EmployeeId);
                tvm.Add(
                    new TasksViewModel
                    {
                        TaskId = item.TaskId,
                        DeadLine = item.DeadLine,
                        StartDate = item.StartDate,
                        Name = item.Name,
                        Priority = item.Priority,
                        EndDate = item.EndDate,
                        State = item.State,
                        ProjectId = item.ProjectId,
                        NomProject = c.Name,
                        NomEmployee = e.FirstName + " " + e.LastName,
                        MeanDuration = Service.GetMeanDurationOfTaskProject(item.ProjectId.Value)

                    }
                    );
                //te.nom = item.Name;
                //te.duree = (item.EndDate - item.StartDate).TotalHours;



            }


            return tvm;

        }


    }
}
