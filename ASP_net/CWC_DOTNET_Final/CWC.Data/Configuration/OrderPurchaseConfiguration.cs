using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class OrderPurchaseConfiguration : EntityTypeConfiguration<OrderPurchase>
    {
        public OrderPurchaseConfiguration()
        {
            HasRequired<Product>(p => p.Product).WithMany(o => o.OrderPurchases).HasForeignKey(p => p.ProductId).WillCascadeOnDelete(false);
            HasRequired<Provider>(p => p.Provider).WithMany(o => o.OrderPurchases).HasForeignKey(p => p.ProviderId).WillCascadeOnDelete(false);

            HasKey(o => new { o.ProductId, o.ProviderId });
        }
    }
}
