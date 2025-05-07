using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 乐观并发控制;

public class HouseConfig: IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.ToTable("T_Houses");
        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Owner).IsConcurrencyToken();
    }
}