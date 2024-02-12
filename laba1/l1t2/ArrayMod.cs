using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l1t2
{
    public class ArrayMod
    {
        public static int[] Execute_Own(int[] arr, int k)
        {
            int[] res = new int[arr.Length];
            int count = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (arr[i] % k == 0) { res[count] = arr[i]; count++; }
            }
            Array.Resize(ref res, count);
            return res;
        }
        public static int[] Execute_Lib(int[] arr, int k)
        {
            return arr.Where(elem => elem % k == 0).ToArray();
        }
    }
}
