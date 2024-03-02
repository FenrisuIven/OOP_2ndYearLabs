using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace l1t1
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyTimer_MultiThread timer = new MyTimer_MultiThread();
            timer.Start(() => Output(ConsoleColor.Red, 1), 1);
            timer.Start(() => Output(ConsoleColor.Green, 2), 5);

            Action output = () => Console.WriteLine("Hello");
            timer.Start(output, 10);
        }
        public static void Output(ConsoleColor color, int idx) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{idx}: " + DateTime.Now.ToString("HH:mm:ss"));
            Console.ResetColor();
        }
    }
}
