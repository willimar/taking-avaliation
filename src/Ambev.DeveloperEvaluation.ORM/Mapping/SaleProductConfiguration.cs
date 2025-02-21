using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ToTable("SalesProducts");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(u => u.SaleId);
        builder.HasIndex(u => u.ProductId);

        builder.Property(u => u.ProductName).IsRequired().HasMaxLength(100);

        builder.Property(u => u.UnitValue).IsRequired();
        builder.Property(u => u.Discount).IsRequired();
        builder.Property(u => u.TotalUnityValue).IsRequired();
        builder.Property(u => u.Count).IsRequired();

        builder.Property(u => u.Canceled).IsRequired().HasDefaultValue(false);

        builder.HasOne(u => u.Product).WithMany().HasForeignKey(u => u.ProductId);
    }
}
