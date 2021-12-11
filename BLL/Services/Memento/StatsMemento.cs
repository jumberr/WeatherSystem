using BLL.DTO;

namespace BLL.Services.Memento
{
    public class StatsMemento // Memento
    {
        public CalculatedStatsDTO CalculatedStats { get; private set; }
 
        public StatsMemento(CalculatedStatsDTO calculatedStats)
        {
            CalculatedStats = calculatedStats;
        }
    }
}