using CompteServicesPattern;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWC.Data.Infrastructure;

namespace CWC.Services
{
    public class ProductFurService : Service<Furniture>, IProductFurService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ProductFurService(): base(ut)
        {
        }
    }
}
