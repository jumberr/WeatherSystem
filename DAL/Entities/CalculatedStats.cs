using System.Collections.Generic;

namespace DAL.Entities
{
    public class CalculatedStats
    {
        public int ID { get; set; }

        public IEnumerable<float> Temperature { get; set; }
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        
        public IEnumerable<float> Precipitation { get; set; }
        public float MinPrecipitation { get; set; }
        public float MaxPrecipitation { get; set; }
        
        public IEnumerable<float> WindPower { get; set; }
        public float MinWindPower { get; set; }
        public float MaxWindPower { get; set; }
        
        public IEnumerable<float> AtmosphericPressure { get; set; }
        public float MinAtmosphericPressure { get; set; }
        public float MaxAtmosphericPressure { get; set; }
    }
}