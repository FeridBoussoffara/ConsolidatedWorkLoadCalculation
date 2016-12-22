using CWC.Domain.Entities;
using CWC.MVC.Helpers;
using CWC.MVC.Models;
using CWC.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class EmployeeController : Controller
    {
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;
        private IActivityService AS;
        private IProjectService PS;
        public EmployeeController(ApplicationRoleManager roleManager, ApplicationUserManager userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
            AS = new ActivityService();
        }
        public EmployeeController()
        {
            AS = new ActivityService();
            PS = new ProjectService();
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<RegisterViewModel> RVMs = new List<RegisterViewModel>();
            var users = UserManager.Users.ToList();
            foreach (var Employee in users)
            {
                var roles = UserManager.GetRoles(Employee.Id).ToList();
                Console.WriteLine(Employee.Id);

                RVMs.Add(new RegisterViewModel
                {
                    Id = Employee.Id,
                    CIN = Employee.CIN,
                    Adresse = Employee.Adresse,
                    UserName = Employee.UserName,
                    Email = Employee.Email,
                    Photo = Employee.Photo,
                    EmployeeType = roles.FirstOrDefault()

                });
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

            ViewBag.ClassLiTask = "nav-item";
            ViewBag.ClassspanTask = "";
            ViewBag.ClassSpan2Task = "arrow";

            ViewBag.ClassLiEmp = "nav-item start active open";
            ViewBag.ClassspanEmp = "selected";
            ViewBag.ClassSpan2Emp = "arrow open";
            return View(RVMs);
        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            var E = UserManager.FindById(id);
            RegisterViewModel RVM = new RegisterViewModel
            {
                Id = E.Id,
                Email = E.Email,
                CIN = E.CIN,
                Adresse = E.Adresse,
                HireDate = E.HireDate,
                LastName = E.LastName,
                FirstName = E.FirstName,
                Photo = E.Photo
            };
            if (UserManager.IsInRole(E.Id, "Trainer"))
            {
                IEnumerable<ActivitiesPerMonth> APMs = AS.GetActivitiesByYearAndTrainerPerMonth(2014, E);
                List<string> monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList();
                ViewBag.APM = APMs;
                return View("DetailsTrainer", RVM);
            }
            else
            {
                IEnumerable<ProjectBudget> PBs = PS.Get6MostCostlyProjectsForATeamLeader(E);
                ViewBag.PBs = PBs;
                ViewBag.Mean = PS.MeanTaskCompletionByTeamLeader(E);
                return View("DetailsTeamLeader", RVM);
            }


        }
        // GET: Employee/Create
        public ActionResult Create()
        {
            RegisterViewModel RVM = new RegisterViewModel();
            List<string> types = new List<string>();
            foreach (var item in RoleManager.Roles)
            {
                types.Add(item.Name);
            }
            RVM.EmployeeTypes = types.ToSelectListItems();
            return View(RVM);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(RegisterViewModel RVM, HttpPostedFileBase Image)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    RedirectToAction("Create");
                }
                RVM.Photo = Image.FileName;
                Employee E = new Employee();
                Console.WriteLine("Type:" + RVM.EmployeeType);
                switch (RVM.EmployeeType)
                {
                    case "Employee":
                        {
                            E = new Employee
                            {
                                Email = RVM.Email,
                                CIN = RVM.CIN,
                                FirstName = RVM.FirstName,
                                LastName = RVM.LastName,
                                HireDate = RVM.HireDate,
                                Photo = RVM.Photo,
                                Adresse = RVM.Adresse,
                                UserName = RVM.FirstName + " " + RVM.LastName
                            };
                            break;
                        }
                    case "TeamLeader":
                        {
                            E = new TeamLeader
                            {
                                Email = RVM.Email,
                                CIN = RVM.CIN,
                                FirstName = RVM.FirstName,
                                LastName = RVM.LastName,
                                HireDate = RVM.HireDate,
                                Photo = RVM.Photo,
                                Adresse = RVM.Adresse,
                                UserName = RVM.FirstName + " " + RVM.LastName
                            };
                            break;
                        }
                    case "Trainer":
                        {
                            E = new Trainor
                            {
                                Email = RVM.Email,
                                CIN = RVM.CIN,
                                FirstName = RVM.FirstName,
                                LastName = RVM.LastName,
                                HireDate = RVM.HireDate,
                                Photo = RVM.Photo,
                                Adresse = RVM.Adresse,
                                UserName = RVM.FirstName + " " + RVM.LastName
                            };
                            break;
                        }

                }
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);
                var result = UserManager.Create(E, RVM.Password);

                if (result.Succeeded)
                {
                    var currentUser = UserManager.FindByName(E.UserName);

                    var roleresult = UserManager.AddToRole(currentUser.Id, RVM.EmployeeType);
                }
                return RedirectToAction("Index");
            }

            catch
            {
                Console.WriteLine("Fail");
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            var E = UserManager.FindById(id);
            RegisterViewModel RVM = new RegisterViewModel
            {
                Email = E.Email,
                CIN = E.CIN,
                Adresse = E.Adresse,
                HireDate = E.HireDate,
                LastName = E.LastName,
                FirstName = E.FirstName,
                Photo = E.Photo
            };
            return View(RVM);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, RegisterViewModel RVM, HttpPostedFileBase Image)
        {
            var E = UserManager.FindById(id);
            E.Adresse = RVM.Adresse;
            E.Email = RVM.Email;
            E.CIN = RVM.CIN;
            E.Adresse = RVM.Adresse;
            E.HireDate = RVM.HireDate;
            E.LastName = RVM.LastName;
            E.FirstName = RVM.FirstName;
            if (Image != null)
                E.Photo = Image.FileName;
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            var result = UserManager.Update(E);
            if (result.Succeeded)
                Image.SaveAs(path);
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string id)
        {
            Employee E = UserManager.FindById(id);
            UserManager.Delete(E);
            return RedirectToAction("Index");
        }
        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult GetNumberActivitiesPerMonthByEmployee(string id)
        {
            var E = UserManager.FindById(id);
            IEnumerable<ActivitiesPerMonth> APMs = AS.GetActivitiesByYearAndTrainerPerMonth(2014, E);
            string output = JsonConvert.SerializeObject(APMs);
            return Json(output, JsonRequestBehavior.AllowGet);
        }
    }
}
