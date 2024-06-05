using System.CodeDom;
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
        private List<Image> _horsesImages = new List<Image>();
        private int imagesPresentCount;

        private CancellationTokenSource _cancellToken; //unused


        // First initializing
        public MainWindow()
        {
            InitializeComponent();
            InitializeHorseList();
            InitializeImageList();
            
            HorsesLeaderboard.ItemsSource = horses;
        }

        private void InitializeHorseList()
        {
            horses = new ObservableCollection<Horse>
            {
                new Horse(Brushes.DarkSlateGray, "Lucilda"),
                new Horse(Brushes.GreenYellow, "Emanuel")
            };
        }
        private void InitializeImageList()
        {
            foreach (var horse in horses)
            {
                Image img = GenerateImageObject(horse);
                TrackLayout.Children.Add(img);
                _horsesImages.Add(img);
                imagesPresentCount++;
            }
        }

        // Not really sure about that part
        private Image GenerateImageObject(Horse horse)
        {
            Image resImage = new Image();
            BitmapImage horseTemplate = new BitmapImage();
            horseTemplate.BeginInit();
            horseTemplate.UriSource = new Uri(@"C:\Users\Nova\source\repos\OOP_Labs\laba3\l3t1\Horse\Images\Horses\WithOutBorder_0000.png");
            horseTemplate.EndInit();

            var mask = new BitmapImage();
            mask.BeginInit();
            mask.UriSource = new Uri(@"C:\Users\Nova\source\repos\OOP_Labs\laba3\l3t1\Horse\Images\HorsesMask\mask_0000.png");
            mask.EndInit();

            resImage.Source = GetColoredImage(horseTemplate, mask, horse.Color);
            resImage.Width = 75;
            resImage.Height = 75;
            return resImage;
        }
        // First initializing


        // Everything considering the images
        private ImageSource GetColoredImage(BitmapImage image, BitmapImage mask, SolidColorBrush colorBrush)
        {
            Color color = colorBrush.Color;
            var imageBmp = new WriteableBitmap(image);
            var maskBmp = new WriteableBitmap(mask);
            var outBmp = BitmapFactory.New(image.PixelWidth, image.PixelHeight);
            outBmp.ForEach((x,y,z) =>
            {
                return MultiplyColors(imageBmp.GetPixel(x,y), color, maskBmp.GetPixel(x,y).A);
            });
            return outBmp;
        }
        private Color MultiplyColors(Color imagePixel, Color chosenColor, byte alpha)
        {
            var amount = alpha / 255.0;
            var r = (byte)(chosenColor.R * amount + imagePixel.R * (1 - amount));
            var g = (byte)(chosenColor.G * amount + imagePixel.G * (1 - amount));
            var b = (byte)(chosenColor.B * amount + imagePixel.B * (1 - amount));
            return Color.FromArgb(imagePixel.A, r,g,b);
        }
        // Everything considering the images


        // Everything considering the race part
        private async void RunProgram(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();

            var lauchHorses = LaunchHorses();
            var changePositionHorses = ChangePositionHorses();
            var updateRatingPositionHorses = UpdateRatingPositionHorses();

            await Task.WhenAll(lauchHorses, changePositionHorses, updateRatingPositionHorses);

            MessageBox.Show($"Race has finished. {horses.ElementAt(0).Name} has won!");
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
                            PositionChanges(_horsesImages[i], i);
                        }
                    });
                    Task.Delay(100).Wait();
                    if (_cancellToken.Token.IsCancellationRequested) break;
                }
            });
        }
        private void PositionChanges(Image horse, int i) =>
            horse.Margin = new Thickness(horses[i].Position % 500, 0, 0, 0);

        private async Task UpdateRatingPositionHorses()
        {
            _cancellToken = new CancellationTokenSource();
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
                        if (!string.IsNullOrEmpty(Bet_HorseName) && horses.Any(elem => elem.Name == Bet_HorseName))
                        {
                            BankAccount += betPrice * 2;
                            Balance.Content = $"{BankAccount}";
                        }
                        StopProcess();
                    }
                    Dispatcher.Invoke(() =>
                    {
                        HorsesLeaderboard.Items.Refresh();
                    });
                }
            });
        }
        public void StopProcess()
        {
            _cancellToken?.Cancel();
        }

        // Everything considering the race part


        // Changing the leaderboard
        public void ChangeLeaderboardRating()
        {
            horses = new ObservableCollection<Horse>(horses.OrderBy(elem => elem.Time.TotalMilliseconds));
            HorsesLeaderboard.ItemsSource = horses;
            HorsesLeaderboard.Items.Refresh();
        }

        
        // Changing the leaderboard

    }
}