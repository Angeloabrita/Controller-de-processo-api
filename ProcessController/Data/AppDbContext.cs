using Microsoft.EntityFrameworkCore;
using ProcessController.Model;

namespace ProcessController.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }



        public DbSet<Availability> Availability { get; set; }
        public DbSet<Oee> Oee { get; set; }

        public DbSet<Perfomance> Perfomance { get; set;}
        public DbSet<Process> Processs { get; set;}
        public DbSet<ProcessControl> processControls { get; set; }
        public DbSet<Quality> Quality { get; set; }
        public DbSet<ProcessControl> ProcessControl { get; set; } 




    }
}
