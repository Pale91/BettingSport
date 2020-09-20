using BettingSport.API.Helper;
using BettingSport.API.Specifications;
using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Xunit;

namespace BettingSport.Tests.UnitTest.Web
{
    public class PagingSpecificationTest
    {
        [Fact]
        public void ItSetDefaultValues()
        {
            // Act
            PagingSpecification<SportEvent> specification = new PagingSpecification<SportEvent>();

            // Assert
            Assert.Equal(Constants.PAGE_SIZE, specification.PageSize);
            Assert.Equal(Constants.PAGE_NUMBER, specification.PageNumber);
        }

        [Fact]
        public void ItSetDefaultValuesWhenLessThan1()
        {
            // Act
            PagingSpecification<SportEvent> specification = new PagingSpecification<SportEvent>(-1, -1);

            // Assert
            Assert.Equal(Constants.PAGE_SIZE, specification.PageSize);
            Assert.Equal(Constants.PAGE_NUMBER, specification.PageNumber);
        }

        [Fact]
        public void ItSetProvidedValues()
        {
            // Arrange
            int pageNumber = 2;
            int pageSize = 50;

            // Act
            PagingSpecification<SportEvent> specification = new PagingSpecification<SportEvent>(pageSize, pageNumber);

            // Assert
            Assert.Equal(pageSize, specification.PageSize);
            Assert.Equal(pageNumber, specification.PageNumber);
        }
    }
}
