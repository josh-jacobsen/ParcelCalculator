using System;
using Xunit;

namespace ParcelCostCalculator.Tests
{
    public class ParcelCalculatorTests
    {
        [Theory]
        [InlineData(9, 3)]
        [InlineData(10, 8)]
        [InlineData(50, 15)]
        [InlineData(100, 25)]
        public void Parcel_CalculateShippingCost(decimal parcelDimensions, decimal cost)
        {
            // Arrange 
            var parcel = new Parcel(parcelDimensions);

            // Act
            var result = parcel.CalculateShippingCost();

            // Assert
            Assert.Equal(cost, result);
        }

        [Fact]
        public void CreateParcel_NegativeDimensions_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Parcel(-1));
            Assert.Equal("Dimensions must be a positive number", ex.Message);
        }
    }
}