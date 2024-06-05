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
        static void Main(string[] args)
        {
            //Console.Write("Input array: ");
            //int[] startArr = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            //Console.Write("Input k: ");
            //int k = int.Parse(Console.ReadLine());
            int[] startArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 3;

            Func<int, bool> func = (elem) => elem % k == 0;

            int[] finalArr_Own = ArrayMod.Execute_Own(startArr, func);
            int[] finalArr_Linq = ArrayMod.Execute_Linq(startArr, func);

            Console.Write("\nStart arr:\t\t" + string.Join(" ", startArr));
            Console.Write("\nFinal arr (own):\t" + string.Join(" ", finalArr_Own));
            Console.Write("\nFinal arr (linq):\t" + string.Join(" ", finalArr_Linq));

            Console.ReadKey();
        }
    }
}
