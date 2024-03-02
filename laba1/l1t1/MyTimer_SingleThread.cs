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
        public void Start(Action action, int s)
        {
            Console.WriteLine("Single thread timer was started. Interval: {0}s", s);
            while (true)
            {
                System.Threading.Thread.Sleep(s * 1000);
                action();
            }
        }
    }
}