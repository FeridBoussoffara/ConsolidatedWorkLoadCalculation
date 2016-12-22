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
    public class ProjectController : Controller
    {
        IProjectService service = null;
        GroupProjectService gservice = null;
        EmployeeService eservice = null;
        IndividualProjectService iservice = null;
        AssignementService aservice = null;
        
        // GET: Project
        public ProjectController()
        {
            service = new ProjectService();
            gservice = new GroupProjectService();
            eservice = new EmployeeService();
            iservice = new IndividualProjectService();
            aservice = new AssignementService();
        }
        public ActionResult Index()
        {
            var proj = service.GetAll();
            List<ProjectViewModel> pvm = new List<ProjectViewModel>();
            foreach(var item in proj)
            {
              
                var projmv = new ProjectViewModel
                {
                    Name = item.Name,
                   
                    Budget = item.Budget,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ProjectId = item.ProjectId,
                    Category=item.Category.ToString(),
                    TypeProject=item.TypeProject.ToString()
                    

                };
                
                pvm.Add(projmv);
            }
            ViewBag.ClassLiDash = "nav-item";
            ViewBag.ClassspanDash = "";
            ViewBag.ClassSpan2Dash = "arrow";

            ViewBag.ClassLiprod = "nav-item";
            ViewBag.Classspanprod = "";
            ViewBag.ClassSpan2prod = "arrow";

            ViewBag.ClassLiprovd = "nav-item";
            ViewBag.Classspanprovd = "";
            ViewBag.ClassSpan2provd = "arrow";

            ViewBag.ClassLiCust = "nav-item";
            ViewBag.ClassspanCust = "";
            ViewBag.ClassSpan2Cust = "arrow";

            ViewBag.ClassLiproje = "nav-item start active open";
            ViewBag.Classspanproje = "selected";
            ViewBag.ClassSpan2proje = "arrow open";

            ViewBag.ClassLiTask = "nav-item";
            ViewBag.ClassspanTask = "";
            ViewBag.ClassSpan2Task = "arrow";

            ViewBag.ClassLiEmp = "nav-item";
            ViewBag.ClassspanEmp = "";
            ViewBag.ClassSpan2Emp = "arrow";

            return View(pvm);
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project p = service.GetById(id.Value);
            ProjectViewModel pvm = new ProjectViewModel()
            
            {
                Name = p.Name,

                Budget = p.Budget,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                ProjectId = p.ProjectId,
                Category=p.Category.ToString()

                

            };
            if(p is GroupProject)
            {
                GroupProject g = gservice.GetGroup(p.ProjectId);
                Employee tl = service.GetTeamLeader((g.TeamLeaderId));
                TeamLeader t = new TeamLeader
                {
                    Adresse = tl.Adresse,
                    CIN = tl.CIN,
                    FirstName = tl.FirstName


                };
                IEnumerable<Employee> es = new List<Employee>();
                es = aservice.getGroupEmployees(p.ProjectId);
                t.groupProjects = new List<GroupProject>() { g };
                g.TeamLeader = t;
                ViewBag.Group =g ;
                ViewBag.Type = 1;
                ViewBag.Liste = es;
            }

           else
            {
                IndividualProject g = iservice.GetIndividual(p.ProjectId);
                Employee tl = service.GetSingleEmployee((g.SingleEmployeeId));
                Employee t = new Employee()
                {
                    Adresse = tl.Adresse,
                    CIN = tl.CIN,
                    FirstName = tl.FirstName


                };
                
                g.Employee = t;
                ViewBag.Group = g;
                ViewBag.Type = 0;
            }

            if (pvm == null)
            {
                return HttpNotFound();
            }

            return View(pvm);
           /* if(p.TypeProject.ToString()=="1")
            { return RedirectToAction("Details", "GroupProjectController"); }
            return RedirectToAction("Details", "IndividualProjectController");*/
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            var projectvm = new ProjectViewModel();
            List<string> types = new List<string> { "IndividualProject", "GroupProject" };
            projectvm.Types = types.ToSelectListItems();

            return View(projectvm);
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel pvm)
        {
            Console.WriteLine(pvm.TypeProject);
            if (pvm.TypeProject=="IndividualProject")

            { return RedirectToAction("Create", "IndividualProjectController"); }
            return RedirectToAction("Create", "GroupProjectController");
           

        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project p = service.GetById(id.Value);
            ProjectViewModel pvm = new ProjectViewModel()
            {
                Name = p.Name,

                Budget = p.Budget,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                ProjectId = p.ProjectId,
                Category=p.Category.ToString()

            };

            if (pvm == null)
            {
                return HttpNotFound();
            }

            return View(pvm);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectViewModel pvm)
        {
            if (ModelState.IsValid)
            {

                Project p = service.GetById(id);
                p.Name = pvm.Name;

                p.Budget = pvm.Budget;
                p.StartDate = pvm.StartDate;
                p.EndDate = pvm.EndDate;
                
               

                service.Update(p);
                service.Commit();

                return RedirectToAction("Index");
            }
            return View(pvm);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        { if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Project p = service.GetById(id.Value);
            ProjectViewModel pvm = new ProjectViewModel()
    {
                Name = p.Name,

                Budget = p.Budget,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                ProjectId = p.ProjectId,
                Category=p.Category.ToString()

            };

            if (pvm == null)
            {
                return HttpNotFound();
}

            return View(pvm);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, ProjectViewModel pvm)
        {
            Project p = service.GetById(id.Value);
            service.Delete(p);
            service.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Progress(int id)
        {
            ViewBag.done = service.doneTasks(id);
            ViewBag.all = service.allTasks(id);
            ViewBag.pourcentage = service.progressProject(id);
            ViewBag.ma = aservice.MostActiveEmployee().FirstName;
            return View();
        }

        public ActionResult MostActiveEmp()
        {
            ViewBag.most = aservice.MostActiveEmployee().FirstName;
            ViewBag.proj = aservice.GetByIdString(aservice.MostActiveEmployee().Id);
            return View();
        }
        public ActionResult AssignEmployee()
        {
            AssignementViewModel avm = new AssignementViewModel();
            IEnumerable<Employee> employees = new List<Employee>() ;
            avm.nomsEmp=service.getAllEmployees().ToSelectListItemsEmployee();
            //AssignementViewModel a = new AssignementViewModel()
            //{
            //    ProjectId = avm.ProjectId,
            //};
            //List<String> ls = new List<string>();
            //ls = employees.Select(p => p.FirstName).ToList();
            //ViewBag.ls= ls.ToSelectListItems();
            //avm.nomsEmp = ls.ToSelectListItems();
            
            return View(avm);
        }
        [HttpPost]
        public ActionResult AssignEmployee(AssignementViewModel avm, int id)
        {
            //Assignement a = new Assignement()
            //{
            //    EmployeeId = avm.EmployeeId,
            //    ProjectId = avm.ProjectId,
            //    DateIn = DateTime.Now
            //};
            aservice.AssignProjectToEmployee(avm.EmployeeId, id);
            aservice.Commit();
            return RedirectToAction("Index");
            

        }

      
        public ActionResult ProjectInGivenTime(String From, String To)
        {
            DateTime fromd = Convert.ToDateTime(From);
            DateTime tod = Convert.ToDateTime(To);
            ViewBag.projet = service.getProjectInDate(fromd, tod);
            return View();
        }
        public ActionResult DelivredProject()
        {
            ViewBag.delproj = service.getDelivredProject();
            return View();
        }
        public ActionResult NonDelivredProject()
        {
            ViewBag.nondelproj = service.getNonDelivredProject();
            return View();
        }
        public ActionResult MostExpensiveProject()
        {
            ViewBag.expproj = service.getMostExpensiveProject();
            return View();
        }

    }
}
