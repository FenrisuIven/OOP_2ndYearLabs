using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace laba2
{
    public partial class MainWindow
    {
        private List<string> currentNum = new List<string>();
        bool firstOp = true;
        string lastOp = "";
        bool isNegative = false;

        private void AddToList(string val, bool op)
        {
            if (firstOp) txtOutput.Text = "";
            if (currentNum.Count == 1 && currentNum.ElementAt(0) == "0")
            {   
                if (val == "0")
                {   //Дозволяємо появу лише одного нуля на початку числа,
                    //щоб включити випадки коли треба ввести шось типу 0.5
                    MessageBox.Show("That's enough zeroes for one num.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (val == ".")
                {
                    MessageBox.Show("That's my boi.", "Error", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Nope. Can't do that.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            input.Add(val);
            if (!op) currentNum.Add(val);
            DisplayInput();
        }

        private void ButtonExec(string op, bool addToList)
        {
            AddToList(op, true);
            if (firstOp) { FirstOp(); firstOp = false; }
            else
            {
                ReformatCurrNum();
                calc.Exec(op, double.Parse(currentNum.ElementAt(0)));
            }
            currentNum = new List<string>();
            lastOp = op;
            DisplayRes();
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

        #region Digit Buttons
        private void btn1_Click(object sender, RoutedEventArgs e) => AddToList("1", false);
        private void btn2_Click(object sender, RoutedEventArgs e) => AddToList("2", false);
        private void btn3_Click(object sender, RoutedEventArgs e) => AddToList("3", false);
        private void btn4_Click(object sender, RoutedEventArgs e) => AddToList("4", false);
        private void btn5_Click(object sender, RoutedEventArgs e) => AddToList("5", false);
        private void btn6_Click(object sender, RoutedEventArgs e) => AddToList("6", false);
        private void btn7_Click(object sender, RoutedEventArgs e) => AddToList("7", false);
        private void btn8_Click(object sender, RoutedEventArgs e) => AddToList("8", false);
        private void btn9_Click(object sender, RoutedEventArgs e) => AddToList("9", false);
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (lastOp == "/" && currentNum == null) return;
            AddToList("0", false);
        }
        private void btn00_Click(object sender, RoutedEventArgs e) => AddToList("00", false);
        private void btnDot_Click(object sender, RoutedEventArgs e) => AddToList(".", false);

        #endregion

        #region Operations
        private void btnPlus_Click(object sender, RoutedEventArgs e) => ButtonExec("+", true);
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (currentNum.Count == 0 && firstOp) 
            { 
                AddToList("-", true);
                lastOp = "-";
                isNegative = true;
            }

        }
        private void btnMultiply_Click(object sender, RoutedEventArgs e) => ButtonExec("*", true);
        private void btnDivide_Click(object sender, RoutedEventArgs e) => ButtonExec("/", true);

        private void btnRoot_Click(object sender, RoutedEventArgs e)
        {
            bool skipRes = false;
            ReformatCurrNum();
            try { calc.Root(double.Parse(currentNum.ElementAt(0)) * (isNegative ? -1 : 1)); }
            catch(ArgumentOutOfRangeException) { skipRes = true; txtOutput.Text = "Invalid input"; }
            FinishExec(skipRes);
        }
        private void btnPow_Click(object sender, RoutedEventArgs e) => calc.Pow(0);
        private void btnPi_Click(object sender, RoutedEventArgs e)
        {
            currentNum = new List<string>();
            AddToList(Math.PI.ToString(), false);
            DisplayInput(); DisplayRes();
        }
        private void btnExp_Click(object sender, RoutedEventArgs e) => calc.Root(1);
        private void btnLn_Click(object sender, RoutedEventArgs e) => calc.Root(1);

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            bool skipRes = false;
            ReformatCurrNum();
            try { calc.Exec(lastOp == "" ? "+" : lastOp, double.Parse(currentNum.ElementAt(0))); }
            catch (DivideByZeroException) { skipRes = true; txtOutput.Text = "Cannot divide by zero."; }
            //if (firstOp) FirstOp();
            FinishExec(skipRes);
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            input = new List<string>();
            txtOutput.Text = "";
            currentNum = new List<string>();
        }

        private void FirstOp()
        {
            ReformatCurrNum();
            calc.Add(double.Parse(currentNum.ElementAt(0)));
            currentNum = new List<string>();
        }
#endregion

    }
}
