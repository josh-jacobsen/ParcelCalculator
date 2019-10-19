using System.Collections.Generic;

namespace ParcelCostCalculator
{
    public class Order
    {
        public List<Parcel> Parcels { get; private set; } = new List<Parcel>();

        private decimal _totalShippingPrice;

        public Order()
        {

        }

        public void AddParcelToOrder(Parcel parcel)
        {
            Parcels.Add(parcel);
        }

        public decimal GetShippingPriceForOrder()
        {
            foreach (var parcel in Parcels)
            {
                _totalShippingPrice = _totalShippingPrice + parcel.CalculateShippingCost();
            }

            return _totalShippingPrice;
        }
    }
}