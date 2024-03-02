using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace l1t6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bubble sort");
            CompareSortMethods(Ethalon_BubbleSort, StudentMethods.Student_BubbleSort);

            Console.WriteLine("Quick sort");
            CompareSortMethods(Ethalon_QuickSort, StudentMethods.Student_BubbleSort);

            Console.ReadKey();
        }

        public static void CompareSortMethods(Func<int[], int[]> ethalon, Func<int[], int[]> student)
        {
            double ethalonTime = 1, studentTime;

            int[] arr = GenerateArr(30000);

            int[] copyForEthalon = new int[arr.Length],
                  copyForStudent = new int[arr.Length];

            Array.Copy(arr, copyForEthalon, arr.Length);
            Array.Copy(arr, copyForStudent, arr.Length);

            try
            {
                Stopwatch st = Stopwatch.StartNew();
                ethalon(copyForEthalon);
                st.Stop();
                ethalonTime = st.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Ethalon sort finished working. Ellapsed time: {TimeSpan.FromMilliseconds(ethalonTime)}");
            }
            catch (Exception ex) { Console.WriteLine("Exception in Ethalon sort: " + ex.Message); }

            var cancelToken = new CancellationTokenSource(TimeSpan.FromMilliseconds(1000000));
            try
            {
                Stopwatch st = Stopwatch.StartNew();
                var studRes = Task.Run(() => student(copyForStudent), cancelToken.Token);
                studRes.Wait(cancelToken.Token);
                st.Stop();
                studentTime = st.Elapsed.TotalMilliseconds;

                if (CheckIfSorted(copyForEthalon, studRes.Result))
                    Console.WriteLine($"Student sort gave right answer. Ellapsed time: " +
                        $"{TimeSpan.FromMilliseconds(studentTime)}");
                else
                {
                    Console.WriteLine($" - X Student sort gave wrong answer. Ellapsed time: " +
                        $"{TimeSpan.FromMilliseconds(studentTime)}\n");
                    return;
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($" - ! Student sort took longer than {TimeSpan.FromMilliseconds(ethalonTime * 3 + 50)} ms\n");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" - ! Exception in Student sort: {ex.Message}\n");
                return;
            }

            if (ethalonTime / 3 - 50 <= studentTime && studentTime <= ethalonTime * 3 + 50)
                Console.WriteLine("+ Execution times are similar enough\n");

            else Console.WriteLine("- Execution times vary too much\n");
        }

        #region Ethalon Sorts
        public static int[] Ethalon_BubbleSort(int[] arr)
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

        static int[] Ethalon_QuickSort(int[] arr) => Ethalon_QuickSort(arr, 0, arr.Length - 1);

        static int[] Ethalon_QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex) return array;

            var pivotIndex = Partition(array, minIndex, maxIndex);
            Ethalon_QuickSort(array, minIndex, pivotIndex - 1);
            Ethalon_QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    (array[pivot], array[i]) = (array[i], array[pivot]);
                }
            }

            pivot++;
            (array[pivot], array[maxIndex]) = (array[maxIndex], array[pivot]);
            return pivot;
        }
        #endregion

        public static bool CheckIfSorted(int[] ethalonArr, int[] studArr)
        {
            for (int i = 0; i < ethalonArr.Length; i++) 
            { 
                if (ethalonArr[i] != studArr[i]) 
                    return false; 
            }
            return true;
        }

        public static int[] GenerateArr(int amountOfElems)
        {
            int[] res = new int[amountOfElems];
            Random rnd = new Random();
            for(int i = 0; i < amountOfElems; i++)
                res[i] = rnd.Next(0, 100000);
            return res;
        }
    }
}
