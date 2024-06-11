using System;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;

using laba4_rework.Serialization;

using CargoClass;
using CropsClass;
using DeliveryEnum;

namespace laba4_rework.Views
{
    public partial class Cargo_MainWindow : Window
    {
        public ObservableCollection<Cargo> cargoList;
        public Cargo_MainWindow()
        {
            InitializeComponent();
            var rnd = new Random();
            cargoList = new ObservableCollection<Cargo>();
            for (int i = 0; i < 15; i++)
            {
                var crop = new Crops(
                    CropsPresets.names[rnd.Next(CropsPresets.names.Length - 1)],
                    CropsPresets.countries[rnd.Next(CropsPresets.countries.Length - 1)],
                    (Season)rnd.Next(1,4));
                var cargo = new Cargo(crop,
                    Delivery.Supplier,
                    rnd.Next(50),
                    rnd.Next(50),
                    rnd.Next(50),
                    DateTime.Now
                    );
                
                cargoList.Add(cargo);
            }
            listBox.ItemsSource = cargoList;
        }

        private void RemoveElementFromList(object sender, RoutedEventArgs e)
        {
            cargoList.Remove(listBox.SelectedItem as Cargo);
            listBox.ItemsSource = cargoList;
        }

        private void ChangeCargoInfo(object sender, RoutedEventArgs e)
        {
            var changeInfoWindow = new Cargo_ChangeCargoInfo((Cargo)listBox.SelectedItem, this);
            changeInfoWindow.Initialize();
            changeInfoWindow.ShowDialog();
        }

        private void AddNewCargo(object sender, RoutedEventArgs e)
        {
            var changeInfoWindow = new Cargo_AddNewCargo(this);
            changeInfoWindow.ShowDialog();
        }
        private void SerializeList(object sender, RoutedEventArgs e)
        {
            var dtoList = cargoList.Select(elem => elem.MapToCargoDTO()).ToList();
            Writer<CargoDTO>.WriteObjectsToFile(Settings.cargoPath, dtoList);
        }
        private void DeserializeList(object sender, RoutedEventArgs e)
        {
            var dtoList = Writer<CargoDTO>.ParseObjectsFromFile(Settings.cargoPath);
            var list = dtoList.Select(elem => Cargo.MapToCargo(elem));
            cargoList = new ObservableCollection<Cargo>(list);
            listBox.ItemsSource = cargoList;
        }
    }
}