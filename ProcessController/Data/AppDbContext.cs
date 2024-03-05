using Microsoft.EntityFrameworkCore;
using ProcessController.Model;

namespace ProcessController.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        }

        public DbSet<Availability> Availability { get; set; }
        public DbSet<Perfomance> Perfomance { get; set;}
        public DbSet<Process> Processs { get; set;}
        public DbSet<Quality> Quality { get; set; }
        public DbSet<ProcessController.Model.ProcessControl> ProcessControl { get; set; } = default!;

    }
}
