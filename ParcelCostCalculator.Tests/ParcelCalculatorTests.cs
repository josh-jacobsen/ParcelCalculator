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
        public void CalculateShippingCost_ValidDimensions_Calculates(decimal parcelDimensions, decimal cost)
        {
            // Arrange 
            var parcel = new Parcel(parcelDimensions);

            // Act
            var result = parcel.CalculateShippingCost();

            // Assert
            Assert.Equal(cost, result);
        }

        [Fact]
        public void CalculateShippingCost_NegativeDimensions_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Parcel(-1));
            Assert.Equal("Dimensions must be a positive number", ex.Message);
        }

        [Fact]
        public void AddParcelToOrder_ValidParcels_AddsParcels()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(1);
            var mediumParcel = new Parcel(10);

            // Act
            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            // Assert
            Assert.Equal(2, order.Parcels.Count);
        }

        [Fact]
        public void GetShippingPriceForOrder_ValidParcelsInOrder_Calculates()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(1);
            var mediumParcel = new Parcel(10);

            // Act
            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            // Assert
            Assert.Equal(11, order.GetShippingPriceForOrder());
        }

        [Fact]
        public void GetShippingPriceForOrder_NoParcelsInOrder_Returns0()
        {
            // Arrange 
            var order = new Order();

            // Act

            // Assert
            Assert.Equal(0, order.GetShippingPriceForOrder());
        }

        [Fact]
        public void ShippingType_SpeedyShipping_DoublesShippingCost()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(1);
            var mediumParcel = new Parcel(10);

            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            // Act
            order.SetShippingTypeToSpeedy();

            // Assert
            Assert.Equal(22, order.GetShippingPriceForOrder());
        }
    }
}