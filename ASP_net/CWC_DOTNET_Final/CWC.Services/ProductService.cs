using CompteServicesPattern;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWC.Data.Infrastructure;
using Context;

namespace CWC.Services
{
    public class ProductService : Service<Product>,IProductService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        MyCWCContexte ct = new MyCWCContexte();
        public ProductService(): base(ut)
        {
        }
        public IEnumerable<Product> GetAllp()
        {
            return   ct.DbProduct.ToList();
        }
        public Product GetProductById(int id)
        {
            return ct.DbProduct.Where(p => p.ProductId == id).First();
        }

        public float NormalGainofAllProducts()
        {
            float result = GetAllp().Select(p => p.Price * p.Quantity).Sum();
            return result;
        }
        
        public int SumTotalQuantity() 
        {
            return GetAllp().Select(p => p.Quantity).Sum();
        }
    }
}
