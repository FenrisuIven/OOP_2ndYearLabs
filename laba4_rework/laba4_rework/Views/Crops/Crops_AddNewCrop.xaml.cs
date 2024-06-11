using System.Windows;
using System.ComponentModel;

using CropsClass;

namespace laba4_rework.Views
{
    public partial class Crops_AddNewCrop : Window
    {
        private Crops_MainWindow _parent;
        
        private enum confirmClose
        {
            DoConfirm,
            DontConfirm
        };
        private confirmClose _confirmClose = confirmClose.DoConfirm;
        
        public Crops_AddNewCrop(Crops_MainWindow parent)
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
            var list = _parent.cropsList;

            var name = Name_TextBox.Text == "" ? $"Crop {list.Count + 1}" : Name_TextBox.Text;
            var country = Country_TextBox.Text == "" ? "Ukraine" : Country_TextBox.Text;
            var season = Country_TextBox.Text == "" ? 1 : int.Parse(Season_TextBox.Text);
            var newCrops = new Crops(name, country, season);

            list.Add(newCrops);
            _parent.cropsList = list;
            _parent.listBox.ItemsSource = _parent.cropsList;
        }
        
        private void ClosingSequence(object sender, CancelEventArgs e)
        {
            if (_confirmClose == confirmClose.DontConfirm) return;
            if (string.IsNullOrWhiteSpace(Name_TextBox.Text) || string.IsNullOrWhiteSpace(Country_TextBox.Text) || string.IsNullOrWhiteSpace(Season_TextBox.Text))
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