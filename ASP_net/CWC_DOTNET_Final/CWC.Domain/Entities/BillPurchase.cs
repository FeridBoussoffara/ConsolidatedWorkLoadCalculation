﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
    public class BillPurchase:OrderPurchase
    {
        public DateTime DatePurchase { get; set; }
    }
}
