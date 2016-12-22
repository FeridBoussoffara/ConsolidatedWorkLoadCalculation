using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product> 
    {
        public ProductConfiguration()
        {
            Map<Furniture>(c => c.Requires("Type").HasValue("Furniture"));
            Map<Electronic>(c => c.Requires("Type").HasValue("Electronic"));
            Map<Software>(c => c.Requires("Type").HasValue("Software"));
            Map<Vehicule>(c => c.Requires("Type").HasValue("Vehicule") );
            Map<Agriculture>(c => c.Requires("Type").HasValue("Agriculture"));
        }
    }
}
