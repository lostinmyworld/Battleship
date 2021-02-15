using Application;
using AutoMapper;
using Infrastructure;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Battleship.Extensions
{
    internal static class RegisterExtensions
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IGameService, GameService>();

            return services;
        }

        internal static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<DataMapping>();
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
