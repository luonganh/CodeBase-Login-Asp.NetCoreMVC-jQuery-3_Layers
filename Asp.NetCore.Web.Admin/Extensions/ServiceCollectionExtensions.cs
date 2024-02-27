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

        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Identity service
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;

                // Sets the minimum length a password must be
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //options.Lockout.MaxFailedAccessAttempts = 3;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // services.AddTransient<IIdentityService, IdentityService>();

            // autoregister DI
            var assemblyToScan = Assembly.GetAssembly(typeof(IBaseService));
            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
                .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Services"))
                .AsPublicImplementedInterfaces();
                       
            return services;           
        }
    }
}
