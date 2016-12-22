using CWC.Domain.Entities;
using CWC.MVC.Helpers;
using CWC.MVC.Models;
using CWC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TasksController : Controller
    { 
        ITaskService Service=null;
        public  TasksController() {
            Service = new TaskServices();
            }

        // GET: Tasks
        public ActionResult Index()

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
                        TaskId=item.TaskId,
                        DeadLine=item.DeadLine,
                        StartDate=item.StartDate,
                        Name=item.Name,
                        Priority=item.Priority,
                        EndDate=item.EndDate,
                        State=item.State,
                        ProjectId=item.ProjectId,
                        NomProject  =c.Name,
                        NomEmployee=e.FirstName+" "+e.LastName,
                        MeanDuration= Service.GetMeanDurationOfTaskProject(item.ProjectId.Value),
                        EmployeeId=e.Id
            }
                    );
                

            }


            ViewBag.ClassLiDash = "nav-item";
            ViewBag.ClassspanDash = "";
            ViewBag.ClassSpan2Dash = "arrow";

            ViewBag.ClassLiprod = "nav-item";
            ViewBag.Classspanprod = "";
            ViewBag.ClassSpan2prod = "arrow open";

            ViewBag.ClassLiprovd = "nav-item";
            ViewBag.Classspanprovd = "";
            ViewBag.ClassSpan2provd = "arrow";

            ViewBag.ClassLiCust = "nav-item";
            ViewBag.ClassspanCust = "";
            ViewBag.ClassSpan2Cust = "arrow";

            ViewBag.ClassLiproje = "nav-item";
            ViewBag.Classspanproje = "";
            ViewBag.ClassSpan2proje = "arrow";

            ViewBag.ClassLiTask = "nav-item start active open";
            ViewBag.ClassspanTask = "selected";
            ViewBag.ClassSpan2Task = "arrow open";

            ViewBag.ClassLiEmp = "nav-item";
            ViewBag.ClassspanEmp = "";
            ViewBag.ClassSpan2Emp = "arrow";
            return View(tvm);
        }

        [HttpPost]
        public ActionResult Index(String searchString)

        {
            var ta = Service.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                ta = null;
               ta = Service.getTasksPerProjectName(searchString);
            }
          
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
            return View(tvm);
        }


        public ActionResult TaskPriority()

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
                        NomEmployee = e.FirstName + " " + e.LastName
                    }
                    );


            }
            return View(tvm);
        }



        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task t = Service.GetById(id.Value);
            Project c = Service.GetProjectId(t.ProjectId.Value);
            TasksViewModel ts = new TasksViewModel
            {
                DeadLine = t.DeadLine,
                EndDate = t.EndDate,
                Name = t.Name,
                Priority = t.Priority,
                State = t.State,
                StartDate = t.StartDate,
                TaskId=t.TaskId,
                NomProject=c.Name
                
               

            };
            if (ts == null)
            {
                return HttpNotFound();
            }
            return View(ts);
        }

       





        // GET: Tasks/Create
        public ActionResult Create()
        {
            var TasksVM = new TasksViewModel();
            TasksVM.Project = Service.GetAllProjects().ToSelectListItemsProject();
            TasksVM.Employee = Service.GetAllEmployee().ToSelectListItemsEmployee();

          

            return View(TasksVM);
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(TasksViewModel vm)
        {
            Task t = new Task
            {
                StartDate=vm.StartDate,
                DeadLine=vm.DeadLine,
                Name=vm.Name,
                Priority=vm.Priority,
                EndDate=vm.EndDate,
                ProjectId=vm.ProjectId,
                State=true,
                EmployeeId=vm.EmployeeId
                

            };
            Service.Add(t);
            Service.Commit();
             return RedirectToAction("Index");
           

        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id ==null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task t = Service.GetById(id.Value);
            TasksViewModel ts = new TasksViewModel
            {
                DeadLine = t.DeadLine,
                EndDate = t.EndDate,
                Name = t.Name,
                Priority = t.Priority,
                StartDate = t.StartDate

            };
            if (ts == null)
            {
                return HttpNotFound();
            }
            return View(ts);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,TasksViewModel pp, FormCollection collection)
        {
           if (ModelState.IsValid)
            {
                Task p = Service.GetById(id);
                p.Name = pp.Name;
                p.Priority = pp.Priority;
                p.StartDate = pp.StartDate;
                p.EndDate = pp.EndDate;
                p.DeadLine = pp.DeadLine;
                Service.Update(p);
                Service.Commit();
                return RedirectToAction("Index");
            }
            return View(pp);
        }


        
        public ActionResult TasksPerEmployee(String id)

        {
             String idd = id.ToString();
          
            
               var ta = Service.getTasksPerEmployee(idd);
            List<TaskEmployee> mychart = new List<TaskEmployee>();


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
                mychart.Add(new TaskEmployee
                {
                    nom=item.Name,
                    duree= (item.EndDate - item.StartDate).TotalHours,
                    moyenne= Service.GetMeanDurationOfTaskProject(item.ProjectId.Value)
                });


            }
            Employee titre = Service.GetEmployeeId(idd);
            ViewBag.nom = titre.FirstName + " " + titre.LastName;



            ViewBag.mychart = mychart;
            ViewBag.employee = idd;

            return View(tvm);
        }



        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task t = Service.GetById(id.Value);
            TasksViewModel ts = new TasksViewModel {
                DeadLine=t.DeadLine,
               EndDate=t.EndDate,
               Name=t.Name,
               Priority=t.Priority,
               State=t.State,StartDate=t.StartDate 
               
            };
            if (ts==null)
            {
                return HttpNotFound();
            }
            return View(ts);
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            Task t = Service.GetById(id.Value);
            Service.Delete(t);
            Service.Commit();
            return RedirectToAction("Index");
        }

        
        public ActionResult Chart()


        {

            List<int> priorite = new List<int>();
            List<String> nom = new List<string>();

            List<Task> tasks = Service.GetAll().ToList();

            foreach(var task in tasks)
            {
                nom.Add(task.Name.ToString());
                priorite.Add(task.Priority);
            }


           // List<int> a = new List<int>() { 1,2,4};
            
            string[] ss = new string[nom.Count];
            int i = 0;
            foreach (var item in nom)
            {
                ss[i] = item;
                i++;

            }


            new System.Web.Helpers.Chart(width: 700, height: 500).AddSeries(
              
        chartType: "column",
        xValue: ss,
        yValues: new[] { priorite },legend:  "Priorities per Tasks" 
        ).Write("png");
            return null;
        }

     
    public ActionResult ExportToExcel()
        {
            var Tasks = new System.Data.DataTable("teste");
            List<Task> ltasks = Service.GetAll().ToList();
            Tasks.Columns.Add("TaskId", typeof(int));
            
            Tasks.Columns.Add("Name", typeof(string));
            Tasks.Columns.Add("Priority", typeof(int));

            Tasks.Columns.Add("Startdate", typeof(string));
            Tasks.Columns.Add("Enddate", typeof(string));
            Tasks.Columns.Add("Deadline", typeof(string));
            Tasks.Columns.Add("Project", typeof(string));
            Tasks.Columns.Add("Employee Lastname", typeof(string));
            Tasks.Columns.Add("Employee Firstname", typeof(string));
            
            foreach (var item in ltasks)
            {
                 Tasks.Rows.Add(item.TaskId, item.Name, item.Priority, item.StartDate.ToString(), item.EndDate.ToString(), item.DeadLine.ToString(), item.Project.Name, item.Employee.LastName, item.Employee.FirstName);
                

            }


            var products = new System.Data.DataTable("teste");
            products.Columns.Add("col1", typeof(int));
            products.Columns.Add("col2", typeof(string));

            products.Rows.Add(1, "product 1");
            products.Rows.Add(2, "product 2");
            products.Rows.Add(3, "product 3");
            products.Rows.Add(4, "product 4");
            products.Rows.Add(5, "product 5");
            products.Rows.Add(6, "product 6");
            products.Rows.Add(7, "product 7");


            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = Tasks;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View("MyView");
        }


        public ActionResult getdoneTasksPerEmployee(String id)
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
            Employee titre = Service.GetEmployeeId(idd);
            ViewBag.nom = titre.FirstName + " " + titre.LastName;

            return View(tvm);

        }
    }
}