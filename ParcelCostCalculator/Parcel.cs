using System;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator
{
    public class Parcel
    {
        private ParcelSize _parcelSize;

        public Parcel(ParcelSize parcelSize)
        {
            _parcelSize = parcelSize;
        }

        public decimal CalculateShippingCost()
        {
            if (_parcelSize == ParcelSize.SMALL)
            {
                return 3m;
            }
            if (_parcelSize == ParcelSize.MEDIUM)
            {
                return 8m;
            }
            if (_parcelSize == ParcelSize.LARGE)
            {
                return 15m;
            }

            return 25m;
        }
    }
}