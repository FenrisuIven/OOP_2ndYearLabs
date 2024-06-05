using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;

namespace l3t1
{
    public partial class Horse
    {
        //just a template, will be changed later on
        public SolidColorBrush Color { get; private set; }
        public string Name { get; private set; }
        public int Speed { get; private set; }
        public TimeSpan Time { get; private set; }
        public int Coefficient { get; private set; }
        public int Bid { get; set; }
        public double Position { get; set; }


        private Stopwatch _stopwatch = new Stopwatch();


        //not really how it is supposed to be done, I am just testing things out
        public Horse(SolidColorBrush color, string name, int coefficient = 0)
        {
            Name = name;
            Color = color;
            Position = 0;
            Time = new TimeSpan(0,0,0,0, new Random().Next(9, 99999));
            //btw, Random for double (val < 1) is: new Random().NextDouble();

            Speed = new Random().Next(5, 10);

            Coefficient = coefficient;

            _stopwatch.Start();
        }
        public bool TimerRunning() => _stopwatch.IsRunning;

        public void ChangeAcceleration()
        {
            var value = new Random().Next(7, 11) / 10.0;
            Position += Speed * value;
        }
        public async Task RunAsync()
        {
            while (true)
            {
                if (Position >= 400)
                {
                    _stopwatch.Stop();
                    break;
                }
                Time = _stopwatch.Elapsed;
                ChangeAcceleration();
                await Task.Delay(100);
            }
        }
    }
}
