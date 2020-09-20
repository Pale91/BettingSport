using BettingSport.Core.Entities;
using BettingSport.Core.Interfaces;
using BettingSport.Tests.IntegrationTest.Fixture;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions.Ordering;

namespace BettingSport.Tests.IntegrationTest
{
    [Collection("Service collection")]
    [Order(2)]
    public class IRepositoryTest
    {
        InfrastructureFixture fixture;
        public IRepositoryTest(InfrastructureFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact, Order(1)]
        public void AddsNewRecord()
        {
            // Arrange
            var repository = this.fixture.ServiceProvider.GetService<IRepository<SportEvent>>();
            var readonlyRepository = this.fixture.ServiceProvider.GetService<IReadonlyRepository<SportEvent>>();
            var unitOfWork = this.fixture.ServiceProvider.GetService<IUnitOfWork>();

            var newEvent = new SportEvent()
            {
                Name = "New Event",
                OddsForDraw = 1,
                OddsForFirstTeam = 1,
                OddsForSecondTeam = 1,
                StartDate = DateTime.Now
            };

            // Act
            var previousCount = readonlyRepository.GetAll().Count();
            newEvent = repository.Add(newEvent);
            unitOfWork.CommitChanges();
            var count = readonlyRepository.GetAll().Count();

            // Assert
            Assert.Equal(previousCount + 1, count); // The new event was inserted
            Assert.True(newEvent.Id > 0); // Id was assigned
        }

        [Fact, Order(2)]
        public void UpdatesRecord()
        {
            // Arrange
            var repository = this.fixture.ServiceProvider.GetService<IRepository<SportEvent>>();
            var readonlyRepository = this.fixture.ServiceProvider.GetService<IReadonlyRepository<SportEvent>>();
            var unitOfWork = this.fixture.ServiceProvider.GetService<IUnitOfWork>();
            var newName = "Name Updated";
            var newOddValue = 2;
            var _event = readonlyRepository.Get(fixture.DefaultEvent.Id);

            // Act
            _event.Name = newName;
            _event.OddsForDraw = newOddValue;
            _event.OddsForFirstTeam = newOddValue;
            _event.OddsForSecondTeam = newOddValue;
            repository.Update(_event);
            unitOfWork.CommitChanges();
            _event = readonlyRepository.Get(fixture.DefaultEvent.Id); // Retrieving updated event from store

            // Assert
            Assert.Equal(newName, _event.Name);
            Assert.Equal(newOddValue, _event.OddsForDraw);
            Assert.Equal(newOddValue, _event.OddsForFirstTeam);
            Assert.Equal(newOddValue, _event.OddsForSecondTeam);
        }

        [Fact, Order(3)]
        public void DeleteDefault()
        {
            // Arrange
            var repository = this.fixture.ServiceProvider.GetService<IRepository<SportEvent>>();
            var readonlyRepository = this.fixture.ServiceProvider.GetService<IReadonlyRepository<SportEvent>>();
            var unitOfWork = this.fixture.ServiceProvider.GetService<IUnitOfWork>();

            // Act
            var previousCount = readonlyRepository.GetAll().Count();
            repository.Delete(fixture.DefaultEvent.Id);
            unitOfWork.CommitChanges();
            var count = readonlyRepository.GetAll().Count();

            // Assert
            Assert.Equal(previousCount - 1, count); // Record was deleted
        }
    }
}
