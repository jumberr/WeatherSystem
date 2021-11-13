using DAL.Entities;
using DAL.Repository.Impl;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputCalculatedStatsInstance_CalledAddMethodOfDBSetWithCalculatedStatsInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StatsContext>()
                .Options;
            var mockContext = new Mock<StatsContext>(opt);
            var mockDbSet = new Mock<DbSet<CalculatedStats>>();
            mockContext
                .Setup(context => 
                    context.Set<CalculatedStats>(
                    ))
                .Returns(mockDbSet.Object);
            var repository = new TestCalcStatsRepository(mockContext.Object);
            var expectedStats = new Mock<CalculatedStats>().Object;

            //Act
            repository.Create(expectedStats);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStats
                ), Times.Once());
        }
        
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StatsContext>()
                .Options;
            var mockContext = new Mock<StatsContext>(opt);
            var mockDbSet = new Mock<DbSet<CalculatedStats>>();
            mockContext
                .Setup(context =>
                    context.Set<CalculatedStats>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestCalcStatsRepository(mockContext.Object);

            var expectedStats = new CalculatedStats { ID = 1};
            mockDbSet.Setup(mock => mock.Find(expectedStats.ID)).Returns(expectedStats);

            //Act
            repository.Delete(expectedStats.ID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStats.ID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStats
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StatsContext>()
                .Options;
            var mockContext = new Mock<StatsContext>(opt);
            var mockDbSet = new Mock<DbSet<CalculatedStats>>();
            mockContext
                .Setup(context =>
                    context.Set<CalculatedStats>(
                        ))
                .Returns(mockDbSet.Object);

            var expectedStats = new CalculatedStats { ID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStats.ID))
                    .Returns(expectedStats);
            var repository = new TestCalcStatsRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStats.ID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStats.ID
                    ), Times.Once());
            Assert.Equal(expectedStats, actualStreet);
        }
        
    }
}