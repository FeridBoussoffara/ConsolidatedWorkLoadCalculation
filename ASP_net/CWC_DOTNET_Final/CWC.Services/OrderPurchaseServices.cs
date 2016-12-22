using CompteServicesPattern;
using CWC.Data.Infrastructure;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
    public class OrderPurchaseServices : Service<OrderPurchase>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        ProductService ps = new ProductService();
    

        public OrderPurchaseServices() : base(ut)
        {
        }


        //find order by id 
        public OrderPurchase FindByIds(int id1, int id2)
        {
            return ut.getRepository<OrderPurchase>().GetMany(a => a.ProviderId == id1 && a.ProductId == id2).FirstOrDefault();
        }

        //all liste product for provider
        public IEnumerable<Product> GetProductProvider(int id)
        {
            var o = ut.getRepository<OrderPurchase>().GetMany(a => a.Provider.ProviderId == id).Select(a => a.ProductId).ToList();
            ICollection<Product> olist = new List<Product>();
            foreach (var item in o)
            {
                var h = ps.GetById(item);
                olist.Add(h);
            }
            return olist.AsEnumerable();

        }

        //get products earnings 
        public float GetProductEarnProvider(int id)
        {
            var o = ut.getRepository<OrderPurchase>().GetMany(a => a.Provider.ProviderId == id).ToList().Select(a => a.Product).Select(a => a.Price).Sum();
            return o;

        }

        //list product for prodiver without duplicated 
        public IEnumerable<Product> GetProductProviderDistinced(int id)
        {
            var o = ut.getRepository<OrderPurchase>().GetMany(a => a.Provider.ProviderId == id).Select(a => a.ProductId).Distinct().ToList();
            ICollection<Product> olist = new List<Product>();
            foreach (var item in o)
            {
                var h = ps.GetById(item);
                olist.Add(h);
            }
            return olist.AsEnumerable();
        }


        //get product date order by product id 
        public DateTime GetProductProviderDateOrder(int prodid)
        {
            var o = ut.getRepository<OrderPurchase>().GetMany(a => a.Product.ProductId == prodid).Select(a => a.DateOrder).First();
            return o;

        }

        //get product quantity by product id
        public int GetProductProviderQu(int prodid)
        {
            var o = ut.getRepository<OrderPurchase>().GetMany(a => a.Product.ProductId == prodid).Select(a => a.quantity).First();
            return o;

        }

        //get quantity ordered by provider 
        public int GetQuantityOrderedProvider(int id)
        {
            var o = ut.getRepository<OrderPurchase>().GetMany(a => a.Provider.ProviderId == id).ToList().Select(a => a.Product).Select(a => a.Quantity).Sum();
            return o;
        }


    }
}
