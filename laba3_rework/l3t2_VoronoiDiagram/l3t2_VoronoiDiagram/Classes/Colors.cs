using System;
using System.Drawing;

namespace l3t2_VoronoiDiagram.Classes;

public class Colors
{
    private static Random _rnd = new();

    public static Color GetRandomColor()
    {
        int r = _rnd.Next(50, 256);
        int g = _rnd.Next(50, 256);
        int b = _rnd.Next(50, 256);
        return Color.FromArgb(r, g, b);
    }
}