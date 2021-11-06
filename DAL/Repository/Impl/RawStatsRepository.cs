using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Impl
{
    public class RawStatsRepository : BaseRepository<RawStats>, IRawStatsRepository
    {
        internal RawStatsRepository(DbContext context) : base(context)
        {
        }
    }
}