using EComTest.Domain.CategoryEntity;
using EComTest.Domain.OrderEntity;
using EComTest.Domain.ProductEntity;
using EComTest.Infrastructure.Category;
using EComTest.Infrastructure.Order;
using EComTest.Infrastructure.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Domain.CategoryEntity.Category> Categories { get; set; }
        public DbSet<Domain.ProductEntity.Product> Products { get; set; }
        public DbSet<Domain.OrderEntity.Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());

            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
        }
    }
}
