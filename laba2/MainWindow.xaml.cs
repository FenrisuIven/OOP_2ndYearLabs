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

        public MainWindow() { InitializeComponent(); 
            InitializeButtons(); 
        }

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

        #region SidePannel
        private bool sidePannelActive = false;
        private void AddPannel_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppearence();
            sidePannelActive = !sidePannelActive;
        }

        public void ChangeAppearence()
        {
            List<Button> sidePannel = new() {
                operation_Root, 
                operation_Pow,
                digit_Pi, 
                digit_Exp, 
                operation_Ln
            };

            if (!sidePannelActive)
            {
                skip_AddPannel.Content = "<";
                ColumnDefinition sideCol = new ColumnDefinition();
                grid.ColumnDefinitions.Add(sideCol);
            }
            else
            {
                skip_AddPannel.Content = "≡";
                grid.ColumnDefinitions.RemoveAt(grid.ColumnDefinitions.Count - 1);
            }

            foreach (var button in sidePannel)
            {
                button.Visibility = button.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        #endregion

    }
}