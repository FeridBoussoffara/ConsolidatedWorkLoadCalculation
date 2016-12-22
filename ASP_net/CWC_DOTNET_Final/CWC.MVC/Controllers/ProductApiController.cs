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
    public class ProductApiController : ApiController
    {
        IProductService service = null;
        IProductAgrService servicearg = null;
        IProductFurService servicefur = null;
        IProductElecService servicelec = null;
        IProductSofService servicesof = null;
        IProductVehService serviceveh = null;
        IOrderSaleService orService = null;

        public ProductApiController()
        {
            service = new ProductService();
            servicearg = new ProductAgrService();
            servicefur = new ProductFurService();
            servicelec = new ProductElecService();
            servicesof = new ProductSofService();
            serviceveh = new ProductVehService();
            orService = new OrderSaleService();
        }
        [HttpGet]
        [AcceptVerbs("GET")]
        public List<CustomerModel> ListCutomerByProduct(int id)
        {
            List<Customer> lsCustomers = orService.ListCustomersByProductID(id);
            List<CustomerModel> cMs = new List<CustomerModel>(); 
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
            return cMs;
        }
        [HttpGet]
        [AcceptVerbs("GET" )]
        public ProductModel MostSoldProduct()
        {
            Product product = orService.MostSoldProduct();

             

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
             return   productmodel ;

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
                return productmodel;

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
                    return productmodel;
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
                    return productmodel;
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
                return productmodel;
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
                return productmodel;
            }

            return null;
        }
        [HttpGet]
        [AcceptVerbs("GET")]
        public float CalculEarningProduct(int id)
        {
            int monthSysdate = DateTime.Now.Month;
            float cal = orService.CalculateEarningsByMonth(id, monthSysdate);


            return cal;
        }
    }

}
