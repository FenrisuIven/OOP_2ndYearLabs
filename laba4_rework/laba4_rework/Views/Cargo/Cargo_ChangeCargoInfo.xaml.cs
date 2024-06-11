using System.Windows;
using System.ComponentModel;

using CargoClass;

namespace laba4_rework.Views
{
    public partial class Cargo_ChangeCargoInfo : Window
    {
        public Cargo obj;
        private Cargo_MainWindow _parent;
        
        private enum confirmClose
        {
            DoConfirm,
            DontConfirm
        };
        private confirmClose _confirmClose = confirmClose.DoConfirm;
        
        public Cargo_ChangeCargoInfo(Cargo cargo, Cargo_MainWindow parent)
        {
            InitializeComponent();
            obj = cargo;
            _parent = parent;
        }

        public void Initialize()
        {
            // var dto = obj.MapToCargoDTO();
            // Name_TextBox.Text = "" + dto.Name;
            // Country_TextBox.Text = "" + dto.Country;
            // Season_TextBox.Text = "" + dto.Season;
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
            // var list = _parent.cropsList.ToImmutableList();
            //
            // var dto = obj.MapToCropsDTO();
            // var name = Name_TextBox.Text == "" ? dto.Name : Name_TextBox.Text;
            // var country = Country_TextBox.Text == "" ? dto.Country : Country_TextBox.Text;
            // var season = Season_TextBox.Text == "" ? dto.Season : int.Parse(Season_TextBox.Text);
            //
            // var changed = new CropsClass(name, country, season);
            // list = list.Replace(obj, changed);
            // _parent.cropsList = new ObservableCollection<CropsClass>(list.ToList());
            // _parent.listBox.ItemsSource = _parent.cropsList;
        }
        
        private void ClosingSequence(object sender, CancelEventArgs e)
        {
            // if (_confirmClose == confirmClose.DontConfirm) return;
            // var dto = obj.MapToCropsDTO();
            // if (Name_TextBox.Text != dto.Name || Country_TextBox.Text != dto.Country || Season_TextBox.Text != dto.Season.ToString())
            // {
            //     MessageBoxResult result = 
            //         MessageBox.Show(
            //             "You have unsaved changes, do you wanna quit without saving?", 
            //             "Warning!", 
            //             MessageBoxButton.YesNo, 
            //             MessageBoxImage.Warning);
            //     if (result == MessageBoxResult.No)
            //     {
            //         e.Cancel = true;
            //     }
            // }
        }
    }
}