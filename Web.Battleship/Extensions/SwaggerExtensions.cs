using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Web.Battleship.Extensions
{
    internal static class SwaggerExtensions
    {
        internal static void AddSomeSwag(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.Battleship", Version = "v1" });
            });
        }
    }
}
