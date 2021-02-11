using Api.Battle.Interfaces;
using Api.Battle.Services;
using Api.Battle.Services.Extensions;
using AutoMapper;
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
