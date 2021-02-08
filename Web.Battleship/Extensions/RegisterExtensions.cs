using Api.Battle.Interfaces;
using Api.Battle.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Battleship.Extensions
{
    internal static class RegisterExtensions
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
        }
    }
}
