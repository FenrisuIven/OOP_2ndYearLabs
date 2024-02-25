using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l1t5
{
    public partial class Form1 : Form
    {
        Action superExecList = () => { };

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => AddToExecList(checkBox1, 0);
        private void checkBox2_CheckedChanged(object sender, EventArgs e) => AddToExecList(checkBox2, 1);
        private void checkBox3_CheckedChanged(object sender, EventArgs e) => AddToExecList(checkBox3, 2);

        void AddToExecList(CheckBox check, int idx)
        {
            if (check.Checked) superExecList += operations[idx];
            else superExecList -= operations[idx];
        }
    }
}
