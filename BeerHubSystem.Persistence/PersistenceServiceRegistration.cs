using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeerHubSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("BeerHubSystemConnectionString")));

            services.AddTransient<IBeerRepository, BeerRepository>();
            services.AddTransient<IWholesalerRepository, WholesalerRepository>();
            services.AddTransient<IBeerSaleRepository, BeerSaleRepository>();

            return services;
        }
    }
}
