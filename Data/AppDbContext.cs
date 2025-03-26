using CloudDoc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudDoc.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>()
            .HasMany(u=>u.Documents)
            .WithOne(d=>d.User)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);

    }
    public DbSet<Document> Documents { get; set; } = null!;

}
