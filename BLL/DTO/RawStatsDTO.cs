using System.Collections.Generic;

namespace BLL.DTO
{
    public class RawStatsDTO
    {
        public int ID { get; set; }

        public IEnumerable<float> Temperature { get; set; }
        public IEnumerable<float> Precipitation { get; set; }
        public IEnumerable<float> WindPower { get; set; }
        public IEnumerable<float> AtmosphericPressure { get; set; }
    }
}