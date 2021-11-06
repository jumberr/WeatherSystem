﻿using System;
using DAL.Repository.Impl;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private StatsContext db;
        private RawStatsRepository _rawStatsRepository;
        private CalculatedStatsRepository _calculatedStatsRepository;
        
        public EfUnitOfWork(DbContextOptions options)
        {
            db = new StatsContext(options);
        }
        
        public RawStatsRepository RawStats => _rawStatsRepository ??= new RawStatsRepository(db);

        public CalculatedStatsRepository CalculatedStats => _calculatedStatsRepository ??= new CalculatedStatsRepository(db);

        public void Save()
        {
            db.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                _disposed = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}