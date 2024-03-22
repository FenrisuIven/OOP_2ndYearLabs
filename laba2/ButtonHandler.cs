﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace laba2
{
    public partial class MainWindow
    {
        private List<string> currentNum = new List<string>();
        bool firstOp = true;
        string lastOp = "";
        bool isNegative = false;
        bool blockInput = false;

        private void AddToList(string val, bool op)
        {
            if (firstOp) txtOutput.Text = "";
            if (currentNum.Count == 1 && currentNum.ElementAt(0) == "0")
            {
                if (val != ".") return;
            }
            input.Add(val);
            if (!op) currentNum.Add(val);
            DisplayInput();
        }

        //everything about "digit buttons" and "operations button" can and should be changed ofc
        //mostly the names and how the logic behind some "special" buttons (Pi, E, and so on) is handled
        //but at least
        #region Digit Buttons

        private void digitBtn_Click(object sender, RoutedEventArgs e)
        {
            string digit = (string)((Button)sender).Content;

            if (digit == "π")
            {
                ComplexNumLogic(Math.PI.ToString());
                return;
            }
            if (digit == "e")
            {
                ComplexNumLogic(Math.E.ToString());
                return;
            }

            if (digit == "0" && lastOp == "/" && currentNum == null) return;
            AddToList(digit, false);
        }

        private void ComplexNumLogic (string num)
        {
            currentNum = new List<string>();
            AddToList(num, false);
            DisplayInput();
            DisplayRes();
        }

        #endregion

        #region Operations

        private void operationBtn_Click(object sender, RoutedEventArgs e)
        {
            string operation = (string)((Button)sender).Content;

            if (blockInput) return;
            if (operation == "√") { RootLogic(); return; }
            if (operation == "xⁿ") { PowLogic(sender); return; }

            AddToList(operation, true);

            if (firstOp) { FirstOp(); firstOp = false; }
            else
            {
                if (operation == "-" && currentNum.Count == 0 && firstOp)
                {
                    AddToList("-", true);
                    lastOp = "-";
                    isNegative = true;
                }
                ReformatCurrNum();
                calc.Exec(operation, double.Parse(currentNum.ElementAt(0)));
            }

            currentNum = new List<string>();
            lastOp = operation;
            DisplayRes();
        }

        private void RootLogic()
        {
            bool skipRes = false;
            ReformatCurrNum();
            try { calc.Root(double.Parse(currentNum.ElementAt(0)) * (isNegative ? -1 : 1)); }
            catch(ArgumentOutOfRangeException) { skipRes = true; txtOutput.Text = "Invalid input"; }
            FinishExec(skipRes);
        }
        private void PowLogic(object sender)
        {
            blockInput = true;
            FirstOp();
            AddToList("^", true);
            lastOp = (string)((Button)sender).Content;
        }
        private void LnLogic(object sender)
        {
            //tbd
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            bool skipRes = false;
            ReformatCurrNum();
            try { calc.Exec(lastOp == "" ? "+" : lastOp, double.Parse(currentNum.ElementAt(0)), double.Parse(currentNum.ElementAt(0))); }
            catch (DivideByZeroException) { skipRes = true; txtOutput.Text = "Cannot divide by zero."; }
            FinishExec(skipRes);
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            input = new List<string>();
            txtOutput.Text = "";
            currentNum = new List<string>();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e) => AddToList("1", false); //tbd

        private void FirstOp()
        {
            ReformatCurrNum();
            calc.Add(double.Parse(currentNum.ElementAt(0)));
            currentNum = new List<string>();
        }

        public void FinishExec(bool skipRes)
        {
            ReformatInputList();
            DisplayInput();
            if (!skipRes) DisplayRes();
            txtInput.SetCurrentValue(ForegroundProperty, Brushes.LightGray);

            input = new List<string>();
            currentNum = new List<string>();
            calc = new Calculator_Client();
            lastOp = "";
            firstOp = true;
            isNegative = false;
        }
        #endregion

    }
}
