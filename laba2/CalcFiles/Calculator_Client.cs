using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Calculator_Client
    {
        ArithmeticUnit_Receiver arithUnit;
        ControlUnit_Invoker controlUnit;

        public Calculator_Client()
        {
            arithUnit = new ArithmeticUnit_Receiver();
            controlUnit = new ControlUnit_Invoker();
        }
        public double Out() => arithUnit.Register;

        private double Run(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithUnit.Register;
        }

        public double Add(double operand) => Run(new Add(arithUnit, operand));
        public double Sub(double operand) => Run(new Sub(arithUnit, operand));
        public double Mul(double operand) => Run(new Mul(arithUnit, operand));
        public double Div(double operand) => Run(new Div(arithUnit, operand));
        public double Root(double operand) => Run(new Root(arithUnit, operand));
        public double Pow(double operand) => Run(new Add(arithUnit, operand));

        public void Exec(string op, double num)
        {
            switch (op)
            {
                case "+":
                    Add(num);
                    break;

                case "-":
                    Sub(num);
                    break;

                case "*":
                    Mul(num);
                    break;

                case "/":
                    Div(num);
                    break;

                case "√":
                    Root(num);
                    break;
            }
        }

        public double Undo(int levels)
        {
            controlUnit.Undo(levels);
            return arithUnit.Register;
        }
        public double Redo(int levels)
        {   
            controlUnit.Redo(levels);
            return arithUnit.Register;
        }
    }
}
