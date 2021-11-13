using System;
using DAL.Repository.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRawStatsRepository RawStatsRepository { get; }
        ICalculatedStatsRepository CalculatedStatsRepository { get; }
        void Save();
    }
}