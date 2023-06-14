using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Time_Management.Areas.Identity.Data;
using Time_Management.Models;

namespace Time_Management.Areas.Identity.Data;

public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    // (Microsoft, 2020)    available at   https://learn.microsoft.com/en-us/ef/ef6/fundamentals/working-with-dbcontext
    public DbSet<Time_Management.Models.Modules> Modules { get; set; }

    public DbSet<Time_Management.Models.Module_Planning> Module_Planning { get; set; }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.Firstname).HasMaxLength(128);
        builder.Property(u => u.Lastname).HasMaxLength(128);
    }
}