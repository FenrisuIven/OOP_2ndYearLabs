using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace l1t3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double>[] series = {
                (num) => 1f / Math.Pow(2, num),
                (num) => 1f / Factorial(num), 
                (num) => 1f / UnevenPow(num)
            };
            double accuracy = .0001;

            double res_Series1 = CalculateSeries(series[0], accuracy);
            double res_Series2 = CalculateSeries(series[1], accuracy);
            double res_Series3 = CalculateSeries(series[2], accuracy);

            Console.WriteLine($"Accuracy: {Output(accuracy)}\n");

            Console.WriteLine($"Series 1:  1/2^0 + 1/2^1 + 1/2^2 + ... + 1/2^n" +
                $"\nres:\t  {Output(res_Series1)}\n");

            Console.WriteLine($"Series 2:  1/1! + 1/2! + 1/3! + ... + 1/n!" +
                $"\nres:\t  {Output(res_Series2)}\n");

            Console.WriteLine($"Series 3: -1/2^0 + 1/2^1 - 1/2^2 + ... ± 1/2^n" +
                $"\nres:\t  {Output(res_Series3)}\n");

            Console.ReadKey();
        }

        public static double CalculateSeries(Func<double, double> func, double accuracy)
        {
            double init = func(0);
            double funcVal = init;
            double sum = init;
            for (int i = 1; Math.Abs(funcVal) >= accuracy; i++)
            {
                if (func(i) == funcVal) continue;
                funcVal = func(i);
                sum += funcVal;
            }
            return sum;
        }

        static double Factorial(double num)
        {
            float res = 1;
            for (int i = 2; i <= num; i++) res *= i;
            return res;
        }
        static double UnevenPow(double num) => 
            Math.Pow(2, num) * (num % 2 == 0 ? -1f : 1f);

        static string Output(double num) => 
            $"{(num > 0 ? " " : "")}{num:0.##########}";
    }
}
