using System.Collections.Generic;

namespace BLL.DTO
{
    public class CalculatedStatsDTO
    {
        public CalculatedStatsDTO(int id)
        {
            ID = id;
        }

        public int ID { get; set; }

        public IEnumerable<float> Temperature { get; set; } = new List<float>();
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        
        public IEnumerable<float> Precipitation { get; set; } = new List<float>();
        public float MinPrecipitation { get; set; }
        public float MaxPrecipitation { get; set; }
        
        public IEnumerable<float> WindPower { get; set; } = new List<float>();
        public float MinWindPower { get; set; }
        public float MaxWindPower { get; set; }
        
        public IEnumerable<float> AtmosphericPressure { get; set; } = new List<float>();
        public float MinAtmosphericPressure { get; set; }
        public float MaxAtmosphericPressure { get; set; }
    }
}