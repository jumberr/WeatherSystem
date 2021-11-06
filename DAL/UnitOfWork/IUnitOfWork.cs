using System;
using DAL.Repository.Impl;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        RawStatsRepository RawStats { get; }
        CalculatedStatsRepository CalculatedStats { get; }
        void Save();
    }
}