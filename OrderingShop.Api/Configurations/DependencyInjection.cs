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