using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using l3t1_HorseRace.Classes;

namespace l3t1_HorseRace.ImageHandlres;

public class ImageGenerator
{
    public static Image GenerateImageObject(Horse horse)
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


    private static ImageSource GetColoredImage(BitmapImage image, BitmapImage mask, SolidColorBrush colorBrush)
    {
        Color color = colorBrush.Color;
        var imageBmp = new WriteableBitmap(image);
        var maskBmp = new WriteableBitmap(mask);
        var outBmp = BitmapFactory.New(image.PixelWidth, image.PixelHeight);
        outBmp.ForEach((x,y) =>
        {
            return MultiplyColors(imageBmp.GetPixel(x,y), color, maskBmp.GetPixel(x,y).A);
        });
        return outBmp;
    }
    private static Color MultiplyColors(Color imagePixel, Color chosenColor, byte alpha)
    {
        var amount = alpha / 255.0;
        var r = (byte)(chosenColor.R * amount + imagePixel.R * (1 - amount));
        var g = (byte)(chosenColor.G * amount + imagePixel.G * (1 - amount));
        var b = (byte)(chosenColor.B * amount + imagePixel.B * (1 - amount));
        return Color.FromArgb(imagePixel.A, r,g,b);
    }
}