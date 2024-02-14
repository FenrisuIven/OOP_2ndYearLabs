using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l1t4
{
    internal class Program
    {
        public delegate double del(double num);
        static void Main(string[] args)
        {
            #region Setup
            Console.WriteLine("Вводьте рядки послідовно один за одним.\n" +
                "Поки вони матимуть вигляд 0 х чи 1 х чи 2 х" +
                "\n(тобто, цифра від 0 до 2, а після неї запис конкретного числа)," +
                "\nпрограма обчислюватиме одну з трьох функцій" +
                "\n\t0 -- sqrt(abs(x))" +
                "\n\t1 -- x^3 (інакше кажучи, x*x*x)" +
                "\n\t2 -- x + 3,5" +
                "\n(згідно цифри на початку) і виводитиме результат." +
                "\n\nЯкщо вхідний рядок не задовольнятиме цей формат, програма завершить роботу.\n");

            #endregion

            del[] operations = {   
                (num) => Math.Sqrt(Math.Abs(num)),
                (num) => Math.Pow(num, 3),
                (num) => num + 3.5 
            };

            while (true) {
                try 
                {
                    string[] input = Console.ReadLine().Split();
                    short indexOfOperation = short.Parse(input[0]);
                    float num = float.Parse(input[1]);
                    del res = operations[indexOfOperation];
                    Console.WriteLine("Результат виконання: {0}", res(num));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Сталася помилка: {0}\nНатисність будь-яку клавішу для остаточного виходу з програми", ex.Message);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
