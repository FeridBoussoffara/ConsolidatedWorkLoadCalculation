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
    public class ProviderWebAPiController : ApiController
    {
        static readonly ProviderServices ps = new ProviderServices();

        //  /api/ProviderWebAPi
        public IEnumerable<ProviderModels> GetAllProviders()
        {
            var p = ps.GetAll();
            List<ProviderModels> lpm = new List<ProviderModels>();

            foreach (var item in p)
            {
                lpm.Add(new ProviderModels
                {
                    ProviderId = item.ProviderId,
                    Name = item.Name,
                    Adresse = item.Adresse,
                    Email = item.Email,
                    NumTel = item.NumTel,
                    Logo = item.Logo
                });
            }

            return lpm;

        }


        //  /api/ProviderWebAPi/1
        public ProviderModels GetProvider(int ProviderID)
        {
            Provider p = ps.GetById(ProviderID);
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            ProviderModels pm = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId,
                Logo = p.Logo
            };
            return pm;
        }

        [Route("api/provider/region/{Adresse}")]
        [HttpGet]
        public IEnumerable<ProviderModels> GetProviderByRegion(string Adresse)
        {
            var p = ps.GetProviderByRegion(Adresse);
            List<ProviderModels> lpm = new List<ProviderModels>();

            foreach (var item in p)
            {
                lpm.Add(new ProviderModels
                {
                    ProviderId = item.ProviderId,
                    Name = item.Name,
                    Adresse = item.Adresse,
                    Email = item.Email,
                    NumTel = item.NumTel,
                    Logo = item.Logo
                });
            }
            return lpm;

        }

        [Route("api/provider/post")]
        [HttpPost]
        public HttpResponseMessage PostProvider(Provider p)
        {
            ps.Add(p);
            ps.Commit();

            ProviderModels pm = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId,
                Logo = p.Logo
            };

            var response = Request.CreateResponse
                    <ProviderModels>(HttpStatusCode.Created, pm);


            string uri = Url.Route("DefaultApi", new { id = pm.ProviderId });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [Route("api/provider/update")]
        [HttpPost]
        public HttpResponseMessage PutProvider(Provider p)
        {
            ps.Update(p);
            ps.Commit();

            ProviderModels pm = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId,
                Logo = p.Logo
            };

            var response = Request.CreateResponse
                    <ProviderModels>(HttpStatusCode.Created, pm);


            string uri = Url.Route("DefaultApi", new { id = pm.ProviderId });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }


        [Route("api/provider/delete/{ProviderID}")]
        [HttpGet]
        public void DeleteProvider(int ProviderID)
        {
            Provider p = ps.GetById(ProviderID);
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            ps.Delete(p);
            ps.Commit();
        }

        [Route("api/provider/details/{ProviderID}")]
        [HttpGet]
        public ProviderModels DetailsProvider(int ProviderID)
        {
            Provider p = ps.GetById(ProviderID);
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            ProviderModels pm = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId,
                Logo = p.Logo
            };
            return pm;
        }

    }
}
