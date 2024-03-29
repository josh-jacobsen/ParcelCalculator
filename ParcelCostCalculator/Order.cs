using System;
using System.Collections.Generic;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator
{
    public class Order
    {
        public List<Parcel> Parcels { get; private set; } = new List<Parcel>();
        public ShippingType ShippingType { get; private set; } = ShippingType.NORMAL;

        public void AddParcelToOrder(Parcel parcel)
        {
            Parcels.Add(parcel);
        }

        public decimal GetTotalShippingPriceForOrder()
        {
            var totalShippingPrice = GetBaseShippingPrice();

            if (ShippingType == ShippingType.SPEEDY_SHIPPING)
            {
                return totalShippingPrice * 2;
            }

            return totalShippingPrice;
        }

        private decimal GetBaseShippingPrice()
        {
            decimal shippingPrice = 0;

            foreach (var parcel in Parcels)
            {
                shippingPrice += parcel.CalculateShippingCost();
            }

            return shippingPrice;
        }

        public void SetShippingTypeToSpeedy()
        {
            ShippingType = ShippingType.SPEEDY_SHIPPING;
        }

        public override string ToString()
        {
            var output = "";
            for (int i = 0; i < Parcels.Count; i++)
            {
                output += $@"Parcel {i + 1} is {Parcels[i].Size} and will cost ${string.Format("{0:0.00}", Parcels[i].CalculateShippingCost())} to send {Environment.NewLine}";
            }

            output += $@"The base cost for the order is ${string.Format("{0:0.00}", GetBaseShippingPrice())} {Environment.NewLine}";

            if (ShippingType == ShippingType.SPEEDY_SHIPPING)
            {
                output += $@"You have chosen speedy shiping, so the total price of your order is ${string.Format("{0:0.00}", GetTotalShippingPriceForOrder())} {Environment.NewLine}";
            }

            return output;
        }
    }
}