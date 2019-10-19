using System;

namespace ParcelCostCalculator
{
    public class Parcel
    {
        public decimal Dimensions;

        public Parcel(decimal dimensions)
        {
            if (dimensions < 0)
            {
                throw new ArgumentException("Dimensions must be a positive number");
            }

            Dimensions = dimensions;
        }

        public decimal CalculateShippingCost()
        {
            if (Dimensions < 10)
            {
                return 3m;
            }
            if (Dimensions < 50)
            {
                return 8m;
            }
            if (Dimensions < 100)
            {
                return 15m;
            }

            return 25m;
        }
    }
}