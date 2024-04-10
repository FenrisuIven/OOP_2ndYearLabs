using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace l3t1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Horse> horses;
        public MainWindow()
        {
            InitializeComponent();
            horses = new ObservableCollection<Horse>
            {
                new Horse(Brushes.DarkSlateGray, "Lucilda"),
                new Horse(Brushes.GreenYellow, "Emanuel"),
                new Horse(Brushes.LightCoral, "Steve")
            };
            HorsesLeaderboard.ItemsSource = horses;
        }

        private void ChangeAmountOfHorses(object sender, SelectionChangedEventArgs e)
        { //From: <ListBox Name="AmountOfHorses_ListBox" SelectionChanged="<...>" >
            if (AmountOfHorses_ListBox.SelectedItem != null)
            {
                ListBoxItem selectedItem = (ListBoxItem)AmountOfHorses_ListBox.SelectedItem;
                int horseCount = int.Parse(selectedItem.Content.ToString());

                if (horseCount > horses.Count)
                {
                    AddHorses(horseCount);
                }
                else if (horseCount < horses.Count)
                {
                    RemoveHorses(horseCount);
                }

            }
        }
        private void AddHorses(int amount)
        {
            for(int i = horses.Count; i < amount; i++)
            {
                horses.Add(new Horse(Brushes.DarkSlateGray, "Lucilda"));
            }
            AmountOfHorses_ListBox.Items.Refresh();
        }
        private void RemoveHorses(int finalAmount)
        {
            for (int i = horses.Count; i > finalAmount; i--)
            {
                horses.RemoveAt(horses.Count - 1);
            }
            AmountOfHorses_ListBox.Items.Refresh();
        }
    }
}