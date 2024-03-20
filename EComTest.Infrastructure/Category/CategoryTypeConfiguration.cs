using EComTest.Domain.CategoryEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure.Category
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<Domain.CategoryEntity.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.CategoryEntity.Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c=>c.CategoryId);
            builder.Property(c=>c.CategoryId).UseIdentityColumn();


            builder.Property(c=>c.CategoryName).IsRequired();
            builder.Property(c=>c.CategoryName).HasMaxLength(100);
        }
    }
}
