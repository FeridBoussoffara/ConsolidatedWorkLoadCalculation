using CompteServicesPattern;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
    public interface IOrderSaleService :IService<OrderSale>
    {
        IEnumerable<OrderSale> GetAllp();
        float CalculateEarningsByMonth(int idProduct, int month);
        Product MostSoldProduct();
         List<Customer> ListCustomersByProductID(int id);
         float GainOfAllProducts();
        int SumTotalSoldQuantity();
        int NumberOrders();
    }
}
