using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class ArithmeticUnit_Receiver
    {
        public double Register { get; private set; }

        public void Run(string opCode, double operand)
        {
            switch (opCode)
            {
                case "+":
                    Register += operand;
                    break;

                case "-":
                    Register -= operand;
                    break;

                case "*":
                    Register *= operand;
                    break;
                
                case "/":
                    if (operand == 0) throw new DivideByZeroException();
                    Register /= operand;
                    break;

                case "√":
                    if (operand < 0) throw new ArgumentOutOfRangeException();
                    Register = Math.Sqrt(operand);
                    break;

                case "undo √":
                    Register = Math.Pow(Register, 2);
                    break;
            }
        }
    }
}
