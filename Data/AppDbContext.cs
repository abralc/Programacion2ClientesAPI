using Microsoft.EntityFrameworkCore;
using Programacion2ClientesAPI.Models;

namespace Programacion2ClientesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.CUI)
            .IsUnique();

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.NIT)
            .IsUnique();
    }
}
