using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.CodeDom;

namespace laba2
{
    public partial class MainWindow
    {
        #region Digit Buttons
        private void digitBtn_Click(object sender, RoutedEventArgs e)
        {
            string digit = (string)((Button)sender).Content;

            if (digit == "π")
            {
                CustomNumLogic(Math.PI.ToString());
                return;
            }
            if (digit == "e")
            {
                CustomNumLogic(Math.E.ToString());
                return;
            }

            if (digit == "0" && lastOp == "÷" && currentNum == null) return;
            if (digit == ".") digit = ",";
            AddToList(digit, false);
        }

        private void CustomNumLogic(string num)
        {
            currentNum = new List<string>();
            AddToList(num, false);
            DisplayInput();
            DisplayRes();
        }
        #endregion

        #region Operations
        public bool skip = false;
        private void operationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (blockInput) return;
            string operation = (string)((Button)sender).Content;

            switch (operation)
            {
                case "√":
                    RootLogic();
                    return;

                case "xⁿ":
                    PowLogic(sender); 
                    return;

                case "ln":
                    LnLogic(sender); 
                    return;
            }

            AddToList(operation, true);

            if (firstOp) 
            {
                if (operation == "-" && currentNum.ElementAt(0) == "" && input.Count == 1)
                {
                    lastOp = "-";
                    isNegative = true;
                }
                else FirstOp();
                firstOp = false;
            }
            else if (skip) skip = false;
            else
            {
                ReformatCurrNum();
                calc.Exec(lastOp, double.Parse(currentNum.ElementAt(0)));
            }

            currentNum = new List<string>();
            lastOp = operation;
            DisplayRes();
        }

        private void RootLogic()
        {
            bool skipRes = false;
            ReformatCurrNum();

            if (isNegative)
            {
                skipRes = true;
                txtOutput.Text = "Invalid input";
            }
            else
            {
                calc.Root(double.Parse(currentNum.ElementAt(0)));
            }

            FinishExec(skipRes);
        }
        private void PowLogic(object sender)
        {
            AddToList("^", true);
            blockInput = true;
            FirstOp();
            lastOp = (string)((Button)sender).Content;
        }
        private void LnLogic(object sender)
        {
            if (firstOp && currentNum.Count == 0)
            {
                input.Add("ln(");
                AddToList("ln", true);
                input.Add(")_");
            }
            else
            {
                input.Add(" ln_");
            }

            DisplayInput();

            blockInput = true;
            FirstOp();
            lastOp = (string)((Button)sender).Content;
        }
        #endregion

        #region "Service" buttons
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            bool skipRes = false;
            ReformatCurrNum();

            try
            {
                string num = currentNum.ElementAt(0);
                calc.Exec(lastOp == "" ? "+" : lastOp, double.Parse(num), double.Parse(num));
            }
            catch (DivideByZeroException) 
            {
                skipRes = true;
                txtOutput.Text = "Cannot divide by zero";
            }

            FinishExec(skipRes);
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            calc = new Calculator_Client();
            input = new List<string>();
            currentNum = new List<string>();
            lastOp = "";
            firstOp = true;
            isNegative = false;

            txtInput.Text = "";
            txtOutput.Text = "";
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            ReformatCurrNum();
            string num = currentNum.ElementAt(0);
            calc.Exec(lastOp == "" ? "+" : lastOp, double.Parse(num), double.Parse(num));
            calc.Undo(1);

            input = new List<string>() { calc.Out().ToString() };
            currentNum = new List<string>() { calc.Out().ToString() };
            skip = true;

            DisplayInput();
            DisplayRes();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            input.RemoveAt(input.Count - 1);
            currentNum.RemoveAt(currentNum.Count - 1);
            DisplayInput();
            DisplayRes();
        }

        
        #endregion
    }
}
