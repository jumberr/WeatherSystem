using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Impl
{
    public class StatsContext : DbContext
    {
        public DbSet<RawStats> RawStats { get; set; }
        public DbSet<CalculatedStats> CalculatedStats { get; set; }

        public StatsContext(DbContextOptions options) : base(options)
        {
        }
    }
}