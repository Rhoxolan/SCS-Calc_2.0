using Microsoft.EntityFrameworkCore;
using SCSCalc;

namespace SCSCalc_2_0.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Configuration> Configurations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=configurations.db");
    }
}