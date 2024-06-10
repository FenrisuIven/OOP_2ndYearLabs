using System;
using System.Drawing;

namespace l3t2_VoronoiDiagram.Classes;

public class Colors
{
    private static Random _rnd = new();

    public static Color GetRandomColor()
    {
        return Color.FromArgb(_rnd.Next(50,256), _rnd.Next(50,256),_rnd.Next(50,256));
    }
}