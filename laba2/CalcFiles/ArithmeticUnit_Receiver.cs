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

        public void Run(char opCode, double operand)
        {
            switch (opCode)
            {
                case '+':
                    Register += operand;
                    break;

                case '-':
                    Register -= operand;
                    break;

                case '*':
                    Register *= operand;
                    break;
                
                case '/':
                    Register /= operand;
                    break;
            }
        }
    }
}
