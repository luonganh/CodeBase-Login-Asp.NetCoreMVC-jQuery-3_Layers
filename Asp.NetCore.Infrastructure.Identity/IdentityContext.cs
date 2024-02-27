﻿namespace Asp.NetCore.Infrastructure.Identity
{
    public class IdentityContext : IdentityDbContext<Entities.AppUser, Entities.AppRole, Guid>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        public DbSet<Entities.AppRole> AppRoles { set; get; }
        public DbSet<Entities.AppUser> AppUsers { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });

            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
        }
    }

    /// <summary>
    /// Db context creation
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            // get path of assembly that contains appsettings json files
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Asp.NetCore.Web.Admin");

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)            
            .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(AppSettings.AspNetCoreEnvironment) ?? "Production"}.json",
                optional: true,
                reloadOnChange: true)
            .Build();

            throw new NotImplementedException();
        }
    }
}
