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

            await Task.WhenAll(lauchHorses, changePositionHorses);
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
        // Everything considering the race part


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
            for(int i = horses.Count; i < amount; i++)
            {
                horses.Add(new Horse(Horse.GenerateColor(horses), Horse.GenerateName(horses)));
            }
            AmountOfHorses_ListBox.Items.Refresh();
            AddImages();
        }
        private void RemoveHorses(int finalAmount)
        {
            for (int i = horses.Count; i > finalAmount; i--)
            {
                horses.RemoveAt(horses.Count - 1);
            }
            AmountOfHorses_ListBox.Items.Refresh();
            // TODO: Add "RemoveImages();"
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
        //TODO: Add "RemoveImages();"
        // Handlers for changing the amount of horses in race


        // Changing the leaderboard
        public void ChangePlace()
        {
            //tbd
        }
        // Changing the leaderboard
    }
}