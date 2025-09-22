using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVZPP_Calc.net8.model;

namespace MVZPP_Calc.net8.data
{
    public class AppData : DbContext
    {
        public DbSet<KNPR_GG_CALC_RES> GG_result { get; set; }
        public DbSet<NKPR_LVZH_CALC_RES> PP_result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./data/local/AppLocalDBSet.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
