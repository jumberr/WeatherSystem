using System.Collections.Generic;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.ChainOfResponsibility
{
    public class TemperatureHandler : StatsHandler
    {
        public override void Handle(ref CalculatedStatsDTO stats)
        {
            stats.Temperature = new List<float> {0, 1, 3, 6};
            NextHandler?.Handle(ref stats);
        }
    }
}