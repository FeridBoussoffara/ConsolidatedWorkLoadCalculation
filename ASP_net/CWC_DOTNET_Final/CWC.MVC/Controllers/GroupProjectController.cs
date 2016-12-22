using CWC.Domain.Entities;
using CWC.MVC.Helpers;
using CWC.MVC.Models;
using CWC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class GroupProjectController : Controller
    {
        IProjectService service = null;
        AssignementService aservice = null;
        public GroupProjectController()
        {
            service = new ProjectService();
            aservice = new AssignementService();
        }
        // GET: GroupProject
        public ActionResult Index()
        {
            return View("Index", "ProjectController");
        }

        // GET: GroupProject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupProject/Create
        public ActionResult Create()
        {
            List<string> categories = new List<string> { "IT", "Agriculture", "Construction", "Business", "Finance" };
           
            var groupprojectvm = new GroupProjectViewModel();
            groupprojectvm.Employee = service.getAllEmployees().ToSelectListItemsEmployee();

            groupprojectvm.Categories = categories.ToSelectListItems();
            return View(groupprojectvm);
            
        }

        // POST: GroupProject/Create
        [HttpPost]
        public ActionResult Create(GroupProjectViewModel gvm)
        {
            GroupProject gp = new GroupProject()
            {
            StartDate = gvm.StartDate,
                EndDate = gvm.EndDate,
                Name = gvm.Name,
                Budget=gvm.Budget,
                TeamLeaderId = gvm.TeamLeaderId,
                TypeProject = Domain.Entities.TypeProject.Group,
                

            };
            if (gvm.Category == "IT") { gp.Category = CategoryProject.IT; }
            else if (gvm.Category == "Agriculture") { gp.Category = CategoryProject.Agriculture; }
            else if (gvm.Category == "Construction") { gp.Category = CategoryProject.Construction; }
            else if (gvm.Category == "Business") { gp.Category = CategoryProject.Business; }
            else { gp.Category = CategoryProject.Finance; }
            
            service.Add(gp);
            service.Commit();
            aservice.AssignProjectToEmployee(gp.TeamLeaderId, gp.ProjectId);
            aservice.Commit();
            return RedirectToAction("Index","Project/Index");
          
            
        }

        // GET: GroupProject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GroupProject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupProject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GroupProject/Delete/5
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
    }
}
