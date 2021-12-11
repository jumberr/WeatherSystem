using BLL.DTO;
using BLL.Services.HelperClasses;
using BLL.Services.Impl;
using BLL.Services.Memento;
using Xunit;

namespace BLL.Tests
{
    public class MementoTests
    {
        [Fact]
        public void Memento_AddToService()
        {
            Initialize(out var service, out var history, out var memento, out var dto);
            Assert.Equal(memento, history.History.Peek());
            Assert.Equal(dto, history.History.Peek().CalculatedStats);
        }
        
        [Fact]
        public void Memento_RemoveFromService()
        {
            Initialize(out var service, out var history, out var memento, out var dto);

            service.AddStats(new CalculatedStatsDTO(2)); 
            history.History.Push(memento);
            history.History.Pop();
            
            service.RestoreState(history.History.Peek());
            Assert.Equal(memento, history.History.Peek());
            Assert.Equal(dto, history.History.Peek().CalculatedStats);
        }

        private void Initialize(out StatsHistoryService service, out StatsHistory history,
            out StatsMemento memento, out CalculatedStatsDTO dto)
        {
            service = new StatsHistoryService();
            dto = new CalculatedStatsDTO(1);
            service.AddStats(dto);
            history = new StatsHistory();

            memento = service.SaveState();
            history.History.Push(memento);
        }
    }
}