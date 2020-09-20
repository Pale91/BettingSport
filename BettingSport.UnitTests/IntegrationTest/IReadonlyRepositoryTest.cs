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
    [Order(1)]
    public class IReadonlyRepositoryTest
    {
        InfrastructureFixture fixture;
        public IReadonlyRepositoryTest(InfrastructureFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact, Order(1)]
        public void ItGetsOneRecord()
        {
            // Arrange
            var repository = this.fixture.ServiceProvider.GetService<IReadonlyRepository<SportEvent>>();

            // Act
            var count = repository.GetAll().Count();

            // Assert
            Assert.Equal(1, count);
        }

        [Fact, Order(1)]
        public void ItFindById()
        {
            // Arrange
            var repository = this.fixture.ServiceProvider.GetService<IReadonlyRepository<SportEvent>>();
            var defaultEvent = this.fixture.DefaultEvent;

            // Act
            var _event = repository.Get(defaultEvent.Id);

            // Assert
            Assert.NotNull(_event);
            Assert.Equal(defaultEvent.Id, _event.Id);
        }
    }
}
