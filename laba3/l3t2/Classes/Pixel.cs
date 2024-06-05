using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l3t2
{
    public class Pixel
    {
        public static void Draw(Point location, SolidBrush brush, Graphics g)
        {
            g.FillRectangle(brush, location.X, location.Y, 1, 1);
        }

        public static Point FindClosestPoint(Point currentPixel, List<Point> points) 
        {
            var closestPoint = points[0];
            double shortestDistance = Distance(currentPixel, closestPoint);

            foreach (var point in points)
            {
                double distance = Distance(currentPixel, point);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }

        private static double Distance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
