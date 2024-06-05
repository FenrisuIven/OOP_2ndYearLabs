using l3t2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l3t2
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Color AssociatedColor { get; private set; }
        public int Radius { get; private set; }

        public Point(int x, int y, int radius = 15)
        {
            X = x;
            Y = y;
            Radius = radius;
            AssociatedColor = Colors.GetRandomColor();
        }

        public void DrawPoint(Graphics g)
        {
            int border = 4;
            g.FillEllipse(Brushes.Black, X - Radius, Y - Radius, Radius, Radius);
            g.FillEllipse(Brushes.White, X - Radius + (border/2), Y - Radius + (border/2), Radius - border, Radius - border);
        }
            
    }
}
