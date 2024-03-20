using EComTest.Domain.ProductEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure.Product
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Domain.ProductEntity.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductEntity.Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.ProductId);
            builder.Property(p=>p.ProductId).UseIdentityColumn();

            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.ProductName).HasMaxLength(250);

            builder.Property(p=>p.Price).IsRequired();
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");


            builder.HasOne(o => o.Category).WithMany().HasForeignKey(o => o.CategoryId);

        }
    }
}
