using System;
using CropsClass;
using DeliveryEnum;

namespace CargoClass;

public class Cargo : ICloneable, IComparable<Cargo>
{
    private Crops _crops;
    private Delivery _delivery;

    private int _amount;
    private int _priceForOne;
    private int _priceForTransportation;
    private DateTime _deliveryTime;
    
    public Cargo(Crops crops, Delivery delivery, int amount, int priceForOne, int priceForTransportation, DateTime deliveryTime)
    {
        _crops = crops;
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
            Crops = _crops.MapToCropsDTO(),
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
            Crops.MapToCrops(dto.Crops),
            dto.Delivery,
            dto.Amount,
            dto.PriceForOne,
            dto.PriceForTransportation,
            dto.DeliveryTime);
    }

    public override string ToString() => 
        $"Crop name: {_crops.MapToCropsDTO().Name}; " +
        $"Delivery: {_delivery}; " +
        $"Amount: {_amount}; " +
        $"Price for one: {_priceForOne}; " +
        $"Price for transportation: {_priceForTransportation}; " +
        $"Delivery time: {_deliveryTime}";

    public object Clone()
    {
        if (_crops == null)
        {
            throw new ArgumentException("Cannot clone CargoCargoClassct that has any of it's fields null.");
        }
        
        return new Cargo(_crops, _delivery, _amount, _priceForOne, _priceForTransportation, _deliveryTime);
    }

    public int CompareTo(Cargo obj)
    {
        if (obj == null) return 1;
        return _amount.CompareTo(obj._amount);
    }
}