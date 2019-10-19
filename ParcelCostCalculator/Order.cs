using System.Collections.Generic;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator
{
    public class Order
    {
        public List<Parcel> Parcels { get; private set; } = new List<Parcel>();
        private decimal _totalShippingPrice;

        public ShippingType _shippingType { get; private set; } = ShippingType.NORMAL;

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

            if (_shippingType == ShippingType.SPEEDY_SHIPPING)
            {
                return _totalShippingPrice * 2;
            }

            return _totalShippingPrice;
        }

        public void SetShippingTypeToSpeedy()
        {
            _shippingType = ShippingType.SPEEDY_SHIPPING;
        }
    }
}