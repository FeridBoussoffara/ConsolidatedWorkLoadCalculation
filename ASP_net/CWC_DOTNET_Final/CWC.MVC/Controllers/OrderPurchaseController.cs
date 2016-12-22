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
    public class OrderPurchaseController : Controller
    {
        OrderPurchaseServices os = new OrderPurchaseServices();
        ProviderServices ps = new ProviderServices();
        ProductService pps = new ProductService();


        // GET: OrderPurchase
        public ActionResult Index()
        {
            var o = os.GetAll();
            
            List<OrderPurchaseModels> lom = new List<OrderPurchaseModels>();

            foreach (var item in o)
            {
                Provider p = ps.GetById(item.ProviderId);
                Product pp = pps.GetById(item.ProductId);
                lom.Add(new OrderPurchaseModels
                {
                    DateOrder = item.DateOrder,
                    quantity = item.quantity,
                    ProductName = pp.Name,
                    ProviderName  = p.Name,
                    ProductId = pp.ProductId,
                    ProviderId = p.ProviderId
                });
            }

            return View(lom);
        }

        // GET: OrderPurchase/Details/5
        public ActionResult Details(int? Provid, int? Prodid)
        {
            if (Provid == null || Provid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderPurchase o = os.FindByIds(Provid.Value,Prodid.Value);
            OrderPurchaseModels o1 = new OrderPurchaseModels
            {
                quantity = o.quantity,
                DateOrder = o.DateOrder,
                ProductName = o.Product.Name,
                ProviderName = o.Provider.Name,
                ProductId = o.ProductId,
                ProviderId = o.ProviderId
                
            };

            if (o1 == null)
            {
                return HttpNotFound();
            }

            return View(o1);

        }

        // GET: OrderPurchase/Create
        public ActionResult Create()
        {
            var orders = new OrderPurchaseModels();
            orders.Providers = ps.GetAll().ToSelectListItemsProv();
            orders.Products = pps.GetAll().ToSelectListItemsProd();

            return View(orders);
        }

        // POST: OrderPurchase/Create
        [HttpPost]
        public ActionResult Create(OrderPurchaseModels om)
        {
            OrderPurchase o = new OrderPurchase
            {
                ProductId = om.ProductId,
                ProviderId = om.ProviderId,
                quantity = om.quantity,
                DateOrder = om.DateOrder
               
            };
            os.Add(o);
            os.Commit();

            return RedirectToAction("Index");

        }

        // GET: OrderPurchase/Edit/5
        public ActionResult Edit(int? Provid, int? Prodid)
        {
            if (Provid == null || Provid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider p = ps.GetById(Provid.Value);
            Product pp = pps.GetById(Prodid.Value);

            OrderPurchase o = os.FindByIds(Provid.Value, Prodid.Value);
            OrderPurchaseModels o1 = new OrderPurchaseModels
            {
                quantity = o.quantity,
                DateOrder = o.DateOrder,
                ProductId = pp.ProductId,
                ProviderId = p.ProviderId

            };
            o1.Providers = ps.GetAll().ToSelectListItemsProv();
            o1.Products = pps.GetAll().ToSelectListItemsProd();


            if (o1 == null)
            {
                return HttpNotFound();
            }

            return View(o1);
        }

        // POST: OrderPurchase/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection OrderPurchaseModels)
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

        // GET: OrderPurchase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderPurchase/Delete/5
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
