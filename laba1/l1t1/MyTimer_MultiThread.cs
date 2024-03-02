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
        public void Start(Action action, int s)
        {
            Console.WriteLine("Multi thread timer was started. Interval: {0}s", s);

            Thread thread = new Thread(() => { 
                while (true)
                {
                    action();
                    Thread.Sleep(s * 1000);
                } 
            });
            thread.Start();
        }
    }
}
