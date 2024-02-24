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
        private void AddToList(string val)
        {
            input.Add(val);
            DisplayInput();
        }

        public void ButtonExec(string name)
        {
            AddToList(name);
            ReformatInputList();
            DisplayRes();
        }

#region Digit Buttons
        private void btn1_Click(object sender, RoutedEventArgs e) => AddToList("1");
        private void btn2_Click(object sender, RoutedEventArgs e) => AddToList("2");
        private void btn3_Click(object sender, RoutedEventArgs e) => AddToList("3");
        private void btn4_Click(object sender, RoutedEventArgs e) => AddToList("4");
        private void btn5_Click(object sender, RoutedEventArgs e) => AddToList("5");
        private void btn6_Click(object sender, RoutedEventArgs e) => AddToList("6");
        private void btn7_Click(object sender, RoutedEventArgs e) => AddToList("7");
        private void btn8_Click(object sender, RoutedEventArgs e) => AddToList("8");
        private void btn9_Click(object sender, RoutedEventArgs e) => AddToList("9");
        private void btn0_Click(object sender, RoutedEventArgs e) => AddToList("0");
        private void btn00_Click(object sender, RoutedEventArgs e) => AddToList("00");
        private void btnDot_Click(object sender, RoutedEventArgs e) => AddToList(".");

#endregion

#region Operations
        private void btnPlus_Click(object sender, RoutedEventArgs e) => ButtonExec("+");
        private void btnMinus_Click(object sender, RoutedEventArgs e) => ButtonExec("-");
        private void btnMultiply_Click(object sender, RoutedEventArgs e) => ButtonExec("×");
        private void btnDide_Click(object sender, RoutedEventArgs e) => ButtonExec("÷");

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            ReformatInputList();
            DisplayRes();
            txtInput.Foreground = Brushes.LightGray;
            input = new List<string>();
        }


        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            input = new List<string>();
            txtOutput.Text = "";
        }
#endregion

    }
}
