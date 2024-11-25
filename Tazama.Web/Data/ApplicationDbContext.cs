using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tazama.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<SchemaEntity> Schemas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ensure the base configurations are applied
        base.OnModelCreating(modelBuilder);

        // Configure your SchemaEntity
        modelBuilder.Entity<SchemaEntity>()
            .HasKey(s => s.SchemaId);

        modelBuilder.Entity<SchemaEntity>()
            .HasIndex(s => s.SchemaKey)
            .IsUnique();

        // Add any additional configurations here
    }
}