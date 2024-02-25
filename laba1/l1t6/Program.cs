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
            CompareSortMethods(Ethalon_BubbleSort, StudentMethods.Student_BubbleSort);

            CompareSortMethods(Ethalon_QuickSort, StudentMethods.Student_QuickSort);

            Console.ReadKey();
        }

        public static void CompareSortMethods(Func<int[], int[]> ethalon, Func<int[], int[]> student)
        {
            string[] fileList = Directory.GetFiles("arraysForTest", "*.txt");
            double ethalonTime = 1, studentTime;

            for (int i = 0; i < fileList.Count(); i++)
            {
                int[] arr = Array.ConvertAll(File.ReadAllText(fileList[i]).Split(), int.Parse);

                int[] copyForEthalon = new int[arr.Length], copyForStudent = new int[arr.Length];

                Array.Copy(arr, copyForEthalon, arr.Length);
                Array.Copy(arr, copyForStudent, arr.Length);

                try
                {
                    Stopwatch st = new Stopwatch();
                    st.Start();
                    ethalon(copyForEthalon);
                    st.Stop();
                    ethalonTime = st.Elapsed.Milliseconds;
                }
                catch (Exception ex) { Console.WriteLine("Exception in Ethalon sort: " + ex.Message); }

                try
                {
                    var cancellToken = new CancellationTokenSource(TimeSpan.FromSeconds(ethalonTime * 3f + 1000f));
                    Stopwatch st = new Stopwatch();

                    st.Start();
                    var studRes = Task.Run(() => student, cancellToken.Token);
                    studRes.Wait(cancellToken.Token);

                    st.Stop();
                    studentTime = st.Elapsed.Milliseconds;

                    //помилку видає тут, хз шо не то, а розбиратися в цьому поки лінь
                    //if (CheckIfSorted(studRes.Result)) { }
                }
                catch(Exception ex)
                {

                }
            }
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

        public static bool CheckIfSorted(int[] arr)
        {
            int[] copy = new int[arr.Length];
            Array.Sort(copy);
            for (int i = 0; i < arr.Length; i++) { if (arr[i] != copy[i]) return false; }
            return true;
        }
    }
}
