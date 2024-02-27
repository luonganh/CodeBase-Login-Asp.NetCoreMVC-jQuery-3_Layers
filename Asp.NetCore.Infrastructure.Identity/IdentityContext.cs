namespace Asp.NetCore.Infrastructure.Identity
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppUser> AppUsers { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });            
        }
    }
}
