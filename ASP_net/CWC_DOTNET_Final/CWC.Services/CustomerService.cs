using CompteServicesPattern;
using Context;
using CWC.Data.Infrastructure;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
 
    public   class CustomerService : Service<Customer>, ICustomerService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        MyCWCContexte ct = new MyCWCContexte();

        public CustomerService() : base(ut)
        {
                
        }

        public IEnumerable<Customer> GetAllp()
        {
            return ct.DbCustomer.ToList();
        }

        public int NumberCustomers()
        {
            return GetAllp().Count();
        }
    }
}
