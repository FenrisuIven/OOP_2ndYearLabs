using CropsClass;
using CargoClass;
using DeliveryEnum;

namespace WarehouseClass;

public class Warehouse : ICloneable
{
    private int _idxOfWarehouse;
    private int _upkeepPrice;
    private List<Cargo> _cargoesInWarehouse = new();
    
    public Warehouse(int idxOfWarehouse, int upkeepPrice)
    {
        _idxOfWarehouse = idxOfWarehouse;
        _upkeepPrice = upkeepPrice;
    }

    private int GetTotalValue()
    {
        return _cargoesInWarehouse.Aggregate(0, (res, cargo) =>
        {
            var dto = cargo.MapToCargoDTO();
            res += dto.PriceForOne * dto.Amount;
            return res;
        });
    }

    public WarehouseDTO MapToWarehouseDTO()
    {
        return new WarehouseDTO
        {
            Index = _idxOfWarehouse,
            Upkeep = _upkeepPrice,
            AmountOfCargos = _cargoesInWarehouse.Count
        };
    }

    public static Warehouse MapToWarehouse(WarehouseDTO dto)
    {
        var res = new Warehouse(dto.Index, dto.Upkeep);

        var rnd = new Random();
        for (int i = 0; i < dto.AmountOfCargos; i++)
        {
            var crop = new Crops(
                Cargo_Presets.names[rnd.Next(Cargo_Presets.names.Length)],
                Cargo_Presets.countries[rnd.Next(Cargo_Presets.countries.Length)],
                rnd.Next(1,4));
            var cargo = new Cargo(crop, 
                Delivery.Supplier, 
                1, 
                1, 
                1, 
                DateTime.Now);
            
            res.AddToWarehouse(cargo);
        }
        
        return res;
    }
    
    public void AddToWarehouse(Cargo cargo) => _cargoesInWarehouse.Add(cargo);
    public void RemoveFromWarehouse(Cargo cargo) => _cargoesInWarehouse.Remove(cargo);

    public override string ToString()
    {
        return $"Warehouse {_idxOfWarehouse}: Amount of cargoes in warehouse: {_cargoesInWarehouse.Count}; Upkeep price per month: {_upkeepPrice} hrn; Total upkeep for year: {_upkeepPrice * 12} hrn;";
    }

    public object Clone()
    {
        var res = new Warehouse(_idxOfWarehouse, _upkeepPrice);
        foreach (var house in _cargoesInWarehouse)
        {
            res.AddToWarehouse(house);
        }
        return res;
    }
    public Warehouse CloneWithNewIdxAndUpkeep(int idx, int upkeep)
    {
        var res = new Warehouse(idx, upkeep);
        foreach (var house in _cargoesInWarehouse)
        {
            res.AddToWarehouse(house);
        }
        return res;
    }

    public string ToShortString() => $"Warehouse {_idxOfWarehouse}: {GetTotalValue()} hrn";
}