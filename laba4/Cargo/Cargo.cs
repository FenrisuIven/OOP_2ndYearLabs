using System;
using System.Linq;

namespace laba4
{
    public class Cargo : ICloneable, IComparable<Cargo>
    {
        private Crops _crop;
        private Delivery _delivery;

        private int _amount;
        private int _priceForOne;
        private int _priceForTransportation;
        private DateTime _deliveryTime;

        
        private static string _path = "C:/Users/Nova/source/repos/OOP_Labs/laba4/Cargo/cargo.json";
        public static string GetPath => _path;
        
        public Cargo(Crops crop, Delivery delivery, int amount, int priceForOne, int priceForTransportation, DateTime deliveryTime)
        {
            _crop = crop;
            _delivery = delivery;
            _amount = amount;
            _priceForOne = priceForOne;
            _priceForTransportation = priceForTransportation;
            _deliveryTime = deliveryTime;
        }

        public CargoDTO MapToCargoDTO()
        {
            return new CargoDTO
            {
                Crop = _crop.MapToCropsDTO(),
                Delivery = _delivery,
                Amount = _amount,
                PriceForOne = _priceForOne,
                PriceForTransportation = _priceForTransportation,
                DeliveryTime = _deliveryTime
            };
        }

        public static Cargo MapToCargo(CargoDTO dto)
        {
            return new Cargo(
                Crops.MapToCrops(dto.Crop),
                dto.Delivery,
                dto.Amount,
                dto.PriceForOne,
                dto.PriceForTransportation,
                dto.DeliveryTime);
        }

        public override string ToString() => 
            $"Crop name: {_crop.MapToCropsDTO().Name}; " +
            $"Delivery: {_delivery}; " +
            $"Amount: {_amount}; " +
            $"Price for one: {_priceForOne}; " +
            $"Price for transportation: {_priceForTransportation}; " +
            $"Delivery time: {_deliveryTime}";

        public object Clone()
        {
            if (_crop == null)
            {
                throw new ArgumentException("Cannot clone Cargo object that has any of it's fields null.");
            }
            
            return new Cargo(_crop, _delivery, _amount, _priceForOne, _priceForTransportation, _deliveryTime);
        }

        public int CompareTo(Cargo obj)
        {
            if (obj == null) return 1;
            return _amount.CompareTo(obj._amount);
        }
    }
}