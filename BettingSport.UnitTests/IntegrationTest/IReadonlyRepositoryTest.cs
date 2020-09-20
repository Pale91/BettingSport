using BettingSport.Core.Entities;
using BettingSport.Core.Interfaces;
using BettingSport.Tests.IntegrationTest.Fixture;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BettingSport.Tests.IntegrationTest
{
    [Collection("Service collection")]
    public class IReadonlyRepositoryTest
    {
        InfrastructureFixture fixture;
        public IReadonlyRepositoryTest(InfrastructureFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ItGetsOneRecord()
        {
            // Arrange
            var repository = this.fixture.ServiceProvider.GetService<IReadonlyRepository<SportEvent>>();

            // Act
            var count = repository.GetAll().Count();

            // Assert
            Assert.Equal(1, count);
        }
    }
}
