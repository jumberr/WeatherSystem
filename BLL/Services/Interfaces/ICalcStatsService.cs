using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ICalcStatsService
    {
        IEnumerable<CalculatedStatsDTO> GetStats(int page);
    }
}