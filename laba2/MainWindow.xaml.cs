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
                window.MaxWidth = 308;
                window.Width = 308; 
                ColumnDefinition sideCol = new ColumnDefinition();
                grid.ColumnDefinitions.Add(sideCol);

                Grid.SetColumnSpan(txtInput, 5);
                Grid.SetColumnSpan(txtOutput, 5);
                btnRoot.Visibility = Visibility.Visible;
                btnPow.Visibility = Visibility.Visible;
                btnPi.Visibility = Visibility.Visible;
                btnExp.Visibility = Visibility.Visible;
                btnLn.Visibility = Visibility.Visible;
            }
            else
            {
                window.MaxWidth = 250;
                window.Width = 250;
                grid.ColumnDefinitions.RemoveAt(grid.ColumnDefinitions.Count - 1);

                Grid.SetColumnSpan(txtInput, 4);
                Grid.SetColumnSpan(txtOutput, 4);
                btnRoot.Visibility = Visibility.Collapsed;
                btnPow.Visibility = Visibility.Collapsed;
                btnPi.Visibility = Visibility.Collapsed;
                btnExp.Visibility = Visibility.Collapsed;
                btnLn.Visibility = Visibility.Collapsed;
            }
        }
    }
}