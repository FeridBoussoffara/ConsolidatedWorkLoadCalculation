using CWC.Domain.Entities;
using CWC.MVC.Models;
using CWC.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TweetSharp;
using System.IO;
using System.Net;
using System.Data;
using System.Text;

namespace CWC.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProviderController : Controller
    {
        
        ProviderServices ps = new ProviderServices();
        OrderPurchaseServices os = new OrderPurchaseServices();
        public static string _consumerKey = "UDZex6iB7wxcemDiBZK7xX6Hl"; // Your key
        public static string _consumerSecret = "3gKvVR5zMf0EY0DfaxdB8czMByjBJMAkD7rjJqkwGjbasfzvBc"; // Your key  
        public static string _accessToken = "2532692814-hqucBjFvH4HQfwXF59eYAKNQMZJKXWz316XDRsM"; // Your key  
        public static string _accessTokenSecret = "MRPnB57BQkgYAxVojOpzyRf0xZqGEDQD9gJYl13e1tFIR"; // Your key  

        ////////////////////////////////////////////////////////SERVICE//////////////////////////////////////////

        // GET: Provider/ProfileProvider/1
        public ActionResult ProfileProvider(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider p = ps.GetById(id.Value);
            ProviderModels p1 = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Logo = p.Logo,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId
            };

            if (p1 == null)
            {
                return HttpNotFound();
            }

            List<ProfileProviderModels> lpm = new List<ProfileProviderModels>();
            var products = os.GetProductProvider(id.Value);

            foreach (var item in products)
            {
                DateTime d = os.GetProductProviderDateOrder(item.ProductId);
                
                int q = os.GetProductProviderQu(item.ProductId);
                lpm.Add(new ProfileProviderModels
                {
                    name = item.Name,
                    earning = item.Price,
                    lastdate = d.ToString("dd/MM/yyyy"),
                    quantity = q,
                    img = item.Photo
                });
            }
            ViewBag.earn = os.GetProductEarnProvider(id.Value);
            ViewBag.quan = os.GetQuantityOrderedProvider(id.Value);
            ViewBag.prod = lpm;

            //api
            int tweetcount = 1;
            TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
            twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);


            var tweets_search = twitterService.Search(new SearchOptions { Q = "#Ebay" });
            //var tweets_search = twitterService.Search(new SearchOptions { Q = keyword, Count = Convert.ToInt32(count), MaxId = Convert.ToInt64(maxid) });

            List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
            ViewBag.tweet = tweets_search.Statuses;
            return View(p1);
        }

        //Get Provider/GetOrderedProductProvider/3
        public ActionResult GetOrderedProductProvider(int? id)
        {
            var p = os.GetProductProvider(id.Value);

            List<ProductModel> lpm = new List<ProductModel>();

            foreach (var item in p)
            {
                lpm.Add(new ProductModel
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Photo = item.Photo
                });
            }
            Provider p11 = ps.GetById(id.Value);
            ViewBag.Name = p11.Name;
            return View(lpm);


        }

        // GET: Provider/MostProvider
        public ActionResult MostProvider()
        {
            Provider p = ps.MostActiveProvider();
            ProviderModels p1 = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Logo = p.Logo,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId
            };
            if (p1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Name = "Most Requested Provider";
            return View("Details", p1);

        }

        // GET: Provider/ProductForSpecificProviderRegion/France (unused)
        public ActionResult ProductForSpecificProviderRegion(String country)
        {
            var p = ps.GetProductProviderRegion(country);

            List<ProductModel> lpm = new List<ProductModel>();

            foreach (var item in p)
            {
                lpm.Add(new ProductModel
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            ViewBag.Name = country;
            return View(lpm);

        }

        //map Stat
        //Provider/MapProviderRegion
        public ActionResult MapProviderRegion()
        {
            List<MapRegionModels> mp = new List<MapRegionModels>();
            List<String> listAd = ps.GetListAdresseProviders();
            foreach (var item in listAd)
            {
                int c = ps.GetProviderNumberByRegion(item);
                String code = "";
                String color = "";
                if (item == "Afghanistan") { code = "AF"; color = "#eea638"; }
                else if (item == "Albania") { code = "AL"; color = "#d8854f"; }
                else if (item == "Algeria") { code = "DZ"; color = "#de4c4f";  }
                else if (item == "Angola") { code = "AO"; color = "#de4c4f"; }
                else if (item == "Argentina") { code = "AR"; color = "#86a965"; }
                else if (item == "Armenia") { code = "AM"; color = "#d8854f"; }
                else if (item == "Australia") { code = "AU"; color = "#8aabb0"; }
                else if (item == "Austria") { code = "AT"; color = "#d8854f"; }
                else if (item == "Azerbaijan") { code = "AZ"; color = "#d8854f"; }
                else if (item == "Bahrain") { code = "BH"; color = "#eea638"; }
                else if (item == "Bangladesh") { code = "BD"; color = "#eea638"; }
                else if (item == "Belarus") { code = "BY"; color = "#d8854f"; }
                else if (item == "Belgium") { code = "BE"; color = "#d8854f"; }
                else if (item == "Benin") { code = "BJ"; color = "#de4c4f"; }
                else if (item == "Brazil") { code = "BR"; color = "#86a965"; }
                else if (item == "Canada") { code = "CA"; color = "#a7a737"; }
                else if (item == "Cameroon") { code = "ARCM"; color = "#de4c4f"; }
                else if (item == "Chile") { code = "CL"; color = "#Argentina"; }
                else if (item == "China") { code = "CN"; color = "#eea638"; }
                else if (item == "Egypt") { code = "EG"; color = "#de4c4f"; }
                else if (item == "India") { code = "IN"; color = "#eea638"; }
                else if (item == "Italy") { code = "JM"; color = "#a7a737"; }
                else if (item == "Japan") { code = "JP"; color = "#eea638"; }
                else if (item == "United States") { code = "US"; color = "#a7a737"; }
                else if (item == "Tunisia") { code = "TN"; color = "#de4c4f"; }
                else if (item == "Morocco") { code = "MA"; color = "#de4c4f"; }
                else if (item == "France") { code = "FR"; color = "#d8854f"; }
                else if (item == "Spain") { code = "ES"; color = "#d8854f"; }
                else if (item == "Qatar") { code = "QA"; color = "#eea638"; }
                mp.Add(
                    new MapRegionModels
                    {
                        name = item+ " "+ c,
                        value = c,
                        code = code,
                        color = color
                    }
                );
                
            }
            ViewBag.List = mp;
            return View("MapProviderRegion", "_LayoutMap");
        }

        //provider contact page 
        //Provider/ContactPageProvider
        public ActionResult ContactPageProvider(int? id)
        {
            Provider p = ps.GetById(id.Value);
            ProviderModels p1 = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Logo = p.Logo,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId
            };
            if (p1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.prov = p1;
            return View("ContactPageProvider");
        }





        ////////////////////////////////////////////////CRUD////////////////////////////////////////

            // GET: Provider
        public ActionResult Index()
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


            return View("Index", "_LayoutIndex", lpm);
           // return View(lpm);

        }

        //search by region(recherche)
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var p = ps.GetProviderByRegion(searchString);
            List<ProviderModels> lpm = new List<ProviderModels>();
            if (!String.IsNullOrEmpty(searchString))
            {
                foreach (var item in p)
                {
                    lpm.Add(new ProviderModels
                    {
                        Name = item.Name,
                        Adresse = item.Adresse,
                        Email = item.Email,
                        NumTel = item.NumTel,
                        Logo = item.Logo
                    });
                }
            }
            return View(lpm);
        }

        // GET: Provider/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider p = ps.GetById(id.Value);
            ProviderModels p1 = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Logo = p.Logo,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId =p.ProviderId
            };

            if(p1 == null)
            {
                return HttpNotFound();
            }

            return View(p1);
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Image, ProviderModels pp)
        {
            if (!ModelState.IsValid || Image == null || Image.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            Provider p = new Provider
            {
                Name = pp.Name,
                Adresse = pp.Adresse,
                Email = pp.Email,
                NumTel = pp.NumTel,
                Logo = Image.FileName
           };
            ps.Add(p);
            ps.Commit();

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

        }

        // GET: Provider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider p = ps.GetById(id.Value);
            ProviderModels p1 = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Logo = p.Logo,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId
            };

            if (p1 == null)
            {
                return HttpNotFound();
            }

            return View(p1);

        }

        // POST: Provider/Edit/5
        [HttpPost]
        public ActionResult Edit(int id ,ProviderModels pp, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                Provider p = ps.GetById(id);
                p.Name = pp.Name;
                p.NumTel = pp.NumTel;
                p.Email = pp.Email;
                p.Adresse = pp.Adresse;
                if( Image != null && Image.ContentLength != 0 ) 
                {
                    p.Logo = Image.FileName;
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                    Image.SaveAs(path);
                }

                ps.Update(p);
                ps.Commit();

                return RedirectToAction("Index");
            }
            return View(pp);
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider p = ps.GetById(id.Value);
            ProviderModels p1 = new ProviderModels
            {
                Adresse = p.Adresse,
                Email = p.Email,
                Logo = p.Logo,
                Name = p.Name,
                NumTel = p.NumTel,
                ProviderId = p.ProviderId
            };

            if (p1 == null)
            {
                return HttpNotFound();
            }

            return View(p1);
        }

        // POST: Provider/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, ProviderModels pp)
        {
            Provider p = ps.GetById(id.Value);
            ps.Delete(p);
            ps.Commit();
            return RedirectToAction("Index");
        }
    }
}
