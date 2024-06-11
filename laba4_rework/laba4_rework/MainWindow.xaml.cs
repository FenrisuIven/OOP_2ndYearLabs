using System.Windows;
using System.Diagnostics;

using laba4_rework.Views;

namespace laba4_rework
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
        private void OpenJsonFileLocation(object sender, RoutedEventArgs e) => Process.Start(Settings.path);
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