using System.Windows.Controls;
using l3t1_HorseRace.ViewModels;

namespace l3t1_HorseRace
{
    public partial class RaceLines : Page
    {
        public RaceLines()
        {
            InitializeComponent();
            RaceLinesVM.Instance.RequestImageAddition += AddImage;
            RaceLinesVM.Instance.RequestImageRemoval += RemoveImage;
        }

        public void AddImage(Image img)
        {
            TrackLayout.Children.Add(img);
            TrackLayout.UpdateLayout();
        }

        public void RemoveImage(Image img)
        {
            TrackLayout.Children.Remove(img);
            TrackLayout.UpdateLayout();
        }
    }
}