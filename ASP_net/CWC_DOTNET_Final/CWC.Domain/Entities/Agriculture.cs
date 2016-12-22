using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Domain.Entities
{

   public enum CategoryAgriculture
    {
        Vegetable,
        Fruit
    }
    public class Agriculture: Product
    {
        public CategoryAgriculture Category { get; set; }
        public DateTime ValidityDate { get; set; }
    }
}
