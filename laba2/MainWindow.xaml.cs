using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba2
{
    //тут по логике может быть капец, не обращай внимания :)
    //мне главное было заставить это все работать, я уже столько вариантов перепробовала шо це жесть
    //пока гружу просто рабочую версию, почищу уже потом (тут много ненужного скорее всего)
    public partial class MainWindow : Window
    {
        List<string> input = new List<string>();
        List<string> latestNum = new List<string>();
        double res = 0;
        bool firstNum = true;

        bool rememberNum = false;
        char prevAction = new char();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DisplayInput()
        {
            txtInput.Text = string.Join("", input);
        }
        private void AddToLists(string val)
        {
            input.Add(val);
            if (rememberNum) latestNum.Add(val);
            DisplayInput();
        }

#region Digit Buttons
        private void btn1_Click(object sender, RoutedEventArgs e) => AddToLists("1");
        private void btn2_Click(object sender, RoutedEventArgs e) => AddToLists("2");
        private void btn3_Click(object sender, RoutedEventArgs e) => AddToLists("3");
        private void btn4_Click(object sender, RoutedEventArgs e) => AddToLists("4");
        private void btn5_Click(object sender, RoutedEventArgs e) => AddToLists("5");
        private void btn6_Click(object sender, RoutedEventArgs e) => AddToLists("6");
        private void btn7_Click(object sender, RoutedEventArgs e) => AddToLists("7");
        private void btn8_Click(object sender, RoutedEventArgs e) => AddToLists("8");
        private void btn9_Click(object sender, RoutedEventArgs e) => AddToLists("9");
        private void btn0_Click(object sender, RoutedEventArgs e) => AddToLists("0");
        private void btn00_Click(object sender, RoutedEventArgs e) => AddToLists("00");
#endregion

#region Operations
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            ReformatInputList();
            AddToLists("+");
            rememberNum = true;
            OpButtonAction('+');
        }


        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            ReformatInputList();
            AddToLists("-");
            rememberNum = true;
            OpButtonAction('-');
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            ReformatInputList();
            AddToLists("×");
            rememberNum = true;
            OpButtonAction('×');
        }

        private void btnDide_Click(object sender, RoutedEventArgs e)
        {
            ReformatInputList();
            AddToLists("÷");
            rememberNum = true;
            OpButtonAction('÷');
        }
#endregion

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            OpButtonAction('=');
            prevAction = new char();
            txtInput.Text = " ";
            input = new List<string>();
            rememberNum = false;
        }

        public void OpButtonAction(char op)
        {
            if (prevAction == '\0') 
            { 
                prevAction = op;
                res = double.Parse(input.ElementAt(0));
                txtOutput.Text = $"{res}";
                return;
            }
            if (op != '=') latestNum.RemoveAt(latestNum.Count - 1);
            string lastNum = latestNum.Count != 1 ? string.Join("", latestNum) : latestNum.ElementAt(0);
            latestNum = new List<string>();

            switch (prevAction)
            {
                case '+':
                    res += double.Parse(lastNum);
                    break;

                case '-':
                    res -= double.Parse(lastNum);
                    break;

                case '×':
                    res *= double.Parse(lastNum);
                    break;

                case '÷':
                    res /= double.Parse(lastNum);
                    break;
            }
            prevAction = Convert.ToChar(input.ElementAt(input.Count - 1));
            txtOutput.Text = $"{res}";
            ReformatInputList();
        }

        public void ReformatInputList ()
        {
            string temp = string.Join("", input);
            input = new List<string> { temp };
            if (firstNum) { res += double.Parse(temp); firstNum = false; }
        }
    }
}