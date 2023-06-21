using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CRM.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Company>()
        .HasIndex(e => e.CompanyName)
        .IsUnique();

        builder.Entity<Company>()
        .HasIndex(e => e.INN)
        .IsUnique();
    }

    internal void GetService<T>(List<Deal> items)
    {
        throw new NotImplementedException();
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
}
