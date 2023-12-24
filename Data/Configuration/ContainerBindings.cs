using Data.Base;
using Data.Repositories;
using Domain.Abstractions;
using Domain.Products.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;

namespace Data.Configuration
{
    public class ContainerBindings
    {
        public static void AddRepositories(IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<ExpressContext>(
            opt => opt.UseSqlServer(connectionString == null ? "dev" : connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
        }
    }
}
