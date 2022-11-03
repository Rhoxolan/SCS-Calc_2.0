using Microsoft.EntityFrameworkCore;
using SCSCalc;
using System.Collections.ObjectModel;

namespace SCS_Calc_2._0
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Configuration> Configurations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=configurations.db");
        }
    }
}
