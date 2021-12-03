using System;
using BLL.DTO;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using Moq;
using Xunit;

namespace BLL.Tests
{
    public class ExportServiceTests
    {
        //[Fact]
        //public void Singleton_GetInstance_EqualResult()
        //{
        //    // Assert
        //    Assert.Equal(ExportService.Instance, ExportService.Instance);
        //}
        
        [Fact]
        public void Singleton_GetInstance_NotNullResult()
        {
            //Arrange
            IExportService calcStatsService = ExportService.Instance;

            // Assert
            Assert.NotNull(calcStatsService);
        }
        
        [Fact]
        public void FactoryMethod_UseFactoryMethod_TypeOfClass()
        {
            //Arrange
            IExportService calcStatsService = ExportService.Instance;
            
            // Act
            var type = StatsType.Raw;
            var result = calcStatsService.FactoryMethod(type);
            // Assert
            Assert.Equal(result, typeof(RawStatsDTO).ToString());
        }
        
        [Fact]
        public void FactoryMethod_UseFactoryMethodWithBadParameter_ThrowException()
        {
            //Arrange
            IExportService calcStatsService = ExportService.Instance;
            
            // Act
            var type = StatsType.NotImplemented;
            
            // Assert
            Assert.Throws<NotImplementedException>(() => calcStatsService.FactoryMethod(type));
        }
    }
}