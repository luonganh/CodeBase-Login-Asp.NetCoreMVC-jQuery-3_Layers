namespace Asp.NetCore.Infrastructure.Identity.EntityConfigurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<Entities.AppRole>
    {
        public void Configure(EntityTypeBuilder<Entities.AppRole> builder)
        {
            builder.ToTable("AppRoles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(254).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Description).HasMaxLength(254);
            builder.Property(x => x.CreatedBy).HasMaxLength(36);
            builder.Property(x => x.UpdatedBy).HasMaxLength(36);
            builder.Property(x => x.DeletedBy).HasMaxLength(36);
        }
    }
}