using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l3t2.Classes
{
    public class Colors
    {
        public static Color GetRandomColor()
        {
            var rndColor = new Random();
            var r = rndColor.Next(256);
            var g = rndColor.Next(256);
            var b = rndColor.Next(256);
            return Color.FromArgb(r,g,b);
        }
    }
}
