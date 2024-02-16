using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace l1t5
{
    public partial class Form1 : Form
    {
        delegate void del();
        del[] operations;
        del super = () => { };

        Color CustomBackColor = Color.Gray;
        Color SwitchBackColor = Color.Gold;

        public Form1()
        {
            operations = [
                () => Opacity = Opacity == 1 ? .5 : 1,
                () => BackColor = BackColor == CustomBackColor ? SwitchBackColor : CustomBackColor,
                () => MessageBox.Show("world", "hello")
            ];

            InitializeComponent();
        }

        private void b_OpacityChange_Click(object sender, EventArgs e) => operations[0]();
        private void b_BGColorChange_Click(object sender, EventArgs e) => operations[1]();
        private void b_HelloWorld_Click(object sender, EventArgs e) => operations[2]();

        private void b_Super_Click(object sender, EventArgs e) 
        {
            MessageBox.Show("Супермегатекст\nвід супермегакнопки");
            super(); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AddToExecList(checkBox1, 0);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            AddToExecList(checkBox2, 1);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            AddToExecList(checkBox3, 2);
        }

        void AddToExecList(CheckBox check, int idx)
        {
            if (check.Checked) super += operations[idx];
            else super -= operations[idx];
        }
    }
}
