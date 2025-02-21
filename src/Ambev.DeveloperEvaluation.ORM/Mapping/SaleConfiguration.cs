using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Number).IsRequired();
            builder.Property(u => u.Date).IsRequired().HasDefaultValueSql("current_timestamp");
            builder.Property(u => u.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.CpfCnpjCustomer).IsRequired().HasMaxLength(20);
            builder.Property(u => u.CompanyName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);

            builder.Property(u => u.TotalValue).IsRequired();

            builder.Property(u => u.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasMany(u => u.Products)
                .WithOne()
                .HasForeignKey(fk => fk.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
