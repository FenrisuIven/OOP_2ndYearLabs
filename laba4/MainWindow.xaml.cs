using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace laba4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string path = "C:/Users/Nova/source/repos/OOP_Labs/laba4/";
        private void OpenCropsJsonFileLocation(object sender, RoutedEventArgs e)
        {
            Process.Start(path + "Crops/");
        }

        private void OpenWarehouseJsonFileLocation(object sender, RoutedEventArgs e)
        {
            Process.Start(path + "Warehouse/");
        }
        private void OpenWarehouseMainForm(object sender, RoutedEventArgs e)
        {
            var warehouse = new Warehouse_MainWindow();
            warehouse.ShowDialog();
        }
        private void OpenCropsMainForm(object sender, RoutedEventArgs e)
        {
            var crops = new Crops_MainWindow();
            crops.ShowDialog();
        }
        private void OpenCargoMainForm(object sender, RoutedEventArgs e)
        {
            var cargo = new Cargo_MainWindow();
            cargo.ShowDialog();
        }
    }
}