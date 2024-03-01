using System;
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
        char op = new char();
        bool firstOp = true;

        private void AddToList(string val, bool opAdded)
        {
            input.Add(val);
            ReformatInputList();
            DisplayInput();
            if (opAdded) return;
            currentNum.Add(val);
        }

        public void ButtonExec(string name, bool display)
        {
            if (display) AddToList(name, true);
            ReformatCurrNum();

            op = Convert.ToChar(name);

            double num = double.Parse(currentNum.ElementAt(0));
            if (!firstOp)
            {
                switch (name)
                {
                    case "+":
                        calc.Add(num);
                        break;
                    case "-":
                        calc.Sub(num);
                        break;
                    case "×":
                        calc.Mul(num);
                        break;
                    case "÷":
                        calc.Div(num);
                        break;
                }
            }
            currentNum = new List<string>();

            DisplayRes();
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
        private void btn0_Click(object sender, RoutedEventArgs e) => AddToList("0", false);
        private void btn00_Click(object sender, RoutedEventArgs e) => AddToList("00", false);
        private void btnDot_Click(object sender, RoutedEventArgs e) => AddToList(".", false);

#endregion

#region Operations
        private void btnPlus_Click(object sender, RoutedEventArgs e) => ButtonExec("+", true);
        private void btnMinus_Click(object sender, RoutedEventArgs e) => ButtonExec("-", true);
        private void btnMultiply_Click(object sender, RoutedEventArgs e) => ButtonExec("×", true);
        private void btnDide_Click(object sender, RoutedEventArgs e) => ButtonExec("÷", true);

        private void btnRoot_Click(object sender, RoutedEventArgs e) => ButtonExec("√", true);
        private void btnPow_Click(object sender, RoutedEventArgs e) => ButtonExec("ⁿ", true);
        private void btnPi_Click(object sender, RoutedEventArgs e) => ButtonExec("π", true);
        private void btnExp_Click(object sender, RoutedEventArgs e) => ButtonExec("e", true);
        private void btnLn_Click(object sender, RoutedEventArgs e) => ButtonExec("l", true);

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            ButtonExec(Convert.ToString(op), false);
            ReformatInputList();
            DisplayRes();
            txtInput.Foreground = Brushes.LightGray;
            input = new List<string>();
            currentNum = new List<string>();

            calc = new Calculator_Client();
        }


        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            input = new List<string>();
            txtOutput.Text = "";
            currentNum = new List<string>();
            op = new char();
        }
#endregion

    }
}
