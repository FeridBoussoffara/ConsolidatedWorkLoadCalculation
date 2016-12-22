using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Configuration
{
    public class OrderSaleConfiguration : EntityTypeConfiguration<OrderSale>
    {
        public OrderSaleConfiguration()
        {
            HasRequired<Product>(p => p.Product).WithMany(o => o.OrderSales).HasForeignKey(p => p.ProductId).WillCascadeOnDelete(false);
            HasRequired<Customer>(p => p.customer).WithMany(o => o.OrderSales).HasForeignKey(p => p.CustomerId).WillCascadeOnDelete(false);
            Property(p => p.DateSale).IsOptional();
            HasKey(o => new { o.ProductId, o.CustomerId });
        }
    }
}
