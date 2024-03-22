using System;
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
            {   //if user has entered 0 as first digit
                if (val != ".") return;
                //allow the "." as the only symbol to go after it -- "0."
                //basically to prevent input like "0185"
            }
            input.Add(val);
            if (!op) currentNum.Add(val);
            DisplayInput();
        }

        //everything about "digit buttons" and "operations button" should be
        //changed ofc, mostly the names and the way logic behind some "special"
        //buttons (Pi, E, and so on) is handled
        //but at least the general direction of it is correct ig :P
        #region Digit Buttons

        private void digitBtn_Click(object sender, RoutedEventArgs e)
        {
            string digit = (string)((Button)sender).Content;

            if (digit == "π")
            {   //those two if's can be made shorter, need to figure out how
                ComplexNumLogic(Math.PI.ToString());
                return;
            }
            if (digit == "e")
            {
                ComplexNumLogic(Math.E.ToString());
                return;
            }

            if (digit == "0" && lastOp == "/" && currentNum == null) return;
            //basically if user chose "divide" as operation and then tried to
            //enter "0" (and there is no other digits entered, so: "num / 0"):
            //return

            AddToList(digit, false);
        }

        private void ComplexNumLogic (string num)
        {   //"handler" of adding Pi and Exp nums, need to change it's name
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
            //this is "true" when user has chosen pow as operation
            //we want to exclude situations like: "num ^ * +" and so on
            //(technically, I should make this possible for all of the operations too)

            if (operation == "√") { RootLogic(); return; }
            if (operation == "xⁿ") { PowLogic(sender); return; }

            //here: only the input one
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
        {   //basically - calculate root only of the current inputted number and
            //return it as result of calculations
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

        #endregion


        #region "Service" buttons

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            //skipRes is basically: "to not output calculation result"
            bool skipRes = false;
            ReformatCurrNum();

            //lastOp can be null if we press "Equal" and when we have only one number entered
            //second num is required for when the lasstOp was Pow -- we "pow" "registry" to this "second num"
            try { calc.Exec(lastOp == "" ? "+" : lastOp, double.Parse(currentNum.ElementAt(0)), double.Parse(currentNum.ElementAt(0))); }

            //shouldn't be possible, BUT if we DO get to diving by zero:
            catch (DivideByZeroException) { skipRes = true; txtOutput.Text = "Cannot divide by zero."; }
            FinishExec(skipRes);
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            input = new List<string>();
            txtOutput.Text = "";
            calc = new Calculator_Client();

            input = new List<string>();
            currentNum = new List<string>();
            lastOp = "";
            firstOp = true;
            isNegative = false;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e) => AddToList("1", false); //tbd

        private void FirstOp()
        {   //"firstOp" is when we have only one num entered and add a op after:
            //basically add current inputted num to calc's registry
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
            blockInput = false;
        }
        #endregion
    }
}
