using System;
using BLL.DTO;
using BLL.Services.HelperClasses;
using BLL.Services.Interfaces;

namespace BLL.Services.Impl
{
    public enum StatsType
    {
        Raw,
        Calculated,
        NotImplemented
    }

    public class ExportService : Component, IExportService
    {
        private static ExportService _instance;

        private ExportService() { }

        public static ExportService Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new ExportService();
                }

                return _instance;
            }
        }

        public string FactoryMethod(StatsType type)
        {
            switch (type)
            {
                case StatsType.Raw:
                    return $"{typeof(RawStatsDTO)}";
                case StatsType.Calculated:
                    return $"{typeof(CalculatedStatsDTO)}";
            }

            throw new NotImplementedException();
        }
    }
}