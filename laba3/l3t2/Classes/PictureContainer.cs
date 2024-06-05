using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l3t2
{
    public class PictureContainer
    {
        private Form _form;
        private PictureBox _pictureBox;
        public Bitmap Bmp { get; set; }
        public Graphics Graphics { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public PictureContainer(Form form)
        {
            _form = form;
            Width = form.Width;
            Height = form.Height;
        }
        public void Initialize()
        {
            Bmp = new Bitmap(Width, Height);

            _pictureBox = new PictureBox();
            _pictureBox.Image = Bmp;
            _pictureBox.Size = new Size(Width, Height);
            //_pictureBox.Margin = new Padding(50);

            _form.Controls.Add(_pictureBox);

            Graphics = Graphics.FromImage(Bmp);
        }
        public void Clear()
        {
            _pictureBox.Dispose(); 
        }
    }
}
