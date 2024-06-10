using System.Drawing;

namespace l3t2_VoronoiDiagram
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearBtn = new System.Windows.Forms.Button();
            this.time_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MultiThread_CheckBox = new System.Windows.Forms.CheckBox();
            this.drawBtn = new System.Windows.Forms.Button();
            this.randomBtn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.clearBtn);
            this.panel1.Controls.Add(this.time_Label);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.MultiThread_CheckBox);
            this.panel1.Controls.Add(this.drawBtn);
            this.panel1.Controls.Add(this.randomBtn);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 46);
            this.panel1.TabIndex = 6;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(597, 12);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 22);
            this.clearBtn.TabIndex = 6;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += OnClear;
            // 
            // time_Label
            // 
            this.time_Label.AutoSize = true;
            this.time_Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.time_Label.Location = new System.Drawing.Point(436, 16);
            this.time_Label.Name = "time_Label";
            this.time_Label.Size = new System.Drawing.Size(29, 13);
            this.time_Label.TabIndex = 5;
            this.time_Label.Text = "0 ms";
            this.time_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time:";
            // 
            // MultiThread_CheckBox
            // 
            this.MultiThread_CheckBox.AutoSize = true;
            this.MultiThread_CheckBox.Location = new System.Drawing.Point(234, 16);
            this.MultiThread_CheckBox.Name = "MultiThread_CheckBox";
            this.MultiThread_CheckBox.Size = new System.Drawing.Size(82, 17);
            this.MultiThread_CheckBox.TabIndex = 3;
            this.MultiThread_CheckBox.Text = "MultiThread";
            this.MultiThread_CheckBox.UseVisualStyleBackColor = true;
            this.MultiThread_CheckBox.CheckedChanged += OnMultiThreadChecked;
            
            // 
            // drawBtn
            // 
            this.drawBtn.Location = new System.Drawing.Point(153, 12);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(75, 22);
            this.drawBtn.TabIndex = 2;
            this.drawBtn.Text = "Draw";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += OnDraw;
            // 
            // randomBtn
            // 
            this.randomBtn.Location = new System.Drawing.Point(73, 12);
            this.randomBtn.Name = "randomBtn";
            this.randomBtn.Size = new System.Drawing.Size(61, 22);
            this.randomBtn.TabIndex = 1;
            this.randomBtn.Text = "Random";
            this.randomBtn.UseVisualStyleBackColor = true;
            this.randomBtn.Click += OnRandomPoints;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 13);
            this.numericUpDown1.Maximum = 1000;
            this.numericUpDown1.Minimum = 2;
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(55, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.Text = "Voronoi Diagram";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnFormPaint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnFormMouseClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.SizeChanged += OnSizeChanged;

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.Button randomBtn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label time_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox MultiThread_CheckBox;
        private System.Windows.Forms.Button clearBtn;
    }
}