using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace l3t1_HorseRace.Classes;

public class HorseGenerator
{
    public static Random speedRnd = new();
    public static List<SolidColorBrush> colors = new List<SolidColorBrush>
    {
        Brushes.Aquamarine,
        Brushes.Bisque,
        Brushes.BlueViolet,
        Brushes.CadetBlue,
        Brushes.Coral,
        Brushes.CornflowerBlue,
        Brushes.Crimson,
        Brushes.Gold,
        Brushes.GreenYellow,
        Brushes.SpringGreen,
        Brushes.Turquoise
    };
    public static List<string> names = new List<string>
    {
        "Charlie",
        "Lady",
        "Seattle",
        "Eclipse",
        "Jack",
        "Janice",
        "Lucilda",
        "Emanuel",
        "Seabiscuit",
        "Kelso",
        "Black Caviar",
        "Winx",
        "Barbaro"
    };

    public static string GenerateName(ObservableCollection<Horse> horses)
    {
        var rnd = new Random();
        var name = names.ElementAt(rnd.Next(names.Count));
        if (horses.Any(elem => elem.Name == name))
        {
            while (true)
            {
                name = names.ElementAt(rnd.Next(names.Count));
                if (horses.Any(elem => elem.Name == name)) continue;
                else break;
            }
        }
        return name;
    }
    public static SolidColorBrush GenerateColor(ObservableCollection<Horse> horses)
    {
        var rnd = new Random();
        var color = colors.ElementAt(rnd.Next(colors.Count));
        if (horses.Any(elem => elem.Color == color))
        {
            while (true)
            {
                color = colors.ElementAt(rnd.Next(colors.Count));
                if (horses.Any(elem => elem.Color == color)) continue;
                else break;
            }
        }
        return color;
    }
}