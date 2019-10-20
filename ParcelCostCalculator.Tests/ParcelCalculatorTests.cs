using System;
using ParcelCostCalculator.Models;
using Xunit;

namespace ParcelCostCalculator.Tests
{
    public class ParcelCalculatorTests
    {
        [Theory]
        [InlineData(ParcelSize.SMALL, 1, 3)]
        [InlineData(ParcelSize.MEDIUM, 1, 8)]
        [InlineData(ParcelSize.LARGE, 1, 15)]
        [InlineData(ParcelSize.XL, 1, 25)]
        public void CalculateShippingCost_ValidDimensions_Calculates(ParcelSize parcelSize, decimal parcelWeight, decimal cost)
        {
            // Arrange 
            var parcel = new Parcel(parcelSize, parcelWeight);

            // Act
            var result = parcel.CalculateShippingCost();

            // Assert
            Assert.Equal(cost, result);
        }

        [Theory]
        [InlineData(ParcelSize.SMALL, 1, 0)]
        [InlineData(ParcelSize.SMALL, 1.5, 1)]
        [InlineData(ParcelSize.SMALL, 2, 2)]
        [InlineData(ParcelSize.SMALL, 3.33, 4.66)]
        [InlineData(ParcelSize.SMALL, 8, 14)]
        [InlineData(ParcelSize.MEDIUM, 3, 0)]
        [InlineData(ParcelSize.MEDIUM, 3.125, 0.25)]
        [InlineData(ParcelSize.MEDIUM, 10, 14)]
        [InlineData(ParcelSize.LARGE, 7.5, 3)]
        [InlineData(ParcelSize.LARGE, 11, 10)]
        [InlineData(ParcelSize.XL, 7.5, 0)]
        [InlineData(ParcelSize.XL, 11, 2)]
        [InlineData(ParcelSize.XL, 20, 20)]
        public void CalculateAdditionalChargesForWeight_OverLimit_CalculatesCorrectValues(ParcelSize parcelSize, decimal parcelWeight, decimal additionalCharge)
        {
            // Arrange 
            var parcel = new Parcel(parcelSize, parcelWeight);

            // Act
            var result = parcel.CalculateAdditionalChargesForWeight();

            // Assert
            Assert.Equal(additionalCharge, result);
        }

        [Fact]
        public void AddParcelToOrder_ValidParcels_AddsParcels()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(ParcelSize.SMALL, 1);
            var mediumParcel = new Parcel(ParcelSize.MEDIUM, 1);

            // Act
            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            // Assert
            Assert.Equal(2, order.Parcels.Count);
        }

        [Fact]
        public void GetTotalShippingPriceForOrder_NormalShipping_ReturnsBasePrice()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(ParcelSize.SMALL, 1);
            var mediumParcel = new Parcel(ParcelSize.MEDIUM, 1);

            // Act
            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            // Assert
            Assert.Equal(11, order.GetTotalShippingPriceForOrder());
        }

        [Fact]
        public void GetTotalShippingPriceForOrder_NoParcelsInOrder_Returns0()
        {
            // Arrange 
            var order = new Order();

            // Act

            // Assert
            Assert.Equal(0, order.GetTotalShippingPriceForOrder());
        }

        [Fact]
        public void GetTotalShippingPriceForOrder_SpeedyShipping_DoublesShippingCost()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(ParcelSize.SMALL, 1);
            var mediumParcel = new Parcel(ParcelSize.MEDIUM, 1);

            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            // Act
            order.SetShippingTypeToSpeedy();

            // Assert
            Assert.Equal(22, order.GetTotalShippingPriceForOrder());
        }

        [Fact]
        public void ToString_WithParcels_OutputsAllFields()
        {
            // Arrange 
            var order = new Order();
            var smallParcel = new Parcel(ParcelSize.SMALL, 1);
            var mediumParcel = new Parcel(ParcelSize.MEDIUM, 1);

            order.AddParcelToOrder(smallParcel);
            order.AddParcelToOrder(mediumParcel);

            order.SetShippingTypeToSpeedy();

            // Act
            var output = order.ToString();

            // Assert
            Assert.Equal("Parcel 1 is SMALL and will cost $3.00 to send \nParcel 2 is MEDIUM and will cost $8.00 to send \nThe base cost for the order is $11.00 \nYou have chosen speedy shiping, so the total price of your order is $22.00 \n", output);
        }
    }
}