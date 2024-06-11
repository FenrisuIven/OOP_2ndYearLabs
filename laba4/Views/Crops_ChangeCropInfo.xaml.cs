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
    public partial class Crops_ChangeCropInfo : Window
    {
        public Crops obj;
        private Crops_MainWindow _parent;
        
        private enum confirmClose
        {
            DoConfirm,
            DontConfirm
        };
        private confirmClose _confirmClose = confirmClose.DoConfirm;
        
        public Crops_ChangeCropInfo(Crops crop, Crops_MainWindow parent)
        {
            InitializeComponent();
            obj = crop;
            _parent = parent;
        }

        public void Initialize()
        {
            var dto = obj.MapToCropsDTO();
            Name_TextBox.Text = "" + dto.Name;
            Country_TextBox.Text = "" + dto.Country;
            Season_TextBox.Text = "" + dto.Season;
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
            var list = _parent.cropsList.ToImmutableList();
            
            var dto = obj.MapToCropsDTO();
            var name = Name_TextBox.Text == "" ? dto.Name : Name_TextBox.Text;
            var country = Country_TextBox.Text == "" ? dto.Country : Country_TextBox.Text;
            var season = Season_TextBox.Text == "" ? dto.Season : int.Parse(Season_TextBox.Text);
            
            var changed = new Crops(name, country, season);
            list = list.Replace(obj, changed);
            _parent.cropsList = new ObservableCollection<Crops>(list.ToList());
            _parent.listBox.ItemsSource = _parent.cropsList;
        }
        
        private void ClosingSequence(object sender, CancelEventArgs e)
        {
            if (_confirmClose == confirmClose.DontConfirm) return;
            var dto = obj.MapToCropsDTO();
            if (Name_TextBox.Text != dto.Name || Country_TextBox.Text != dto.Country || Season_TextBox.Text != dto.Season.ToString())
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