﻿using CompteServicesPattern;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
    public interface ICustomerService : IService<Customer>
    {
        IEnumerable<Customer> GetAllp();
        int NumberCustomers();

    }
}