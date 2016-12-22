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
    public class EmployeeService : Service<Employee>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public EmployeeService() : base(ut)
        {

        }
       
        
       
        }
    }

