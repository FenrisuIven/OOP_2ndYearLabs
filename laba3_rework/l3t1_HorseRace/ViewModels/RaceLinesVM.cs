using System.Windows.Controls;

namespace l3t1_HorseRace.ViewModels;

public class RaceLinesVM
{
    private static RaceLinesVM _instance;

    public static RaceLinesVM Instance
    {
        get
        {
            if (_instance == null) _instance = new();
            return _instance;
        }
    }

    public delegate void ImageAction(Image img);
    public event ImageAction RequestImageAddition;
    public event ImageAction RequestImageRemoval;

    public void ImgAdditionRequested(Image img) => RequestImageAddition?.Invoke(img);
    public void ImgRemovalRequested(Image img) => RequestImageRemoval?.Invoke(img);
}