using EComTest.Domain.OrderEntity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace EComTest.Application
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(c=>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });


            return services;
        }
    }
}
