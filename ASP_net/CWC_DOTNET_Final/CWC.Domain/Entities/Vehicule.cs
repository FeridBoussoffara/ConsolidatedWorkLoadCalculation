using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{
   public class Vehicule: Product
    {
        public int WheelsNbr { get; set; }
        public int Capacity { get; set; }
        public String VehiculeType { get; set; }  
        public float weightveh { get; set; }
    }
}
