using System;
using System.Windows;
using System.ComponentModel;

using WarehouseClass;
using CargoClass;
using CropsClass;
using DeliveryEnum;

namespace laba4_rework.Views
{
    public partial class Warehouse_AddNewWarehouse : Window
    {
        private Warehouse_MainWindow _parent;
        
        private enum confirmClose
        {
            DoConfirm,
            DontConfirm
        };
        private confirmClose _confirmClose = confirmClose.DoConfirm;
        
        public Warehouse_AddNewWarehouse(Warehouse_MainWindow parent)
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
            var list = _parent.warehouseList;

            var idx = Index_TextBox.Text == "" ? list.Count + 1 : int.Parse(Index_TextBox.Text);
            var upkeep = Upkeep_TextBox.Text == "" ? 1 : int.Parse(Upkeep_TextBox.Text);
            var newWarehouse = new Warehouse(idx, upkeep);

            var rnd = new Random();
            var amountOfCrops = int.Parse(AmountOfCargos_TextBox.Text);
            for (int i = 0; i < amountOfCrops; i++)
            {
                var crop = new Crops(
                    CropsPresets.names[rnd.Next(CropsPresets.names.Length)],
                    CropsPresets.countries[rnd.Next(CropsPresets.countries.Length)],
                    (Season)rnd.Next(1,4));
                var cargo = new Cargo(crop, 
                    Delivery.Supplier, 
                    rnd.Next(20), 
                    rnd.Next(999), 
                    rnd.Next(999), 
                    DateTime.Now);
                
                newWarehouse.AddToWarehouse(cargo);
            }
            list.Add(newWarehouse);
            _parent.warehouseList = list;
            _parent.listBox.ItemsSource = _parent.warehouseList;
        }
        
        private void ClosingSequence(object sender, CancelEventArgs e)
        {
            if (_confirmClose == confirmClose.DontConfirm) return;
            if (string.IsNullOrWhiteSpace(Index_TextBox.Text) || string.IsNullOrWhiteSpace(Upkeep_TextBox.Text))
            {
                MessageBoxResult result = MessageBox.Show(
                        "You have unsaved changes, do you wanna quit without saving?", 
                        "Warning!", 
                        MessageBoxButton.YesNo, 
                        MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}