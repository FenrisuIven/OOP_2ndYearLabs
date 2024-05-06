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
                    Cargo_Presets.names[rnd.Next(Cargo_Presets.names.Length - 1)],
                    Cargo_Presets.countries[rnd.Next(Cargo_Presets.countries.Length - 1)],
                    rnd.Next(1,4));
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
            var changeInfoWindow = new Cargo_ChangeCargoInfo(((Cargo)listBox.SelectedItem), this);
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
            var dtoList = cargoList.Select(elem => elem.MapToCargoDTO());
            var jsonString = JsonSerializer.Serialize(dtoList);
            File.WriteAllText(Cargo.GetPath,string.Empty);
            File.WriteAllText(Cargo.GetPath,jsonString);
        }
        private void DeserializeList(object sender, RoutedEventArgs e)
        {
            var jsonString = File.ReadAllText(Cargo.GetPath);
            var dtoList = JsonSerializer.Deserialize<List<CargoDTO>>(jsonString);
            var list = dtoList.Select(elem => Cargo.MapToCargo(elem));
            cargoList = new ObservableCollection<Cargo>(list);
            listBox.ItemsSource = cargoList;
        }
    }
}