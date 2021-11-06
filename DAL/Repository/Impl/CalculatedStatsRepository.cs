using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Impl
{
    public class CalculatedStatsRepository : BaseRepository<CalculatedStats>, ICalculatedStatsRepository
    {
        internal CalculatedStatsRepository(DbContext context) : base(context)
        {
        }
    }
}