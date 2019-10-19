using System;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator
{
    public class Parcel
    {
        public ParcelSize Size { get; private set; }

        public Parcel(ParcelSize parcelSize)
        {
            Size = parcelSize;
        }

        public decimal CalculateShippingCost()
        {
            if (Size == ParcelSize.SMALL)
            {
                return 3m;
            }
            if (Size == ParcelSize.MEDIUM)
            {
                return 8m;
            }
            if (Size == ParcelSize.LARGE)
            {
                return 15m;
            }

            return 25m;
        }
    }
}