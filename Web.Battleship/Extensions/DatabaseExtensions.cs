using Data.EfCore.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Battleship.Extensions
{
    internal static class DatabaseExtensions
    {
        internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BattleShipContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("BattleshipDb")
                    , b => b.MigrationsAssembly("Web.Battleship")));

            services.AddScoped<IBattleshipRepository, BattleshipRepository>();

            return services;
        }
    }
}
