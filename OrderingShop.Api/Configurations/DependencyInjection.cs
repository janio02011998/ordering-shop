﻿using Microsoft.EntityFrameworkCore;
using OrderingShop.Domain.Interfaces;
using OrderingShop.Domain.Mappings;
using OrderingShop.Domain.Services;
using OrderingShop.Infrastructure.Interfaces;
using OrderingShop.Infrastructure.Repositories;
using OrderingShop.Infrastructure.Context;

namespace OrderingShop.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        }
    }
}