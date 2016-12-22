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
    public class IndividualProjectController : Controller
    {
        IProjectService service = null;
        AssignementService aservice = null;
        
        public IndividualProjectController()
        {
            service = new ProjectService();
            aservice = new AssignementService();
        }
        // GET: IndividualProject
        public ActionResult Index()
        {
            return View("Index", "ProjectController");
        }

        // GET: IndividualProject/Details/5
        public ActionResult Details(int? id)
        {/*
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             IndividualProject p = service.GetById(id.Value);
              IndividualProjectViewModel pvm = new IndividualProjectViewModel()

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

              return View(pvm);*/
            return View();
                   }

        // GET: IndividualProject/Create
        public ActionResult Create()
        {
            List<string> categories = new List<string> { "IT","Agriculture","Construction","Business","Finance" };

            var individualprojectvm = new IndividualProjectViewModel();
            individualprojectvm.Employee = service.getAllEmployees().ToSelectListItemsEmployee();
            individualprojectvm.Categories = categories.ToSelectListItems();

            return View(individualprojectvm);
        }

        // POST: IndividualProject/Create
        [HttpPost]
        public ActionResult Create(IndividualProjectViewModel ivm)
        {

            IndividualProject ip = new IndividualProject()
            { 
                StartDate = ivm.StartDate,
                EndDate = ivm.EndDate,
                Name = ivm.Name,
                Budget = ivm.Budget,
                SingleEmployeeId = ivm.SingleEmployeeId,
                TypeProject = Domain.Entities.TypeProject.Individual,

            };
            if (ivm.Category == "IT") { ip.Category = CategoryProject.IT; }
            else if (ivm.Category == "Agriculture") { ip.Category = CategoryProject.Agriculture; }
            else if (ivm.Category == "Construction") { ip.Category = CategoryProject.Construction; }
            else if (ivm.Category == "Business") { ip.Category = CategoryProject.Business; }
            else { ip.Category = CategoryProject.Finance; }
            service.Add(ip);
            service.Commit();
            aservice.AssignProjectToEmployee(ip.SingleEmployeeId, ip.ProjectId);
            aservice.Commit();
            return RedirectToAction("Index", "Project/Index");

        }

        // GET: IndividualProject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndividualProject/Edit/5
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

        // GET: IndividualProject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndividualProject/Delete/5
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
