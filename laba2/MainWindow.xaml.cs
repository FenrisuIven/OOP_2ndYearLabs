using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using org.mariuszgromada.math.mxparser;

namespace laba2
{
    public partial class MainWindow : Window
    {
        private List<string> input = new List<string>();
        private Calculator_Client calc = new Calculator_Client();

        public MainWindow() { InitializeComponent(); }

        private void DisplayInput() 
        {
            if (txtInput.Foreground != Brushes.Black) txtInput.Foreground = Brushes.Black;
            txtInput.Text = string.Join("", input).Replace('.', ','); 
        }

        public void DisplayRes()
        {
            txtOutput.Text = $"{calc.Out()}";
        }

        public void ReformatInputList()
        {
            string temp = string.Join("", input);
            input = new List<string> { temp };
        }

        public void ReformatCurrNum()
        {
            string temp = string.Join("", currentNum);
            currentNum = new List<string> { temp };
        }
    }
}