using System;
using ParcelCostCalculator.Models;
using Xunit;

namespace ParcelCostCalculator.Tests
{
    public class ParcelCalculatorTests
    {
        [Theory]
        [InlineData(ParcelSize.SMALL, 3)]
        [InlineData(ParcelSize.MEDIUM, 8)]
        [InlineData(ParcelSize.LARGE, 15)]
        [InlineData(ParcelSize.XL, 25)]
        public void CalculateShippingCost_ValidDimensions_Calculates(ParcelSize parcelSize, decimal cost)
        {
            // Arrange 
            var parcel = new Parcel(parcelSize);

            // Act
            var result = parcel.CalculateShippingCost();

            // Assert
            Assert.Equal(cost, result);
        }

        [Fact]
        public void AddParcelToOrder_ValidParcels_AddsParcels()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(ParcelSize.SMALL);
            var mediumParcel = new Parcel(ParcelSize.MEDIUM);

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
            var smallParcel = new Parcel(ParcelSize.SMALL);
            var mediumParcel = new Parcel(ParcelSize.MEDIUM);

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
            var smallParcel = new Parcel(ParcelSize.SMALL);
            var mediumParcel = new Parcel(ParcelSize.MEDIUM);

            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            // Act
            order.SetShippingTypeToSpeedy();

            // Assert
            Assert.Equal(22, order.GetShippingPriceForOrder());
        }
    }
}