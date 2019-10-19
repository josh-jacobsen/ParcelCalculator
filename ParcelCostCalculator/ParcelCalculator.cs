using System;

namespace ParcelCostCalculator
{
    public class ParcelCalculator
    {
        public decimal CalculateCostFromDimensions(decimal dimensionsInCentimeters)
        {
            if (dimensionsInCentimeters < 0)
            {
                throw new ArgumentException("Dimensions must be a positive number");
            }
            if (dimensionsInCentimeters < 10)
            {
                return 3m;
            }
            if (dimensionsInCentimeters < 50)
            {
                return 8m;
            }
            if (dimensionsInCentimeters < 100)
            {
                return 15m;
            }

            return 25m;
        }
    }
}