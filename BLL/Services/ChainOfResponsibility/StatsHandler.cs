using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.ChainOfResponsibility
{
    public abstract class StatsHandler
    {
        public StatsHandler NextHandler { get; set; }
        public abstract void Handle(ref CalculatedStatsDTO stats);
    }
}