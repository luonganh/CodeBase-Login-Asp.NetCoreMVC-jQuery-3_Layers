using Asp.NetCore.Infrastructure.Identity;
using Asp.NetCore.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Asp.NetCore.Web.Admin.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Add db context
            services.AddDbContext<IdentityContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(Utilities.AppSettings.ConnectionString);
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });

            // Add more another db contexts
            // services.AddDbContext<EXAMPLE_Context>();

            services.AddScoped(typeof(DbContext), typeof(IdentityContext));
            
            return services;
        }
    }
}
