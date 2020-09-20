using BettingSport.API.Specifications.SportEvent;
using BettingSport.Tests.UnitTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BettingSport.Tests.UnitTest.Web
{
    public class SportEventNameFilterSpecificationTest
    {
        [Theory]
        [InlineData("1", 11)] // 1, 10-19
        [InlineData("2", 2)]  // 2, 12
        [InlineData("19", 1)]  // 19
        [InlineData("55", 0)]
        public void FilterByName(string substring, int expectedCount)
        {
            // Arrange
            var numbersOfItems = 20;
            var data = SportEventData.GenerateData(numbersOfItems);
            var specification = new SportEventNameFilterSpecification(substring);

            // Act
            var count = data.Where(specification.Criteria.Compile()).Count();

            // Assert
            Assert.Equal(expectedCount, count);
        }


    }
}
