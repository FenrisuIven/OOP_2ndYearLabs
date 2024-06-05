using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace l3t1
{
    public partial class MainWindow
    {
        public int betPrice = 20;
        public int BankAccount { get; set; }
        public string Bet_HorseName { get; set; }
        public string Bet_Amount { get; set; }
        private void Bet(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bet");
            if (BankAccount - betPrice < 0) return;
            BankAccount -= betPrice;
            Balance.Content = $"{BankAccount}";
            Bet_HorseName = ChosenHorseName.Content.ToString();
            horses.First(elem => elem.Name == Bet_HorseName).Bid = betPrice;
            HorsesLeaderboard.Items.Refresh();
        }


        // Handlers for changing the amount of horses in race
        // I think I can (or should) move it somewhere, instead of keeping it here in MainWindow
        private void ChangeAmountOfHorses(object sender, SelectionChangedEventArgs e)
        {
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
            for (int i = horses.Count; i < amount; i++)
            {
                horses.Add(new Horse(Horse.GenerateColor(horses), Horse.GenerateName(horses)));
            }
            AmountOfHorses_ListBox.Items.Refresh();
            AddImages();
        }
        private void RemoveHorses(int finalAmount)
        {
            RemoveImages(horses.Count - finalAmount);
            for (int i = horses.Count; i > finalAmount; i--)
            {
                horses.RemoveAt(horses.Count - 1);
            }
            AmountOfHorses_ListBox.Items.Refresh();
        }
        public void AddImages()
        {
            for (int i = imagesPresentCount; i < horses.Count; i++, imagesPresentCount++)
            {
                Image img = GenerateImageObject(horses[i]);
                TrackLayout.Children.Add(img);
                _horsesImages.Add(img);
            }
        }
        public void RemoveImages(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                TrackLayout.Children.Remove(_horsesImages.ElementAt(_horsesImages.Count - 1));
                _horsesImages.Remove(_horsesImages.ElementAt(_horsesImages.Count - 1));
                imagesPresentCount--;
            }
        }
        // Handlers for changing the amount of horses in race
    }
}
