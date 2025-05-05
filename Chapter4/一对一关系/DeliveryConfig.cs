using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一对一关系
{
    class DeliveryConfig:IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("T_Deliverys");
            builder.Property(e => e.CompanyName).IsUnicode().HasMaxLength(10);
            builder.Property(e => e.Number).HasMaxLength(50);
        }
    }
}
