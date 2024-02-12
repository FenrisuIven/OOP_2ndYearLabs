using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace l1t1
{
    public delegate void Del(Action action, int delay, ConsoleKey stopKey);
    public class Program
    {
        static void Main(string[] args)
        {
            Action message = delegate () { Console.WriteLine(DateTime.Now.ToString("HH:mm:ss")); };

            Del del = MyTimer_SingleThread.Start;
            del(message, 1, ConsoleKey.A);

            
            del = MyTimer_MultiThread.Start;
            del(message, 1, ConsoleKey.B);
            del(message, 2, ConsoleKey.B);
            del(message, 3, ConsoleKey.B);
        }
    }
}
