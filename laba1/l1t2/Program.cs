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
        public delegate int[] operationDel(int[] arr, int k, Func<int, bool> func);

        static void Main(string[] args)
        {
            Console.Write("Input array: ");
            int[] startArr = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            Console.Write("Input k: ");
            int k = int.Parse(Console.ReadLine());
            Func<int, bool> func = (elem) => (elem % k == 0);


            operationDel operation = ArrayMod.Execute_Own;
            int[] finalArr_Own = operation(startArr, k, func);

            operation = ArrayMod.Execute_Linq;
            int[] finalArr_Linq = operation(startArr, k, func);



            Console.Write("\nStart arr:\t\t" + string.Join(" ", startArr));

            Console.Write("\nFinal arr (own):\t" + string.Join(" ", finalArr_Own));

            Console.Write("\nFinal arr (linq):\t" + string.Join(" ", finalArr_Linq));

            Console.ReadKey();
        }
    }
}
