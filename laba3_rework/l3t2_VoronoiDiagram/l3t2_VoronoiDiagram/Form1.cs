using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using l3t2_VoronoiDiagram.Classes;
using Point = System.Drawing.Point;

namespace l3t2_VoronoiDiagram
{
    public partial class Form1 : Form
    {
        private bool _multiThreadMode;

        private VoronoiDiagram localVD;
        
        public Form1()
        {
            InitializeComponent();

            localVD = new()
            {
                BMPWidth = ClientSize.Width,
                BMPHeight = ClientSize.Height
            };
            localVD.Initialize();
            localVD.RequestInvalidation += Invalidate;
            localVD.RequestTimeLabelUpdate += () =>
            {
                time_Label.Text = localVD.GetElapsedMilliseconds;
            };
        }

        private void OnFormPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            localVD.DrawVertices();
            g.DrawImage(localVD.BMP, 0, 0);
        }

        private void OnFormMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var clickedPoint = new VoronoiPoint(e.Location.X, e.Location.Y);
                localVD.PointAction(clickedPoint);
            }
        }
        
        private void OnMultiThreadChecked(object sender, EventArgs e) => 
            _multiThreadMode = MultiThread_CheckBox.Checked;
        
        private void OnDraw(object sender, EventArgs e)
        {
            if (!_multiThreadMode)
            {
                localVD.DrawSingleThread();
            }
            else
            {
                localVD.DrawMultiThread();
            }
        }
        
        private void OnRandomPoints(object sender, EventArgs e)
        {
            int amount = (int)numericUpDown1.Value;
            localVD.GenerateRandomPoints(amount < 2 ? 2 : amount);
        }
        
        private void OnClear(object sender, EventArgs e) => localVD.ClearBMP();

        private void OnSizeChanged(object sender, EventArgs e)
        {
            localVD.BMPHeight = ClientSize.Height;
            localVD.BMPWidth = ClientSize.Width;
            localVD.Initialize();

            panel1.Width = ClientSize.Width + 10;
            Refresh();
        }
    }
}