using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CargoClass;
using CropsClass;
using DeliveryEnum;
using WarehouseClass;
using laba4_rework.Serialization;

namespace laba4_rework.Views;

public partial class Warehouse_DetailedInfo : Window
{
    private WarehouseDTO obj;
    public Warehouse_DetailedInfo()
    {
        InitializeComponent();
        ListView_Warehouse.Items.Clear();
        var warehouseDto = new WarehouseDTO {Index = 1, Upkeep = 20, 
        CargoesDTO = new List<CargoDTO> 
        { 
            new()
            {
                Amount = 10, 
                Crops = new CropsDTO() 
                { 
                    Country = CropsPresets.GetRandomCountry(), 
                    Name = CropsPresets.GetRandomName(), 
                    Season = CropsPresets.GetRandomSeason() 
                },
                Delivery = Delivery.Supplier,
                DeliveryTime = new DateTime(2024, 12, 10),
                PriceForOne = 10,
                PriceForTransportation = 10
            },
            new()
            {
                Amount = 10, 
                Crops = new CropsDTO() 
                { 
                    Country = CropsPresets.GetRandomCountry(), 
                    Name = CropsPresets.GetRandomName(), 
                    Season = CropsPresets.GetRandomSeason() 
                },
                Delivery = Delivery.Supplier,
                DeliveryTime = new DateTime(2024, 12, 10),
                PriceForOne = 10,
                PriceForTransportation = 10
            },
            new()
            {
                Amount = 10, 
                Crops = new CropsDTO() 
                { 
                    Country = CropsPresets.GetRandomCountry(), 
                    Name = CropsPresets.GetRandomName(), 
                    Season = CropsPresets.GetRandomSeason() 
                },
                Delivery = Delivery.Supplier,
                DeliveryTime = new DateTime(2024, 12, 10),
                PriceForOne = 10,
                PriceForTransportation = 10
            },
            new()
            {
                Amount = 10, 
                Crops = new CropsDTO() 
                { 
                    Country = CropsPresets.GetRandomCountry(), 
                    Name = CropsPresets.GetRandomName(), 
                    Season = CropsPresets.GetRandomSeason() 
                },
                Delivery = Delivery.Supplier,
                DeliveryTime = new DateTime(2024, 12, 10),
                PriceForOne = 10,
                PriceForTransportation = 10
            }
        } };

        obj = warehouseDto;
        SetLabels();
        
        ListView_Warehouse.ItemsSource = warehouseDto.CargoesDTO;

        var list = Writer<CargoDTO>.ParseObjectsFromFile(Settings.warehousePath);
    }

    private void SetLabels()
    {
        WarehouseIdx_Label.Content = obj.Index;
        WarehouseUpkeep_Label.Content = $"{obj.Upkeep:0.00} hrn";
    }
}