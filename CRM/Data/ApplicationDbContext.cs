using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Deal> Deals { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
}
