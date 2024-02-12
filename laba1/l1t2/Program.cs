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
        public delegate void del1(int elem, int k, List<int> arr);
        public delegate void del2(int elem);

        static void Main(string[] args)
        {
            #region Setup
            Console.Write("Enter your array: ");
            int[] startArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());

            List<int> finalArr = new List<int>();
            #endregion

            del1 d1 = Check;
            for (int i = 0; i < startArr.Length; i++) d1(startArr[i], k, finalArr);

            del2 d2 = Out;
            Console.Write("Final arr: ");
            foreach (int elem in finalArr) d2(elem);

            Console.ReadKey();
        }

        static void Check(int elem, int k, List<int> arr) { if (elem % k == 0) arr.Add(elem); }
        static void Out(int elem) => Console.Write(elem);
    }
}
