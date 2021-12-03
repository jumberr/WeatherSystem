using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;

namespace BLL.Tests
{
    public class CalcStatsServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
//
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new CalcStatsService(nullUnitOfWork)
            );
        }
//
        [Fact]
        public void GetStats_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            var user = new Admin(1, "TestAdmin", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var streetService = new CalcStatsService(mockUnitOfWork.Object);
//
            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => streetService.GetStats(0));
        }
//
        [Fact]
        public void GetStats_StatsFromDAL_CorrectMappingToStatsDTO()
        {
            // Arrange
            var user = new Director(1, "test", 1);
            SecurityContext.SetUser(user);
            var statsService = GetStatsService();
//
            // Act
            var statsDto = statsService.GetStats(0).First();
//
            // Assert
            Assert.True(
                statsDto.ID == 1 &&
                statsDto.MaxTemperature == 17 && 
                statsDto.MaxPrecipitation == 17 &&
                statsDto.MaxAtmosphericPressure == 17 &&
                statsDto.MaxWindPower == 17
            );
        }
//
        private ICalcStatsService GetStatsService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedStats = new CalculatedStats{ 
                ID = 1,
                MaxTemperature = 17, 
                MaxPrecipitation = 17,
                MaxAtmosphericPressure = 17,
                MaxWindPower = 17
            };
            var mockDbSet = new Mock<ICalculatedStatsRepository>();
            
            mockDbSet
                .Setup(z => 
                    z.Find(
                        It.IsAny<Func<CalculatedStats, bool>>(), 
                        It.IsAny<int>(), 
                        It.IsAny<int>()))
                .Returns(
                    new List<CalculatedStats> { expectedStats }
                );
            mockContext
                .Setup(context =>
                    context.CalculatedStatsRepository)
                .Returns(mockDbSet.Object);
//
            ICalcStatsService calcStatsService = new CalcStatsService(mockContext.Object);
//
            return calcStatsService;
        }
    }
}