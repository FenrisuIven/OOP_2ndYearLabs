using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace l1t1
{
    public class MyTimer_MultiThread
    {
        private static bool running = true;

        public static void Start(Action action, int s, ConsoleKey stopKey)
        {
            Console.WriteLine("Multi thread timer was started. Interval: {0}s, Exit key: {1}", s, stopKey);

            Thread thread = new Thread(() => { 
                while (running)
                {
                    action();
                    Thread.Sleep(s * 1000);

                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == stopKey) Stop();
                    }
                } 
            });
            thread.Start();
        }

        static void Stop()
        {
            running = false;
            Console.WriteLine("Multi thread timer was stopped");
            Console.ReadKey();
        }
    }
}
