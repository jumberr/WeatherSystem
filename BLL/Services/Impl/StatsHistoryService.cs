using BLL.DTO;
using BLL.Services.Memento;

namespace BLL.Services.Impl
{
    public class StatsHistoryService // originator
    {
        private CalculatedStatsDTO _last;

        public void AddStats(CalculatedStatsDTO dto)
        {
            _last = dto;
        }

        public StatsMemento SaveState()
        {
            return new StatsMemento(_last);
        }
        
        public void RestoreState(StatsMemento stats)
        {
            _last = stats.CalculatedStats;
        }
    }
}