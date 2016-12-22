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
    public class OrderSaleService : Service<OrderSale>, IOrderSaleService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        IProductService pservive = new ProductService();
        ICustomerService cusservive = new CustomerService();


        MyCWCContexte ct = new MyCWCContexte();

        public OrderSaleService() : base(ut)
        {
        }
        public IEnumerable<OrderSale> GetAllp()
        {
            return ct.DbOrderSale.ToList();
        }

        public float CalculateEarningsByMonth(int idProduct, int month)
        {

            Product pr = pservive.GetById(idProduct);
            int quantity=  ut.getRepository<OrderSale>().GetMany(o => o.ProductId == idProduct && o.DateSale.Month==month).Select(p => p.quantity).Sum();

            float result = pr.Price * quantity;
            return result;
        }
        public float CalculateEarningsByProduct(int idProduct )
        {

            Product pr = pservive.GetById(idProduct);
            int quantity = GetAllp().Where(o => o.ProductId == idProduct ).Select(p => p.quantity).Sum();

            float result = pr.Price * quantity;
            return result;
        }

   
        public Product MostSoldProduct()
        {
            List<Product> lsPrds = new List<Product>();
            List<int> lsQuantOrSal = new List<int>();

            
          //  ut.getRepository<OrderSale>().GetAll().Select(o => o.Product).ToList();  : IMPOSSSIBLE de METTRE à JOUR LES NOUVELLES VALEURS
            lsPrds = GetAllp().Select(o => o.Product).ToList();

            int quantityMax = 0;
            int q = 0;
            int id = 0;
            Product MostSoldProduct = new Product();
            foreach (var item in lsPrds)
            {
                //ut.getRepository<OrderSale>().GetMany(o => o.ProductId == item.ProductId).Select(p => p.quantity).Sum(); : IMPOSSSIBLE de METTRE à JOUR LES NOUVELLES VALEURS
                q = GetAllp().Where(o=>o.ProductId==item.ProductId).Select(p => p.quantity).Sum();

                if (q > quantityMax)
                {
                    quantityMax = q;
                    id = item.ProductId;
                }

            }
            MostSoldProduct = pservive.GetById(id);

            return MostSoldProduct;
             
        }


        public List<Customer> ListCustomersByProductID(int id)
        {
            List<int> idssCustomers = ut.getRepository<OrderSale>().GetMany(o => o.ProductId == id).Select(o=>o.CustomerId).ToList();
            List<Customer> lscCustomerw = new List<Customer>();

             foreach (var item in idssCustomers)
            {
                Customer c = cusservive.GetById(item);
                lscCustomerw.Add(c);
            } 
            return lscCustomerw;

        }

        public float GainOfAllProducts()
        {
            List<Product> products = pservive.GetAllp().ToList();
            float result = 0;
            foreach (var item in products)
            {
                result = result + CalculateEarningsByProduct(item.ProductId);

            }
           
            return result;
        }

        public int SumTotalSoldQuantity()
        {
            return GetAllp().Select(p => p.quantity).Sum();
        }

        public int NumberOrders()
        {
            return ut.getRepository<OrderSale>().GetAll().Count();
        }


    }
}
