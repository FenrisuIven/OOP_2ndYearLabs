using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;

using laba4_rework.Serialization;
using WarehouseClass;

namespace laba4_rework.Views
{
    public partial class Warehouse_MainWindow : Window
    {
        public ObservableCollection<Warehouse> warehouseList = new();
        public Warehouse_MainWindow()
        {
            InitializeComponent();
            
            /*var crop = new CropsClass("Name 4", "Country 4", 4);

            var rnd = new Random();
            warehouseList = new ObservableCollection<Warehouse>();
            for (int i = 0; i < 15; i++)
            {
                var warehouse = new Warehouse(i + 1, rnd.Next(1, 50));
                warehouse.AddToWarehouse(new CargoClass(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                warehouse.AddToWarehouse(new CargoClass(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                warehouse.AddToWarehouse(new CargoClass(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                warehouse.AddToWarehouse(new CargoClass(crop, Delivery.Supplier, 1, 10,1, DateTime.Today));
                 
                warehouseList.Add(warehouse);
            }
            listBox.ItemsSource = warehouseList;*/

            var win = new Warehouse_DetailedInfo();
            win.ShowDialog();
        }

        private void RemoveElementFromList(object sender, RoutedEventArgs e)
        {
            warehouseList.Remove(listBox.SelectedItem as Warehouse);
            listBox.ItemsSource = warehouseList;
        }

        private void ChangeWarehouseInfo(object sender, RoutedEventArgs e)
        {
            var changeInfoWindow = new Warehouse_ChangeWarehouse((Warehouse)listBox.SelectedItem, this);
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
            var dtoList = warehouseList.Select(elem => elem.MapToWarehouseDTO()).ToList();
            Writer<WarehouseDTO>.WriteObjectsToFile(Settings.warehousePath, dtoList);
        }
        private void DeserializeList(object sender, RoutedEventArgs e)
        {
            var dtoList = Writer<WarehouseDTO>.ParseObjectsFromFile(Settings.warehousePath);
            var list = dtoList.Select(elem => Warehouse.MapToWarehouse(elem));
            warehouseList = new ObservableCollection<Warehouse>(list);
            listBox.ItemsSource = warehouseList;
        }
    }
}