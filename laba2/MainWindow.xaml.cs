using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using org.mariuszgromada.math.mxparser;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace laba2
{
    //тут по логике может быть капец, не обращай внимания :)
    //мне главное было заставить это все работать, я уже столько вариантов перепробовала шо це жесть
    //пока гружу просто рабочую версию, почищу уже потом (тут много ненужного скорее всего)
    public partial class MainWindow : Window
    {
        private List<string> input = new List<string>();

        public MainWindow() { InitializeComponent(); }

        private void DisplayInput() 
        {
            if (txtInput.Foreground != Brushes.Black) txtInput.Foreground = Brushes.Black;
            txtInput.Text = string.Join("", input).Replace('.', ','); 
        }

        public void DisplayRes()
        {
            Expression ex = new Expression(input.ElementAt(0));
            txtOutput.Text = $"{ex.calculate()}";
        }

        public void ReformatInputList ()
        {
            string temp = string.Join("", input);
            input = new List<string> { temp };
        }

    }
}