using System;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace laba4
{
    public partial class Warehouse_ChangeWarehouse : Window
    {
        public Warehouse obj;
        private Warehouse_MainWindow _parent;
        
        private enum confirmClose
        {
            DoConfirm,
            DontConfirm
        };
        private confirmClose _confirmClose = confirmClose.DoConfirm;
        
        public Warehouse_ChangeWarehouse(Warehouse house, Warehouse_MainWindow parent)
        {
            InitializeComponent();
            obj = house;
            _parent = parent;
        }

        public void Initialize()
        {
            var dto = obj.MapToWarehouseDTO();
            Index_TextBox.Text = "" + dto.Index;
            Upkeep_TextBox.Text = "" + dto.Upkeep;
        }

        public void SaveAndQuit(object sender, RoutedEventArgs e)
        {
            _confirmClose = confirmClose.DontConfirm;
            ChangeElement();
            Close();
        }
        public void QuitWithoutSaving(object sender, RoutedEventArgs e)
        {
            _confirmClose = confirmClose.DontConfirm;
            Close();
        }
        
        private void ChangeElement()
        {
            
            var list = _parent.warehouseList.ToImmutableList();
            
            var dto = obj.MapToWarehouseDTO();
            int idx = dto.Index, upkeep = dto.Upkeep;
            try
            {
                idx = int.Parse(Index_TextBox.Text);
                upkeep = int.Parse(Upkeep_TextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Some of the fields were in a wrong format! Make sure that all the fields contain numbers.", 
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                exit = false;
                return;
            }
            
            Warehouse clone = obj.CloneWithNewIdxAndUpkeep(idx, upkeep);
            list = list.Replace(obj, clone);
            _parent.warehouseList = new ObservableCollection<Warehouse>(list.ToList());
            _parent.listBox.ItemsSource = _parent.warehouseList;
        }

        private bool exit = true;
        private void ClosingSequence(object sender, CancelEventArgs e)
        {
            if (!exit) 
            {
                e.Cancel = true;
                exit = true;
            }
            if (_confirmClose == confirmClose.DontConfirm) return;
            
            var dto = obj.MapToWarehouseDTO();
            if (Index_TextBox.Text != dto.Index.ToString() || Upkeep_TextBox.Text != dto.Upkeep.ToString())
            {
                MessageBoxResult result = 
                    MessageBox.Show(
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