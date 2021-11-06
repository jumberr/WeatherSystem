using DAL.Entities;
using DAL.Repository.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestCalcStatsRepository : BaseRepository<CalculatedStats>
    {
        public TestCalcStatsRepository(DbContext context) : base(context)
        {
        }
    }
}