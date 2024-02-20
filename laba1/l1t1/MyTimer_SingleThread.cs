using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace l1t1
{
    public class MyTimer_SingleThread
    {
        private static bool running = true;
        public static void Start(Action action, int s, ConsoleKey stopKey)
        {
            Console.WriteLine("Single thread timer was started. Interval: {0}s, Exit key: {1}", s, stopKey);
            while (running)
            {
                System.Threading.Thread.Sleep(s * 1000);
                action();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == stopKey) Stop();
                }
            }
        }
        static void Stop()
        {
            running = false;
            Console.WriteLine("Single thread timer was stopped");
        }
    }
}