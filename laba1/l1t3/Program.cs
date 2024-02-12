using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace l1t3
{
    internal class Program
    {
        delegate float del(float elem);
        static void Main(string[] args)
        {
            del d1 = Series1;
            del d2 = Series2;
            del d3 = Series3;

            float res1 = Calculate(1, d1, 1);
            Console.WriteLine("res1 = {0}\n", res1);
            float res2 = Calculate(1, d2, 1);
            Console.WriteLine("res2 = {0}\n", res2);


            Console.ReadKey();
        }

        static float Calculate(int acc, del d, float start)
        {
            float res = 0;
            float elem = start;
            res += (float)1.0 / start;

            for (int count = 0; count < 20; count++)
            {
                elem = d(elem);
                Console.WriteLine($"elem = {elem}");
                res += (float)1.0/elem;
            }

            return res;
        }

        static float Series1(float elem) { elem *= 2; return elem; }
        static float Series2(float elem) 
        { 
            elem++; 

            return elem; 
        }
        static float Series3(float elem) 
        {
            bool isNegative = elem < 0 ? true : false;
            elem = Math.Abs(elem);
            elem = isNegative ? elem * -1 : elem;
            return elem;
        }
    }
}
