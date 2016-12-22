using CWC.Domain.Entities;
using CWC.MVC.Helpers;
using CWC.MVC.Models;
using CWC.Services;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        IProductService service = null;
        IProductAgrService servicearg = null;
        IProductFurService servicefur = null;
        IProductElecService servicelec = null;
        IProductSofService servicesof = null;
        IProductVehService serviceveh = null;
        IOrderSaleService orService = null;
        ICustomerService cuService = null;

        public ProductController()
        {
            service = new ProductService();
            servicearg = new ProductAgrService();
            servicefur = new ProductFurService();
            servicelec = new ProductElecService();
            servicesof = new ProductSofService();
            serviceveh = new ProductVehService();
            orService = new OrderSaleService();
            cuService = new CustomerService();
        }


        // GET: Product
        public ActionResult Index()
        {
            float gain = orService.GainOfAllProducts();
            float normalGain = service.NormalGainofAllProducts();
            int qanTotal = service.SumTotalQuantity();
            int qanSold = orService.SumTotalSoldQuantity();
            float restQuant = qanTotal - qanSold;
            int nbCust = cuService.NumberCustomers();
            int nbOrders = orService.NumberOrders();
            float ActivityCusOrd = (float)(nbCust*4 / nbOrders)*100;
            

            ViewBag.gain = gain;
            ViewBag.percentGain = (gain / normalGain) * 100;

            ViewBag.restQuant = restQuant;
            ViewBag.percentRest = (float)(restQuant/qanTotal)*100;
            ViewBag.nbCust = nbCust;
            ViewBag.nbOrders = nbOrders;
            ViewBag.activity = ActivityCusOrd;



            IEnumerable<Product> product = null;
            List<Customer> lsCustomers = null; 
            int nbCustByProduct;

            // product = service.GetAll().ToList(); 
            product = service.GetAllp();
            List<ProductModel> pMs = new List<ProductModel>();

            foreach (var item in product)
            {
                lsCustomers = orService.ListCustomersByProductID(item.ProductId);
                nbCustByProduct = lsCustomers.Count();
                var proMd = new ProductModel
                {
                    Id = item.ProductId,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Photo = item.Photo,
                    Price = item.Price,
                    AddedDate = item.AddedDate,
                    nbrCustomers=nbCustByProduct

                };
            


                //proMd.Type = "par défaut";

                if (item is Electronic)
                {
                    proMd.Type = "Electronic";
                }
                else if (item is Agriculture)
                {
                    proMd.Type = "Agriculture";
                }
                else if (item is Furniture)
                {
                    proMd.Type = "Furniture";
                }
                else if (item is Vehicule)
                {
                    proMd.Type = "Vehicule";
                }
                else if (item is Software)
                {
                    proMd.Type = "Software";
                }
                else
                {
                    proMd.Type = "Others";
                }

                pMs.Add(proMd);


            }

            ViewBag.ClassLiDash= "nav-item";
            ViewBag.ClassspanDash = "";
            ViewBag.ClassSpan2Dash = "arrow";

            ViewBag.ClassLiprod = "nav-item start active open";
            ViewBag.Classspanprod = "selected";
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

            ViewBag.ClassLiEmp = "nav-item";
            ViewBag.ClassspanEmp = "";
            ViewBag.ClassSpan2Emp = "arrow";
             
            return View(pMs);

        }
        //else if (item.GetType().IsInstanceOfType(typeof(Vehicule)))
        public ActionResult Index2()
        {
            IEnumerable<Product> product = null;
            // product = service.GetAll().ToList(); 
            product = service.GetAllp();
            List<ProductModel> pMs = new List<ProductModel>();

            foreach (var item in product)
            {
                var proMd = new ProductModel
                {
                    Id = item.ProductId,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Photo = item.Photo,
                    Price = item.Price,
                    AddedDate = item.AddedDate

                };

                //proMd.Type = "par défaut";

                if (item is Electronic)
                {
                    proMd.Type = "Electronic";
                }
                else if (item is Agriculture)
                {
                    proMd.Type = "Agriculture";
                }
                else if (item is Furniture)
                {
                    proMd.Type = "Furniture";
                }
                else if (item is Vehicule)
                {
                    proMd.Type = "Vehicule";
                }
                else if (item is Software)
                {
                    proMd.Type = "Software";
                }
                else
                {
                    proMd.Type = "Others";
                }

                pMs.Add(proMd);


            }
            return View(pMs);

        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = service.GetProductById(id);
            List<string> types = new List<string> { "Agriculture", "Vehicule", "Software", "Electronic", "Furniture", "Others" };
            List<string> categorieAgriculture = new List<string> { "Vegetable", "Fruit" };

           // Pdf p = new Pdf();
           // Section section1 = p.Sections.Add();
           // Text sampleText = new Text("Hello world");
           // section1.Paragraphs.Add(sampleText);
           // p.Save("~/Content/PDF/test.pdf");
           //// Pdf("test.pdf", "Details", productmodel);

            if (product is Electronic)
            {
                Electronic e = (Electronic)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Electronic",
                    Brand = e.Brand
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                ViewBag.Type = productmodel.Type; return View(productmodel);

            }
            if (product is Vehicule)
            {
                Vehicule e = (Vehicule)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Vehicule",
                    weight = e.weightveh,
                    WheelsNbr = e.WheelsNbr,
                    VehiculeType = e.VehiculeType,
                    Capacity = e.Capacity
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                ViewBag.Type = productmodel.Type; return View(productmodel);

            }
            if (product is Agriculture)
            {
                Agriculture e = (Agriculture)product;
                if (e.Category.Equals("Fruit"))
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Fruit",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    ViewBag.Type = productmodel.Type; return View(productmodel);

                }
                else
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Vegetable",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    ViewBag.Type = productmodel.Type; return View(productmodel);

                }
            }
            if (product is Software)
            {
                Software e = (Software)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Software",
                    Version = e.Version,
                    Technology = e.Technology
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                ViewBag.Type = productmodel.Type; return View(productmodel);

            }
            if (product is Furniture)
            {
                Furniture e = (Furniture)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Furniture",
                    Material = e.Material
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                ViewBag.Type = productmodel.Type;
                return View(productmodel);
            }
            
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            var productM = new ProductModel();
            // filmVM.Productors = service.GetAllProducteur().ToSelectListItems();
            List<string> types = new List<string> { "Agriculture", "Vehicule", "Software", "Electronic", "Furniture", "Others" };
            List<string> categorieAgriculture = new List<string> { "Vegetable", "Fruit" };

            productM.Types = types.ToSelectListItemsTypeProd();
            productM.Categories = categorieAgriculture.ToSelectListItemsTypeProd();

            return View(productM);


        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel productmodel, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid || Image == null || Image.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            productmodel.Photo = Image.FileName;

            if (productmodel.Type == "Agriculture" && productmodel.Category == "Fruit")
            {
                Agriculture prodAgriculture = new Agriculture
                {
                    ProductId = productmodel.Id,
                    AddedDate = productmodel.AddedDate,
                    Name = productmodel.Name,
                    Photo = productmodel.Photo,
                    Price = productmodel.Price,
                    Quantity = productmodel.Quantity,
                    Category = CategoryAgriculture.Fruit,
                    ValidityDate = productmodel.ValidityDate

                };
                prodAgriculture.AddedDate = DateTime.Now;
                servicearg.Add(prodAgriculture);
                servicearg.Commit();
            }
            else if (productmodel.Type == "Agriculture" && productmodel.Category == "Vegetable")
            {
                Agriculture prodAgriculture = new Agriculture
                {
                    ProductId = productmodel.Id,
                    AddedDate = productmodel.AddedDate,
                    Name = productmodel.Name,
                    Photo = productmodel.Photo,
                    Price = productmodel.Price,
                    Quantity = productmodel.Quantity,
                    Category = CategoryAgriculture.Vegetable,
                    ValidityDate = productmodel.ValidityDate

                }; prodAgriculture.AddedDate = DateTime.Now;
                servicearg.Add(prodAgriculture);
                servicearg.Commit();

            }
            else if (productmodel.Type == "Vehicule")
            {
                Vehicule prodVehicule = new Vehicule
                {
                    ProductId = productmodel.Id,
                    AddedDate = productmodel.AddedDate,
                    Name = productmodel.Name,
                    Photo = productmodel.Photo,
                    Price = productmodel.Price,
                    Quantity = productmodel.Quantity,
                    Capacity = productmodel.Capacity,
                    VehiculeType = productmodel.VehiculeType,
                    weightveh = productmodel.weight,
                    WheelsNbr = productmodel.WheelsNbr
                }; 
                serviceveh.Add(prodVehicule);
                serviceveh.Commit();
            }
            else if (productmodel.Type == "Software")
            {
                Software prodSoftware = new Software
                {
                    ProductId = productmodel.Id,
                    AddedDate = productmodel.AddedDate,
                    Name = productmodel.Name,
                    Photo = productmodel.Photo,
                    Price = productmodel.Price,
                    Quantity = productmodel.Quantity,
                    Technology = productmodel.Technology,
                    Version = productmodel.Version
                }; prodSoftware.AddedDate = DateTime.Now;
                servicesof.Add(prodSoftware);
                servicesof.Commit();
            }
            else if (productmodel.Type == "Electronic")
            {
                Electronic prodElectronic = new Electronic
                {
                    ProductId = productmodel.Id,
                    AddedDate = productmodel.AddedDate,
                    Name = productmodel.Name,
                    Photo = productmodel.Photo,
                    Price = productmodel.Price,
                    Quantity = productmodel.Quantity,
                    Brand = productmodel.Brand,
                    weightElec = productmodel.weight
                }; prodElectronic.AddedDate = DateTime.Now;
                servicelec.Add(prodElectronic);
                servicelec.Commit();
            }
            else if (productmodel.Type == "Furniture")
            {
                Furniture prodFurniture = new Furniture
                {
                    ProductId = productmodel.Id,
                    AddedDate = productmodel.AddedDate,
                    Name = productmodel.Name,
                    Photo = productmodel.Photo,
                    Price = productmodel.Price,
                    Quantity = productmodel.Quantity,
                    Material = productmodel.Material,
                    weightFur = productmodel.weight
                }; prodFurniture.AddedDate = DateTime.Now;
                servicefur.Add(prodFurniture);
                servicefur.Commit();
            }
            else if (productmodel.Type == "Others")
            {
                Product product = new Product
                {
                    ProductId = productmodel.Id,
                    AddedDate = productmodel.AddedDate,
                    Name = productmodel.Name,
                    Photo = productmodel.Photo,
                    Price = productmodel.Price,
                    Quantity = productmodel.Quantity,
                }; product.AddedDate = DateTime.Now;
                service.Add(product);
                service.Commit();
            }
             
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = service.GetProductById(id);
            List<string> types = new List<string> { "Agriculture", "Vehicule", "Software", "Electronic", "Furniture", "Others" };
            List<string> categorieAgriculture = new List<string> { "Vegetable", "Fruit" };


            if (product is Electronic)
            {
                Electronic e = (Electronic)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Electronic",
                    Brand = e.Brand
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Vehicule)
            {
                Vehicule e = (Vehicule)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Vehicule",
                    weight = e.weightveh,
                    WheelsNbr = e.WheelsNbr,
                    VehiculeType = e.VehiculeType,
                    Capacity = e.Capacity
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Agriculture)
            {
                Agriculture e = (Agriculture)product;
                if (e.Category.Equals("Fruit"))
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Fruit",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    return View(productmodel);

                }
                else
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Vegetable",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    return View(productmodel);

                }
            }
            if (product is Software)
            {
                Software e = (Software)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Software",
                    Version = e.Version,
                    Technology = e.Technology
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Furniture)
            {
                Furniture e = (Furniture)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Furniture",
                    Material = e.Material
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);
            }

            return View();


        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel productmodel, HttpPostedFileBase Image)
        {


            productmodel.Photo = Image.FileName;
            if (productmodel.Type == "Agriculture" && productmodel.Category == "Fruit")
            {
                Agriculture prodAgriculture = servicearg.GetById(id);

                prodAgriculture.AddedDate = productmodel.AddedDate;
                prodAgriculture.Name = productmodel.Name;
                prodAgriculture.Photo = productmodel.Photo;
                prodAgriculture.Price = productmodel.Price;
                prodAgriculture.Quantity = productmodel.Quantity;
                prodAgriculture.Category = CategoryAgriculture.Fruit;
                prodAgriculture.ValidityDate = productmodel.ValidityDate;


                servicearg.Update(prodAgriculture);
                servicearg.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);

                return RedirectToAction("index");
            }
            else if (productmodel.Type == "Agriculture" && productmodel.Category == "Vegetable")
            {
                Agriculture prodAgriculture = servicearg.GetById(id);

                prodAgriculture.AddedDate = productmodel.AddedDate;
                prodAgriculture.Name = productmodel.Name;
                prodAgriculture.Photo = productmodel.Photo;
                prodAgriculture.Price = productmodel.Price;
                prodAgriculture.Quantity = productmodel.Quantity;
                prodAgriculture.Category = CategoryAgriculture.Vegetable;
                prodAgriculture.ValidityDate = productmodel.ValidityDate;


                servicearg.Update(prodAgriculture);
                servicearg.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);

                return RedirectToAction("index");

            }
            else if (productmodel.Type == "Vehicule")
            {
                Vehicule prodVehicule = serviceveh.GetById(id);

                prodVehicule.AddedDate = productmodel.AddedDate;
                prodVehicule.Name = productmodel.Name;
                prodVehicule.Photo = productmodel.Photo;
                prodVehicule.Price = productmodel.Price;
                prodVehicule.Quantity = productmodel.Quantity;
                prodVehicule.Capacity = productmodel.Capacity;
                prodVehicule.VehiculeType = productmodel.VehiculeType;
                prodVehicule.weightveh = productmodel.weight;
                prodVehicule.WheelsNbr = productmodel.WheelsNbr;

                serviceveh.Update(prodVehicule);
                serviceveh.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);

                return RedirectToAction("index");
            }
            else if (productmodel.Type == "Software")
            {
                Software prodSoftware = servicesof.GetById(id);

                prodSoftware.AddedDate = productmodel.AddedDate;
                prodSoftware.Name = productmodel.Name;
                prodSoftware.Photo = productmodel.Photo;
                prodSoftware.Price = productmodel.Price;
                prodSoftware.Quantity = productmodel.Quantity;
                prodSoftware.Technology = productmodel.Technology;
                prodSoftware.Version = productmodel.Version;

                servicesof.Update(prodSoftware);
                servicesof.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);

                return RedirectToAction("index");
            }
            else if (productmodel.Type == "Electronic")
            {
                Electronic prodElectronic = servicelec.GetById(id);


                prodElectronic.AddedDate = productmodel.AddedDate;
                prodElectronic.Name = productmodel.Name;
                prodElectronic.Photo = productmodel.Photo;
                prodElectronic.Price = productmodel.Price;
                prodElectronic.Quantity = productmodel.Quantity;
                prodElectronic.Brand = productmodel.Brand;
                prodElectronic.weightElec = productmodel.weight;

                servicelec.Update(prodElectronic);
                servicelec.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);

                return RedirectToAction("index");
            }
            else if (productmodel.Type == "Furniture")
            {
                Furniture prodFurniture = servicefur.GetById(id);


                prodFurniture.AddedDate = productmodel.AddedDate;
                prodFurniture.Name = productmodel.Name;
                prodFurniture.Photo = productmodel.Photo;
                prodFurniture.Price = productmodel.Price;
                prodFurniture.Quantity = productmodel.Quantity;
                prodFurniture.Material = productmodel.Material;
                prodFurniture.weightFur = productmodel.weight;


                servicefur.Update(prodFurniture);
                servicefur.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);

                return RedirectToAction("index");
            }
            else if (productmodel.Type == "Others")
            {
                Product product = service.GetProductById(id);


                product.AddedDate = productmodel.AddedDate;
                product.Name = productmodel.Name;
                product.Photo = productmodel.Photo;
                product.Price = productmodel.Price;
                product.Quantity = productmodel.Quantity;

                service.Update(product);
                service.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);

                return RedirectToAction("index");
            }


            return View(productmodel);

        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = service.GetById(id);
            List<string> types = new List<string> { "Agriculture", "Vehicule", "Software", "Electronic", "Furniture", "Others" };
            List<string> categorieAgriculture = new List<string> { "Vegetable", "Fruit" };


            if (product is Electronic)
            {
                Electronic e = (Electronic)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Electronic",
                    Brand = e.Brand
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();

                return View(productmodel);

            }
            if (product is Vehicule)
            {
                Vehicule e = (Vehicule)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Vehicule",
                    weight = e.weightveh,
                    WheelsNbr = e.WheelsNbr,
                    VehiculeType = e.VehiculeType,
                    Capacity = e.Capacity
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Agriculture)
            {
                Agriculture e = (Agriculture)product;
                if (e.Category.Equals("Fruit"))
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Fruit",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    return View(productmodel);

                }
                else
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Vegetable",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    return View(productmodel);

                }
            }
            if (product is Software)
            {
                Software e = (Software)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Software",
                    Version = e.Version,
                    Technology = e.Technology
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Furniture)
            {
                Furniture e = (Furniture)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Furniture",
                    Material = e.Material
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var product = service.GetById(id);
            service.Delete(product);
            service.Commit();
            return RedirectToAction("Index");


        }


        public ActionResult StatisticProducts()
        {

            List<StatProductQuantityModel> lstStatPrQ = new List<StatProductQuantityModel>();

            IEnumerable<Product> listproduct = null;
            // product = service.GetAll().ToList(); 
            listproduct = service.GetAllp().ToList();

            foreach (var item in listproduct)
            {
                lstStatPrQ.Add(new StatProductQuantityModel
                {
                    name = item.Name,
                    value = item.Quantity
                });

            }

            //lstStatPrQ.Add(new StatProductQuantityModel
            //{
            //    name = "linux",
            //    value = 45
            //});
            //lstStatPrQ.Add(new StatProductQuantityModel
            //{
            //    name = "Windows",
            //    value = 10
            //});
            //lstStatPrQ.Add(new StatProductQuantityModel
            //{
            //    name = "Mac",
            //    value = 78
            //}
            //   );

            ViewBag.stat = lstStatPrQ;


            return View("StatisticProductsqt");
        }

        public ActionResult CalculEarningProduct(int id)
        {
            int monthSysdate = DateTime.Now.Month;
            ViewBag.Cal = orService.CalculateEarningsByMonth(id, monthSysdate);
            ViewBag.nameProduct = service.GetById(id).Name;
            ViewBag.month = DateTime.Now.ToString("MMMM");
            List<int> listMonths = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var EarningM = new EarningModel();
            EarningM.months = listMonths.ToSelectListItemsInt();

            return View(EarningM);
        }
        [HttpPost]
        public ActionResult CalculEarningProduct(int id, EarningModel earnM)
        {
            int a = earnM.monthNum;
            int year = DateTime.Now.Year;
            DateTime dt = new DateTime(year, a, 1);

            ViewBag.Cal = orService.CalculateEarningsByMonth(id, earnM.monthNum);
            ViewBag.nameProduct = service.GetById(id).Name;
            ViewBag.month = dt.ToString("MMMM");
            List<int> listMonths = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var EarningM = new EarningModel();
            EarningM.months = listMonths.ToSelectListItemsInt();
            EarningM.monthNum = earnM.monthNum;

            return View(EarningM);
        }

        public ActionResult MostSoldProduct()
        {
            Product p = orService.MostSoldProduct();


            var product = service.GetProductById(p.ProductId);
            List<string> types = new List<string> { "Agriculture", "Vehicule", "Software", "Electronic", "Furniture", "Others" };
            List<string> categorieAgriculture = new List<string> { "Vegetable", "Fruit" };


            if (product is Electronic)
            {
                Electronic e = (Electronic)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Electronic",
                    Brand = e.Brand
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Vehicule)
            {
                Vehicule e = (Vehicule)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Vehicule",
                    weight = e.weightveh,
                    WheelsNbr = e.WheelsNbr,
                    VehiculeType = e.VehiculeType,
                    Capacity = e.Capacity
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Agriculture)
            {
                Agriculture e = (Agriculture)product;
                if (e.Category.Equals("Fruit"))
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Fruit",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    return View(productmodel);

                }
                else
                {
                    var productmodel = new ProductModel
                    {
                        Id = e.ProductId,
                        AddedDate = e.AddedDate,
                        Name = e.Name,
                        Photo = e.Photo,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        Type = "Agriculture",
                        Category = "Vegetable",
                        ValidityDate = e.ValidityDate
                    };
                    productmodel.Types = types.ToSelectListItemsTypeProd();
                    productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                    return View(productmodel);

                }
            }
            if (product is Software)
            {
                Software e = (Software)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Software",
                    Version = e.Version,
                    Technology = e.Technology
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);

            }
            if (product is Furniture)
            {
                Furniture e = (Furniture)product;
                var productmodel = new ProductModel
                {
                    Id = e.ProductId,
                    AddedDate = e.AddedDate,
                    Name = e.Name,
                    Photo = e.Photo,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Type = "Furniture",
                    Material = e.Material
                };
                productmodel.Types = types.ToSelectListItemsTypeProd();
                productmodel.Categories = categorieAgriculture.ToSelectListItemsTypeProd();
                return View(productmodel);
            }
            return View("index");

        }

        public ActionResult ListCutomerByProduct(int id)
        {
            List<Customer> lsCustomers = orService.ListCustomersByProductID(id);
            List<CustomerModel> cMs = new List<CustomerModel>();
            @ViewBag.Product = service.GetById(id);
            foreach (var item in lsCustomers)
            {
                var cM = new CustomerModel
                {
                    CustomerId = item.CustomerId,
                    Name = item.Name,
                    Adresse = item.Adresse,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    Photo = item.Photo,
                    Type = item.Type
                };
                cMs.Add(cM);
            }

            return View(cMs);
        }

         
    }
}