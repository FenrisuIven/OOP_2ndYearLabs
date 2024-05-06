using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace laba4
{
    public partial class Warehouse_MainWindow : Window
    {
        public ObservableCollection<Warehouse> warehouseList;
        public Warehouse_MainWindow()
        {
            InitializeComponent();

             /*var crop = new Crops("Name 4", "Country 4", 4);

             var rnd = new Random();
             warehouseList = new ObservableCollection<Warehouse>();
             for (int i = 0; i < 15; i++)
             {
                 var warehouse = new Warehouse(i + 1, rnd.Next(1, 50));
                 warehouse.AddToWarehouse(new Cargo(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                 warehouse.AddToWarehouse(new Cargo(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                 warehouse.AddToWarehouse(new Cargo(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                 warehouse.AddToWarehouse(new Cargo(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                 
                 warehouseList.Add(warehouse);
             }
            listBox.ItemsSource = warehouseList;*/
        }

        private void RemoveElementFromList(object sender, RoutedEventArgs e)
        {
            warehouseList.Remove(listBox.SelectedItem as Warehouse);
            listBox.ItemsSource = warehouseList;
        }

        private void ChangeWarehouseInfo(object sender, RoutedEventArgs e)
        {
            var changeInfoWindow = new Warehouse_ChangeWarehouse(((Warehouse)listBox.SelectedItem), this);
            changeInfoWindow.Initialize();
            changeInfoWindow.ShowDialog();
        }

        private void AddNewWarehouse(object sender, RoutedEventArgs e)
        {
            var changeInfoWindow = new Warehouse_AddNewWarehouse(this);
            changeInfoWindow.ShowDialog();
        }
        private void SerializeList(object sender, RoutedEventArgs e)
        {
            var dtoList = warehouseList.Select(elem => elem.MapToWarehouseDTO());
            var jsonString = JsonSerializer.Serialize(dtoList);
            File.WriteAllText(Warehouse.GetPath,string.Empty);
            File.WriteAllText(Warehouse.GetPath,jsonString);
        }
        private void DeserializeList(object sender, RoutedEventArgs e)
        {
            var jsonString = File.ReadAllText(Warehouse.GetPath);
            var dtoList = JsonSerializer.Deserialize<List<WarehouseDTO>>(jsonString);
            var list = dtoList.Select(elem => Warehouse.MapToWarehouse(elem));
            warehouseList = new ObservableCollection<Warehouse>(list);
            listBox.ItemsSource = warehouseList;
        }
    }
}