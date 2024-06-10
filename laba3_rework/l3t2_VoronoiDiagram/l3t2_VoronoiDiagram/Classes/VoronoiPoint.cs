using System;
using System.Drawing;

namespace l3t2_VoronoiDiagram.Classes
{
    public class VoronoiPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Color AssociatedColor { get; private set; }

        private int Radius = 3;
        
        public VoronoiPoint(int x, int y)
        {
            X = x;
            Y = y;
            AssociatedColor = Colors.GetRandomColor();
        }

        public void DrawPoint(Graphics g)
        {
            g.FillEllipse(Brushes.Black, X - (int)Math.Floor(Radius / 2.0), Y - (int)Math.Floor(Radius / 2.0), Radius, Radius);
        }

        public void DrawPixel(Graphics g, int x, int y)
        {
            g.FillRectangle(new SolidBrush(AssociatedColor), x, y, 1, 1);
        }
    }
}