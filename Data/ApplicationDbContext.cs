using Microsoft.EntityFrameworkCore;
using CrudCannia.Models;

namespace CrudCannia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Propietario> Propietarios { get; set; }

    }
}

