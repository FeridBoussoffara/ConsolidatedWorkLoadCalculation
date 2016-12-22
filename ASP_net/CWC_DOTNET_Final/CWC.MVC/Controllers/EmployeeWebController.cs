using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using CWC.Services;
using Microsoft.AspNet.Identity;

namespace CWC.MVC.Controllers
{

    public class EmployeeWebController : ApiController
    {
        private ApplicationUserManager _userManager;
        private IProjectService PS;
        public EmployeeWebController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
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
        public EmployeeWebController()
        {
            PS = new ProjectService();
        }
        [ActionName("GetMean")]
        public HttpResponseMessage GetMeanCompletionByTeamLeader(string TeamLeaderId)
        {
            try
            {
                var TeamLeader = UserManager.FindById(TeamLeaderId);
                var Mean = PS.MeanTaskCompletionByTeamLeader(TeamLeader);
                return Request.CreateResponse(HttpStatusCode.OK, Mean);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [ActionName("GetProjects")]
        public HttpResponseMessage Get6MostCostlyProjectsForATeamLeader(string TeamLeaderId)
        {
            try
            {

                var TeamLeader = UserManager.FindById(TeamLeaderId);
                var Projects = PS.Get6MostCostlyProjectsForATeamLeader(TeamLeader);
                return Request.CreateResponse(HttpStatusCode.OK, Projects);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
