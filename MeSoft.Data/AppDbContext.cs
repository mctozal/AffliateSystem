using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MeSoft.Data.Configurations;
using MeSoft.Core.EntityModels;

namespace MeSoft.Data
{

    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection"), sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); });

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // apply configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
 
        }

    }
}
