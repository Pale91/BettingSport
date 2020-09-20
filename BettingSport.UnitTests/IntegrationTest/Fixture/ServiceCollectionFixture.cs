using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BettingSport.Tests.IntegrationTest.Fixture
{
    [CollectionDefinition("Service collection")]
    public class ServiceCollectionFixture: ICollectionFixture<InfrastructureFixture>
    {
    }
}
