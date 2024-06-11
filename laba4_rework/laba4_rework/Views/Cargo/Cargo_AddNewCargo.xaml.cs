using System;
using System.Windows;
using System.ComponentModel;

using CropsClass;
using CargoClass;
using DeliveryEnum;

namespace laba4_rework.Views
{
    public partial class Cargo_AddNewCargo : Window
    {
        private Cargo_MainWindow _parent;
        
        private enum confirmClose
        {
            DoConfirm,
            DontConfirm
        };
        private confirmClose _confirmClose = confirmClose.DoConfirm;
        
        public Cargo_AddNewCargo(Cargo_MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        
        public void SaveAndQuit(object sender, RoutedEventArgs e)
        {
            _confirmClose = confirmClose.DontConfirm;
            AddElement();
            Close();
        }
        public void QuitWithoutSaving(object sender, RoutedEventArgs e)
        {
            _confirmClose = confirmClose.DontConfirm;
            Close();
        }
        
        private void AddElement()
        {
            var list = _parent.cargoList;

            var rnd = new Random();
            var crop = new Crops(
                CropsPresets.names[rnd.Next(CropsPresets.names.Length)],
                CropsPresets.countries[rnd.Next(CropsPresets.countries.Length)],
                (Season)rnd.Next(1,4));
            //var name = Name_TextBox.Text == "" ? $"Crop {list.Count + 1}" : Name_TextBox.Text;
            var newCargo = new Cargo(crop, 
                Delivery.Supplier, 
                rnd.Next(50),
                rnd.Next(50),
                rnd.Next(50),
                DateTime.Now);

            list.Add(newCargo);
            _parent.cargoList = list;
            _parent.listBox.ItemsSource = _parent.cargoList;
        }
        
        private void ClosingSequence(object sender, CancelEventArgs e)
        {
            // if (_confirmClose == confirmClose.DontConfirm) return;
            // if (string.IsNullOrWhiteSpace(Name_TextBox.Text) || string.IsNullOrWhiteSpace(Country_TextBox.Text) || string.IsNullOrWhiteSpace(Season_TextBox.Text))
            // {
            //     MessageBoxResult result = MessageBox.Show(
            //         "You have unsaved changes, do you wanna quit without saving?", 
            //         "Warning!", 
            //         MessageBoxButton.YesNo, 
            //         MessageBoxImage.Warning);
            //     if (result == MessageBoxResult.No)
            //     {
            //         e.Cancel = true;
            //     }
            // }
        }
    }
}