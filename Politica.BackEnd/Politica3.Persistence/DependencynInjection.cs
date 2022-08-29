using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Politica.Application.Interfaces;

namespace Politica.Persistence
{
    public static class DependencynInjection
    {
        public static IServiceCollection AppPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<PoliticaDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IPoliticaDbContext>(provider =>
                provider.GetService<PoliticaDbContext>());
            return services;
        }
    }
}
