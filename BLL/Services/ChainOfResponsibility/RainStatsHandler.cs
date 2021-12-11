using System.Collections.Generic;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.ChainOfResponsibility
{
    public class RainStatsHandler : StatsHandler
    {
        public override void Handle(ref CalculatedStatsDTO stats)
        {
            stats.Precipitation = new List<float> {0, 1, 3, 6};
            NextHandler?.Handle(ref stats);
        }
    }
}