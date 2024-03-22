using System;
using System.Diagnostics;
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

        public MainWindow() { InitializeComponent(); InitializeButtons(); }

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


        private bool sidePannelActive = false;
        private void AddPannel_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppearence();
            sidePannelActive = !sidePannelActive;
        }

        public void ChangeAppearence()
        {
            if (!sidePannelActive)
            {
                AddPannel.Content = "<";
                ColumnDefinition sideCol = new ColumnDefinition();
                grid.ColumnDefinitions.Add(sideCol);

                operation_Root.Visibility = Visibility.Visible;
                operation_Pow.Visibility = Visibility.Visible;
                digit_Pi.Visibility = Visibility.Visible;
                digit_Exp.Visibility = Visibility.Visible;
                operation_Ln.Visibility = Visibility.Visible;
            }
            else
            {
                AddPannel.Content = "≡";
                grid.ColumnDefinitions.RemoveAt(grid.ColumnDefinitions.Count - 1);

                operation_Root.Visibility = Visibility.Collapsed;
                operation_Pow.Visibility = Visibility.Collapsed;
                digit_Pi.Visibility = Visibility.Collapsed;
                digit_Exp.Visibility = Visibility.Collapsed;
                operation_Ln.Visibility = Visibility.Collapsed;
            }
        }

    }
}