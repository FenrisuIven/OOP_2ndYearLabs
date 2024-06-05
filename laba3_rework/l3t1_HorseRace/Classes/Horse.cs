using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Threading.Tasks;

namespace l3t1_HorseRace.Classes
{
    public class Horse
    {
        public SolidColorBrush Color { get; private set; }
        public string Name { get; private set; }
        public int Speed { get; private set; }
        public TimeSpan Time { get; private set; }
        public int Coefficient { get; private set; }
        public int Bid { get; set; }
        public double Position { get; set; }


        private Stopwatch _stopwatch = new();
        

        public Horse(SolidColorBrush color, string name, int coefficient = 0)
        {
            Name = name;
            Color = color;
            Position = 0;
            Time = new TimeSpan();

            Speed = HorseGenerator.speedRnd.Next(5,10);

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
                if (Position >= 390)
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