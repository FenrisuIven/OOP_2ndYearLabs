using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
            if (firstOp)
            {
                if (currentNum.Count == 0 && op)
                {
                    currentNum.Add(txtOutput.Text);
                    input.Add(txtOutput.Text);
                }
                txtOutput.Text = "";
            }

            if (currentNum.Count == 1 && currentNum.ElementAt(0) == "0" && val != ",") return;

            if (val != "ln") input.Add(val);

            if (!op) currentNum.Add(val);
            else
            {
                ReformatInputList();
                if (input.ElementAt(0).Length > 12) input.Add("\n");
            }
            DisplayInput();
            DisplayRes();
        }

        private void FirstOp()
        {
            ReformatCurrNum();

            string num = currentNum.ElementAt(0);
            calc.Add((isNegative ? -1 : 1) * double.Parse(num));
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
    }
}
