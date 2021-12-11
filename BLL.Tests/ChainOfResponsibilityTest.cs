using BLL.DTO;
using BLL.Services.ChainOfResponsibility;
using Xunit;

namespace BLL.Tests
{
    public class ChainOfResponsibilityTest
    {
        [Fact]
        public void CoR_StartChain_CollectionsAreNotEmpty()
        {
            var atm = new AtmospericHandler();
            var rain = new RainStatsHandler();
            var wind = new WindHandler();
            var temp = new TemperatureHandler();

            var stats = new CalculatedStatsDTO(1);
            atm.NextHandler = rain;
            rain.NextHandler = wind;
            wind.NextHandler = temp;
            
            atm.Handle(ref stats);
            
            Assert.NotEmpty(stats.Precipitation);
            Assert.NotEmpty(stats.Temperature);
            Assert.NotEmpty(stats.AtmosphericPressure);
            Assert.NotEmpty(stats.WindPower);
        }
        
        [Fact]
        public void CoR_StartChain_SomeCollectionsAreEmpty()
        {
            var atm = new AtmospericHandler();
            var rain = new RainStatsHandler();

            var stats = new CalculatedStatsDTO(1);
            atm.NextHandler = rain;
            
            atm.Handle(ref stats);
            
            Assert.NotEmpty(stats.Precipitation);
            Assert.NotEmpty(stats.AtmosphericPressure);
            
            Assert.Empty(stats.Temperature);
            Assert.Empty(stats.WindPower);
        }
    }
}