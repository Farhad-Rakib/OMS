using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Dbcontext
{

    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
             _configuration = configuration; 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database

            options.UseNpgsql(_configuration.GetConnectionString("PgSqlConnectionStringDev"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Window>()
            .Property(w => w.Id)
            .ValueGeneratedOnAdd();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }

    }

}
