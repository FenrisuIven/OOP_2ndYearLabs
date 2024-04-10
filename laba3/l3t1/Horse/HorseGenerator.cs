using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace l3t1
{
    public partial class Horse 
    {

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
}
