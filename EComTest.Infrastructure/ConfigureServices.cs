using EComTest.Domain.CategoryEntity;
using EComTest.Domain.OrderEntity;
using EComTest.Domain.ProductEntity;
using EComTest.Infrastructure.CategoryProduct;
using EComTest.Infrastructure.Data;
using EComTest.Infrastructure.Order;
using EComTest.Infrastructure.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbCon"));
            });

            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

            return services;
        }
    }
}
