using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一对一关系
{
    class OrderConfig: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("T_Orders");
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Name).IsUnicode();
            builder.HasOne(e => e.Delivery).WithOne(e => e.Order).HasForeignKey<Delivery>(e => e.OrderId);
        }
    }
}
