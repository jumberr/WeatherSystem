using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.ChainOfResponsibility
{
    public class AtmospericHandler : StatsHandler
    {
        public override void Handle(ref CalculatedStatsDTO stats)
        {
            stats.AtmosphericPressure = new List<float> {0, 1, 3, 6};
            NextHandler?.Handle(ref stats);
        }
    }
}