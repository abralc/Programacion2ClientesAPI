using Microsoft.EntityFrameworkCore;
using Programacion2ClientesAPI.Models;

namespace Programacion2ClientesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}