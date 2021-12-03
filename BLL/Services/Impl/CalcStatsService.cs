﻿using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.EF;
using DAL.Entities;
using DAL.Repository.Impl;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Impl
{
    public class CalcStatsService : ICalcStatsService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public CalcStatsService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public IEnumerable<CalculatedStatsDTO> GetStats(int page)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                && userType != typeof(Employee))
            {
                throw new MethodAccessException();
            }
            var weatherId = user.WeatherId;
            var statsEntities = _database.CalculatedStatsRepository
                .Find(z => z.ID == weatherId, page, pageSize);
            
            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<CalculatedStats, CalculatedStatsDTO>()).CreateMapper();
            
            var statsDto = mapper
                .Map<IEnumerable<CalculatedStats>, List<CalculatedStatsDTO>>(statsEntities);
            return statsDto;
        }
    }
}