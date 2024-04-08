using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace l3t1
{
    public class Horse
    {
        //just a template, will be changed later on
        public SolidColorBrush Color { get; private set; }
        public string Name { get; private set; }
        public int Position { get; private set; }
        public TimeSpan Time { get; private set; }
        public int Coefficient { get; private set; }
        public int Bid { get; set; }

        private double _acceleration;
        private Stopwatch _stopwatch;

        //not really how it is supposed to be done, I am just testing things out
        public Horse(SolidColorBrush color, string name, int position = 0, int coefficient = 0)
        {
            Name = name;
            Color = color;
            Position = position;
            Time = new TimeSpan(0,0,0,0, new Random().Next(9, 99999));
            //btw, Random for double (val < 1) is: new Random().NextDouble();

            Coefficient = coefficient;
        }

        public string GetTime() => $"{Time.Minutes:00}:{Time.Seconds:00}:{Time.Milliseconds:000000}";
    }
}
