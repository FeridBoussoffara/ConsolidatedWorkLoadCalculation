﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class Furniture: Product
    {
        public float weightFur { get; set; }
        public String Material { get; set; }
    }
}