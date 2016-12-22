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
    public class ProviderServices : Service<Provider>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        ProductService ps = new ProductService();


        public ProviderServices(): base(ut)
        {
        }


        //get product by provider
        public List<Product> GetProductsByProvider(Provider pp)
        {
            return ut.getRepository<Product>().GetAll().Where(o => o.OrderPurchases.Select(a => a.ProviderId == pp.ProviderId).FirstOrDefault()).ToList();

        }

        //get most product ordered by provider id
        public Product GetMostProductByProvider(Provider p)
        {
            List<Product> pp = GetProductsByProvider(p);
            var p1 = pp.GroupBy(prod => prod.ProductId).OrderByDescending(g => g.Key).First();
            return ut.getRepository<Product>().GetById(p1.Key);

        }

        //get product for all provider by region
        public IEnumerable<Product> GetProductProviderRegion(string Adresse)
        {
            var o = ut.getRepository<OrderPurchase>().GetMany(p => p.Provider.Adresse == Adresse).Select(a => a.ProductId).ToList();
            ICollection<Product> olist = new List<Product>();
            foreach (var item in o)
            {
                var h = ps.GetById(item);
                olist.Add(h);
            }
            return olist.AsEnumerable();


        }


        //get all provider by region
        public List<Provider> GetProviderByRegion(string Adresse)
        {
            return ut.getRepository<Provider>().GetMany(p => p.Adresse == Adresse).OrderBy(p => p.Name).ToList<Provider>();
        }


        //count provider in specific region {used in stat }
        public int GetProviderNumberByRegion(string Adresse)
        {
            return ut.getRepository<Provider>().GetMany(p => p.Adresse == Adresse).Count();
        }


        //get list region of provider {used in map stat}
        public List<String> GetListAdresseProviders()
        {
            return ut.getRepository<Provider>().GetAll().Select(p => p.Adresse).ToList();
        }


        //get most requested provider by company 
        public Provider MostActiveProvider()
        {
            var e = ut.getRepository<OrderPurchase>().GetAll().Select(a => a.Provider).GroupBy(p => p.ProviderId).OrderByDescending(g => g.Key).First();
            return ut.getRepository<Provider>().GetById(e.Key);
        }


    }
}
