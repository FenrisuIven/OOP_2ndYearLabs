using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l1t6
{
    public class StudentMethods
    {
        public static int[] Student_BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
            return arr;
        }


        public static int[] Student_QuickSort(int[] arr) => Student_QuickSort(arr, 0, arr.Length - 1);

        public static int[] Student_QuickSort(int[] arr, int minIdx, int maxIdx)
        {
            if (minIdx >= maxIdx) return arr;

            var pivotIndex = Partition(arr, minIdx, maxIdx);
            Student_QuickSort(arr, minIdx, pivotIndex - 1);
            Student_QuickSort(arr, pivotIndex + 1, maxIdx);

            return arr;
        }
        static int Partition(int[] arr, int minIdx, int maxIdx)
        {
            var pivot = minIdx - 1;
            for (var i = minIdx; i < maxIdx; i++)
            {
                if (arr[i] < arr[maxIdx])
                {
                    pivot++;
                    (arr[pivot], arr[i]) = (arr[i], arr[pivot]);
                }
            }

            pivot++;
            (arr[pivot], arr[maxIdx]) = (arr[maxIdx], arr[pivot]);
            return pivot;
        }
    }
}
