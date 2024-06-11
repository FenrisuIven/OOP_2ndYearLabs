using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;

using laba4_rework.Serialization;
using CropsClass;

namespace laba4_rework.Views
{
    public partial class Crops_MainWindow : Window
    { 
        public ObservableCollection<Crops> cropsList;
        public Crops_MainWindow()
        {
            InitializeComponent();
            /*var rnd = new Random();
            cropsList = new ObservableCollection<CropsClass>();
            for (int i = 0; i < 15; i++)
            {
                var crop = new CropsClass(
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
            var dtoList = cropsList.Select(elem => elem.MapToCropsDTO()).ToList();
            Writer<CropsDTO>.WriteObjectsToFile(Settings.cropsPath, dtoList);
        }
        private void DeserializeList(object sender, RoutedEventArgs e)
        {
            var dtoList = Writer<CropsDTO>.ParseObjectsFromFile(Settings.cropsPath);
            var list = dtoList.Select(elem => Crops.MapToCrops(elem));
            cropsList = new ObservableCollection<Crops>(list);
            listBox.ItemsSource = cropsList;
        }
    }
}