using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l3t2
{
    public partial class Form1 : Form
    {
        private PictureContainer _pictureContainer;
        private VoronoiDiagram _voronoiDiagram;
        public Form1()
        {
            InitializeComponent();
            _pictureContainer = new PictureContainer(this);
            _pictureContainer.Initialize();

            _voronoiDiagram = new VoronoiDiagram(_pictureContainer);
            _voronoiDiagram.GeneratePoints(10);

            _voronoiDiagram.DrawPoints();
            _voronoiDiagram.DrawDiagram();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _pictureContainer.Clear(); 
            _voronoiDiagram.GeneratePoints(10);
            _voronoiDiagram.DrawPoints();
        }
    }
}
