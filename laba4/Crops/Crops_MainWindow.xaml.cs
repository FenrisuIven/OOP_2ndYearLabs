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
    public partial class Crops_MainWindow : Window
    { 
        public ObservableCollection<Crops> cropsList;
        public Crops_MainWindow()
        {
            InitializeComponent();
            /*var rnd = new Random();
            cropsList = new ObservableCollection<Crops>();
            for (int i = 0; i < 15; i++)
            {
                var crop = new Crops(
                    Cargo_Presets.names[rnd.Next(Cargo_Presets.names.Length - 1)],
                    Cargo_Presets.countries[rnd.Next(Cargo_Presets.countries.Length - 1)],
                    rnd.Next(1,4));
                
                cropsList.Add(crop);
            }*/
            listBox.ItemsSource = cropsList;
        }

        private void RemoveElementFromList(object sender, RoutedEventArgs e)
        {
            cropsList.Remove(listBox.SelectedItem as Crops);
            listBox.ItemsSource = cropsList;
        }

        private void ChangeWarehouseInfo(object sender, RoutedEventArgs e)
        {
            var changeInfoWindow = new Crops_ChangeCropInfo(((Crops)listBox.SelectedItem), this);
            changeInfoWindow.Initialize();
            changeInfoWindow.ShowDialog();
        }

        private void AddNewCrop(object sender, RoutedEventArgs e)
        {
            var changeInfoWindow = new Crops_AddNewCrop(this);
            changeInfoWindow.ShowDialog();
        }
        private void SerializeList(object sender, RoutedEventArgs e)
        {
            var dtoList = cropsList.Select(elem => elem.MapToCropsDTO());
            var jsonString = JsonSerializer.Serialize(dtoList);
            File.WriteAllText(Crops.GetPath,string.Empty);
            File.WriteAllText(Crops.GetPath,jsonString);
        }
        private void DeserializeList(object sender, RoutedEventArgs e)
        {
            var jsonString = File.ReadAllText(Crops.GetPath);
            var dtoList = JsonSerializer.Deserialize<List<CropsDTO>>(jsonString);
            var list = dtoList.Select(elem => Crops.MapToCrops(elem));
            cropsList = new ObservableCollection<Crops>(list);
            listBox.ItemsSource = cropsList;
        }
    }
}