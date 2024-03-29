﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    abstract class Command
    {
        protected ArithmeticUnit_Receiver unit;
        protected double operand;

        public abstract void Execute();
        public abstract void UnExecute();
    }

    class Add : Command
    {
        public Add(ArithmeticUnit_Receiver unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() => unit.Run("+", operand);
        public override void UnExecute() => unit.Run("-", operand);
    }

    class Sub : Command
    {
        public Sub(ArithmeticUnit_Receiver unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() => unit.Run("-", operand);
        public override void UnExecute() => unit.Run("+", operand);
    }

    class Mul : Command
    {
        public Mul(ArithmeticUnit_Receiver unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() => unit.Run("×", operand);
        public override void UnExecute() => unit.Run("÷", operand);
    }

    class Div : Command
    {
        public Div(ArithmeticUnit_Receiver unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() => unit.Run("÷", operand);
        public override void UnExecute() => unit.Run("×", operand);
    }

    class Root : Command
    {
        public Root(ArithmeticUnit_Receiver unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() => unit.Run("√", operand);
        public override void UnExecute() => unit.Run("x²", operand);
    }
    class Pow : Command
    {
        private double _num;
        public Pow(ArithmeticUnit_Receiver unit, double operand, double num)
        {
            this.unit = unit;
            this.operand = operand;
            _num = num;
        }
        public override void Execute() => unit.Run("xⁿ", operand, _num);
        public override void UnExecute() => unit.Run("undo xⁿ", operand, _num);
    }
    class Log : Command
    {
        private double _num;
        public Log(ArithmeticUnit_Receiver unit, double operand, double num)
        {
            this.unit = unit;
            this.operand = operand;
            _num = num;
        }
        public override void Execute() => unit.Run("ln", operand, _num);
        public override void UnExecute() => unit.Run("undo ln", operand, _num);
    }
}
