using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace l1t2
{
    internal class Program
    {
        public delegate void OutputDel(int elem);

        static void Main(string[] args)
        {
            OutputDel output = Out;

            int[] startArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int k = 2;

            int[] finalArr_Own = ArrayMod.Execute_Own(startArr, k);
            int[] finalArr_Lib = ArrayMod.Execute_Lib(startArr, k);

            Console.Write("Start arr: ");
            foreach (int elem in startArr) output(elem);

            Console.Write("\nFinal arr (own): ");
            foreach (int elem in finalArr_Own) output(elem);
            Console.Write("\nFinal arr (lib): ");
            foreach (int elem in finalArr_Lib) output(elem);

            Console.ReadKey();
        }


        static void Out(int elem) => Console.Write($"{elem} ");
    }
}
