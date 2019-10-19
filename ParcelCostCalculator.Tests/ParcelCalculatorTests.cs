using System;
using Xunit;

namespace ParcelCostCalculator.Tests
{
    public class ParcelCalculatorTests
    {
        private readonly ParcelCalculator _parcelCalculator;

        public ParcelCalculatorTests()
        {
            // Arrange 
            _parcelCalculator = new ParcelCalculator();
        }

        [Theory]
        [InlineData(9, 3)]
        [InlineData(10, 8)]
        [InlineData(50, 15)]
        [InlineData(100, 25)]
        public void CalculateCostFromDimensions_CalculatesCorrectCost(decimal parcelDimensions, decimal cost)
        {
            // Act
            var result = _parcelCalculator.CalculateCostFromDimensions(parcelDimensions);

            // Assert
            Assert.Equal(cost, result);
        }

        [Fact]
        public void CalculateCostFromDimensions_NegativeDimensions_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _parcelCalculator.CalculateCostFromDimensions(-1));
        }
    }
}