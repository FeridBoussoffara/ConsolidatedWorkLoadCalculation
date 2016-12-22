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
    public class WebAPIProjectController : ApiController
    {
        ProjectService pservice = null;
        AssignementService aservice = null;
        public WebAPIProjectController()
        {
            pservice = new ProjectService();
            aservice = new AssignementService();
        }
        // GET: api/Default
        public HttpResponseMessage GetDelivredProjects()
        {
            var Projects= pservice.getDelivredProject();
            List<ProjectViewModel> listp = new List<ProjectViewModel>();
            foreach(var item in Projects)
            {
                listp.Add(new ProjectViewModel
                {
                    Name = item.Name,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Budget = item.Budget,
                    Category = item.Category.ToString()

                });
            

            }
            if(Projects.Count()==0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listp);
        }
        public HttpResponseMessage GetMostExpensive()
        {
            var Projects = pservice.getMostExpensiveProject();
            List<ProjectViewModel> listp = new List<ProjectViewModel>();
            foreach (var item in Projects)
            {
                listp.Add(new ProjectViewModel
                {
                    Name = item.Name,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Budget = item.Budget,
                    Category = item.Category.ToString()

                });


            }
            if (Projects.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listp);

        }

        public HttpResponseMessage GetMostActive()
        {
            var MostActive = aservice.MostActiveEmployee();
            if (MostActive==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, MostActive.FirstName);

        }
        [Route("api/WebAPIProject/Details/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(int id)
        {
            Project p = pservice.GetById(id);
            ProjectViewModel pvm = new ProjectViewModel()

            {
                Name = p.Name,

                Budget = p.Budget,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                ProjectId = p.ProjectId,
                Category = p.Category.ToString()
            };
            if (p == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, pvm);

        }


        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
        //public IEnumerable<Project> getProjectInDate(DateTime start, DateTime end)
        //{
        //    return ut.getRepository<Project>().GetMany(p => p.StartDate >= start && p.EndDate <= end).ToList();
        //}
    }
}
