using System;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator
{
    public class Parcel
    {
        public ParcelSize Size { get; private set; }

        public decimal Weight { get; set; }

        public Parcel(ParcelSize parcelSize, decimal weight)
        {
            Size = parcelSize;
            Weight = weight;
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

        public decimal CalculateAdditionalChargesForWeight()
        {
            decimal extraCharge = 0;

            if (Size == ParcelSize.SMALL && Weight > 1)
            {
                extraCharge = (Weight - 1) * 2;
            }

            if (Size == ParcelSize.MEDIUM && Weight > 3)
            {
                extraCharge = (Weight - 3) * 2;
            }

            if (Size == ParcelSize.LARGE && Weight > 6)
            {
                extraCharge = (Weight - 6) * 2;
            }

            if (Size == ParcelSize.XL && Weight > 10)
            {
                extraCharge = (Weight - 10) * 2;
            }

            return extraCharge;
        }
    }
}