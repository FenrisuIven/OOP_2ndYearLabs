using System;
using System.Linq;
using System.Windows;
using System.Threading;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using l3t1_HorseRace.Classes;
using l3t1_HorseRace.ViewModels;
using l3t1_HorseRace.ImageHandlres;

namespace l3t1_HorseRace
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Horse> horses = new();
        private List<Image> _horsesImages = new();
        private int imagesPresentCount;

        private Player LocalPlayer = new();
        private HorseSelectionHandler localHSHandler = new();
        private BetSelectionHandler localBSHandler = new();
        
        private CancellationTokenSource _cancellToken; //unused
        
        

        // First initializing
        public MainWindow()
        {
            InitializeComponent();
            Balance.DataContext = LocalPlayer;
            
            TrackFrame.Content = new RaceLines();
            InitializeHorseList();
            InitializeImageList();
            
            UpdateLocalHSMaxIdx();
            ChangeSelectedBetLabel();
            ChangeSelectedHorseLabel(localHSHandler.CurrentIdx);
            HorsesLeaderboard.ItemsSource = horses;

        }

        private void InitializeHorseList()
        {
            horses = new ObservableCollection<Horse>
            {
                new (Brushes.DarkSlateGray, "Lucilda"),
                new (Brushes.GreenYellow, "Emanuel")
            };
        }
        private void InitializeImageList()
        {
            foreach (var horse in horses)
            {
                Image img = ImageGenerator.GenerateImageObject(horse);
                RaceLinesVM.Instance.ImgAdditionRequested(img);
                _horsesImages.Add(img);
                imagesPresentCount++;
            }
        }

        private async void RunProgram(object sender, RoutedEventArgs e)
        {
            var lauchHorses = LaunchHorses();
            var changePositionHorses = ChangePositionHorses();
            var updateRatingPositionHorses = UpdateRatingPositionHorses();

            await Task.WhenAll(lauchHorses, changePositionHorses, updateRatingPositionHorses);

            MessageBox.Show($"Race has finished. {horses.First().Name} has won!\nYou got: ${horses.First().Bid * 2}");
            LocalPlayer.BankAccount += horses.First().Bid * horses.First().Coefficient;
        }
        public async Task LaunchHorses()
        {
            var tasks = new List<Task>();
            foreach (var horse in horses)
            {
                tasks.Add(horse.RunAsync());
            }
            await Task.WhenAll(tasks);
        }
        private async Task ChangePositionHorses()
        {
            _cancellToken = new CancellationTokenSource();
            await Task.Run(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(() =>
                    {
                        for (int i = 0; i < horses.Count; i++)
                        {
                            PositionChange(_horsesImages[i], i);
                        }
                    });
                    Task.Delay(100).Wait();
                    if (_cancellToken.Token.IsCancellationRequested) break;
                }
            });
        }
        private void PositionChange(Image horse, int i) =>
            horse.Margin = new Thickness(horses[i].Position % 700, 0, 0, 0);
        private async Task UpdateRatingPositionHorses()
        {
            _cancellToken = new();
            await Task.Run(() => 
            {
                while (!_cancellToken.Token.IsCancellationRequested)
                {
                    if (horses.All(elem => !elem.TimerRunning()))
                    {
                        Dispatcher.Invoke(() =>
                        {
                            ChangeLeaderboardRating();
                        });
                        _cancellToken.Cancel();
                    }
                    Dispatcher.Invoke(() =>
                    {
                        HorsesLeaderboard.Items.Refresh();
                    });
                }
            });
        }
        public void ChangeLeaderboardRating()
        {
            horses = new ObservableCollection<Horse>(horses.OrderBy(elem => elem.Time.TotalMilliseconds));
            HorsesLeaderboard.ItemsSource = horses;
            HorsesLeaderboard.Items.Refresh();
        }
        
        private void OnBetClick(object sender, RoutedEventArgs e)
        {
            if (LocalPlayer.BankAccount - localBSHandler.GetBet() < 0) return;
            LocalPlayer.BankAccount -= localBSHandler.GetBet();
            
            LocalPlayer.Bet_HorseName = ChosenHorseName.Text;
            horses.First(elem => elem.Name == LocalPlayer.Bet_HorseName).Bid += localBSHandler.GetBet();
            HorsesLeaderboard.Items.Refresh();
        }
        
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

                UpdateLocalHSMaxIdx();
            }
        }
        private void AddHorses(int amount)
        {
            for (int i = horses.Count; i < amount; i++)
            {
                horses.Add(new Horse(HorseGenerator.GenerateColor(horses), HorseGenerator.GenerateName(horses)));
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
                Image img = ImageGenerator.GenerateImageObject(horses[i]);
                RaceLinesVM.Instance.ImgAdditionRequested(img);
                _horsesImages.Add(img);
            }
        }
        public void RemoveImages(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                RaceLinesVM.Instance.ImgRemovalRequested(_horsesImages.ElementAt(_horsesImages.Count - 1));
                _horsesImages.Remove(_horsesImages.ElementAt(_horsesImages.Count - 1));
                imagesPresentCount--;
            }
            
        }

        
        
        
        private void UpdateLocalHSMaxIdx()
        {
            localHSHandler.MaxIdx = horses.Count - 1;
            UpdateCurrentSelectedHorse();
        }
        
        private void PrevHorse_Selection(object sender, RoutedEventArgs e) => ChangeSelectedHorseLabel(localHSHandler.PrevHorse());
        private void NextHorse_Selection(object sender, RoutedEventArgs e)=> ChangeSelectedHorseLabel(localHSHandler.NextHorse());
        public void ChangeSelectedHorseLabel(int idx) => ChosenHorseName.Text = horses[idx].Name;
        private void UpdateCurrentSelectedHorse() => ChosenHorseName.Text = horses[localHSHandler.CurrentIdx].Name;

        private void PrevBet_Selection(object sender, RoutedEventArgs e) => ChangeSelectedBetLabel(localBSHandler.PrevBet());
        private void NextBet_Selection(object sender, RoutedEventArgs e) => ChangeSelectedBetLabel(localBSHandler.NextBet());

        public void ChangeSelectedBetLabel(int? idx = null)
        {
            if (idx == null)
            {
                BetSelection.Content = localBSHandler.GetBet();
                return;
            }
            BetSelection.Content = localBSHandler.GetBet(idx!.Value);
        }
    }
}