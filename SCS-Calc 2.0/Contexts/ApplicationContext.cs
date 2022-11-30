using Microsoft.EntityFrameworkCore;
using SCSCalc;

namespace SCSCalc_2_0.DataBase
{
    public class ApplicationContext : DbContext
    {
        private string connectionString;

        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Configuration> Configurations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString);
    }
}