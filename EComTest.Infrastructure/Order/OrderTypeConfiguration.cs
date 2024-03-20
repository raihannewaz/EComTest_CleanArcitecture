using EComTest.Domain.OrderEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure.Order
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<Domain.OrderEntity.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.OrderEntity.Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o=>o.OrderId);
            builder.Property(o=>o.OrderId).UseIdentityColumn();


            builder.Property(o=>o.Quantity).IsRequired();

            builder.Property(o=>o.Total).HasColumnType("decimal(18,2)");

            builder.HasOne(o => o.Product).WithMany().HasForeignKey(o => o.ProductId);

        }
    }
}
