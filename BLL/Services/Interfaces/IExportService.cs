using BLL.Services.Impl;

namespace BLL.Services.Interfaces
{
    public interface IExportService
    {
        string FactoryMethod(StatsType type);
    }
}