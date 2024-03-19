using EComTest.Domain.CategoryEntity;
using EComTest.Domain.OrderEntity;
using EComTest.Domain.ProductEntity;
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

        public DbSet<Category> Categories { get; set; }
        public DbSet<EComTest.Domain.ProductEntity.Product> Products { get; set; }
        public DbSet<EComTest.Domain.OrderEntity.Order> Orders { get; set; }
        
    }
}
