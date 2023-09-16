using Job_Weather_Report_Infra.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Job_Weather_Report_Infra.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("database"));
        }
        public DbSet<UserEntity> User { get; set; }
    }
}
