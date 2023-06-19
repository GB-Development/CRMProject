using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Deal> Deals { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Company>()
        .HasIndex(e => e.CompanyName)
        .IsUnique();

        builder.Entity<Company>()
        .HasIndex(e => e.INN)
        .IsUnique();

        builder.Entity<Contact>()
        .HasIndex(e => e.FullName)
        .IsUnique();
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
}
