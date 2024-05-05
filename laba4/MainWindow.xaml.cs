using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            var warehouse = new Warehouse_MainWindow();
            warehouse.ShowDialog();
        }
    }
}