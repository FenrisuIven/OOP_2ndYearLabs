namespace l1t5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            b_OpacityChange = new Button();
            b_BGColorChange = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            b_HelloWorld = new Button();
            b_Super = new Button();
            SuspendLayout();
            // 
            // b_OpacityChange
            // 
            b_OpacityChange.Location = new Point(12, 12);
            b_OpacityChange.Name = "b_OpacityChange";
            b_OpacityChange.Size = new Size(86, 23);
            b_OpacityChange.TabIndex = 0;
            b_OpacityChange.Text = "Прозорість";
            b_OpacityChange.UseVisualStyleBackColor = true;
            b_OpacityChange.Click += b_OpacityChange_Click;
            // 
            // b_BGColorChange
            // 
            b_BGColorChange.Location = new Point(104, 12);
            b_BGColorChange.Name = "b_BGColorChange";
            b_BGColorChange.Size = new Size(86, 23);
            b_BGColorChange.TabIndex = 1;
            b_BGColorChange.Text = "Колір фону";
            b_BGColorChange.UseVisualStyleBackColor = true;
            b_BGColorChange.Click += b_BGColorChange_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 88);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(170, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "також змінити Прозорість";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(12, 113);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(171, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "також змінити Колір фону";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(12, 138);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(181, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "також вивести \"Hello World\"";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // b_HelloWorld
            // 
            b_HelloWorld.Location = new Point(196, 12);
            b_HelloWorld.Name = "b_HelloWorld";
            b_HelloWorld.Size = new Size(86, 23);
            b_HelloWorld.TabIndex = 7;
            b_HelloWorld.Text = "Hello World";
            b_HelloWorld.UseVisualStyleBackColor = true;
            b_HelloWorld.Click += b_HelloWorld_Click;
            // 
            // b_Super
            // 
            b_Super.Location = new Point(12, 50);
            b_Super.Name = "b_Super";
            b_Super.Size = new Size(270, 23);
            b_Super.TabIndex = 8;
            b_Super.Text = "супермегакнопка";
            b_Super.UseVisualStyleBackColor = true;
            b_Super.Click += b_Super_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(334, 311);
            Controls.Add(b_Super);
            Controls.Add(b_HelloWorld);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(b_BGColorChange);
            Controls.Add(b_OpacityChange);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button b_OpacityChange;
        private Button b_BGColorChange;
        private Button b_Super;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Button b_HelloWorld;
    }
}
