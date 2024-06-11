using CropsClass;
using DeliveryEnum;

namespace CargoClass;

public class CargoDTO
{
    public CropsDTO Crops { get; set; }
    public Delivery Delivery { get; set; }
    public int Amount { get; set; }
    public int PriceForOne { get; set; }
    public int PriceForTransportation { get; set; }
    public DateTime DeliveryTime { get; set; }

    public CargoDTO() {}
}