using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l1t2
{
    public class ArrayMod
    {
        public static int[] Execute_Own(int[] arr, Func<int, bool> func)
        {
            int[] res = new int[arr.Length];
            int count = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (func(arr[i])) { res[count] = arr[i]; count++; }
            }
            Array.Resize(ref res, count);
            return res;
        }
        public static int[] Execute_Linq(int[] arr, Func<int, bool> func) => 
            arr.Where(elem => func(elem)).ToArray();
    }
}
