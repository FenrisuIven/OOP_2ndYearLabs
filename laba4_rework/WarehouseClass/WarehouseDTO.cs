using CargoClass;

namespace WarehouseClass;

public class WarehouseDTO
{
    public int Index { get; set; }
    public int Upkeep { get; set; }
    public List<CargoDTO> CargoesDTO { get; set; }

    public WarehouseDTO() {}
}