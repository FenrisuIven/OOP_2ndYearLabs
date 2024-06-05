using Accessibility;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l3t2
{
    public class VoronoiDiagram
    {
        private PictureContainer _pictureContainer;
        private List<Point> _points = new List<Point>();
        private Bitmap _bmp;

        public VoronoiDiagram(PictureContainer pictureContainer)
        {
            _pictureContainer = pictureContainer;
            _bmp = _pictureContainer.Bmp;
        }

        public void DrawDiagram(int flag)
        {
            for (int x = 0; x < _pictureContainer.Width; x++)
            {
                for (int y = 0; y < _pictureContainer.Height; y++)
                {
                    Point px = new Point(x, y);

                    var nearestPoint = Pixel.FindClosestPoint(px, _points);

                    Pixel.Draw(px, new SolidBrush(nearestPoint.AssociatedColor), Graphics.FromImage(_bmp));
                }
            }
        }
                
        public void DrawDiagram()
        {
            _bmp.Save($"b4.png");

            List<Bitmap> parts = new List<Bitmap>();
            List<int[,]> positions = new List<int[,]>();

            int sectorWidth = _pictureContainer.Width / 4;
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 4; i++)
            {
                int startSectorX = i * sectorWidth;
                int endSectorX = (i + 1) * sectorWidth;
                var part = _bmp.Clone(new Rectangle(startSectorX, 0, sectorWidth, _pictureContainer.Height), _bmp.PixelFormat);
                parts.Add(part);
                positions.Add(new[,] { { startSectorX, endSectorX } });

                tasks.Add(Task.Run(() => ProcessMultiThreadDrawing(part, startSectorX, endSectorX, sectorWidth)));
            }

            for (int i = 0; i < parts.Count; i++)
            {
                parts[i].Save($"part_{i}.png");
            }

            using (Graphics g = Graphics.FromImage(_bmp)) // <--
            {                                             // _bmp - image to edit
                for (int i = 0; i < parts.Count; i++)
                {
                    var rawPosition = positions[i];
                    PointF position = new PointF(rawPosition[0,0], rawPosition[0,1]);
                    g.DrawImage(parts[i], position);      // <--
                    parts[i].Save($"part_{i}.png");
                }
            }

            _bmp.Save("test1111.png");

            /*var bitmapData = _bmp.LockBits(new Rectangle(0, 0, _pictureContainer.Width, _pictureContainer.Height), ImageLockMode.ReadWrite,
                _bmp.PixelFormat);
            var depth = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
            int sectorWidth = _pictureContainer.Width / 5;

            byte[] buffer = new byte[bitmapData.Width * bitmapData.Height * depth];
            Marshal.Copy(bitmapData.Scan0, buffer, 0, buffer.Length);

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 5; i++)
            {
                int startSectorX = i * sectorWidth;
                int endSectorX = (i + 1) * sectorWidth;

                tasks.Add(Task.Run(() => ProcessMultiThreadDrawing(buffer, startSectorX, endSectorX, depth)));
            }

            Marshal.Copy(buffer, 0, bitmapData.Scan0, buffer.Length);
            _bmp.UnlockBits(bitmapData);

            _bmp.Save("test1111.png");*/
        }
        private void ProcessMultiThreadDrawing(Bitmap buffer, int startX, int endX, int sectorWidth)
        {
            /*for (int i = startX, X = 0; i < endX - sectorWidth; i++, X++)
            {
                for (int j = 0, Y = 0; j < _pictureContainer.Height; j++, Y++)
                {
                    Point px = new Point(i, j);

                    var nearestPoint = Pixel.FindClosestPoint(px, _points);

                    buffer.SetPixel(X, Y, Color.Red);
                }   
            }*/

            for (int x = 0, X = 0; x < endX; x++, X++)
            {
                for (int y = 0, Y = 0; y < _pictureContainer.Height; y++, Y++)
                {
                    Point px = new Point(x, y);

                    var nearestPoint = Pixel.FindClosestPoint(px, _points);

                    buffer.SetPixel(X, Y, Color.Red);
                }
            }
            //buffer.Save("rawPart");
        }
        /*private void ProcessMultiThreadDrawing(Color[,] buffer, int startX, int endX)
        {
            for (int i = startX; i < endX; i++)
            {
                for (int j = 0; j < _pictureContainer.Height; j++)
                {
                    Point px = new Point(i, j);

                    var nearestPoint = Pixel.FindClosestPoint(px, _points);

                    buffer[i, j] = nearestPoint.AssociatedColor;
                }
            }
        }*/

        public void GeneratePoints(int amount)
        {
            var rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int x = rnd.Next(50, _pictureContainer.Width - 50);
                int y = rnd.Next(50, _pictureContainer.Height - 50);
                _points.Add(new Point(x, y));
            }

        }
        public void DrawPoints()
        {
            
            foreach (var point in _points)
            {
                point.DrawPoint(_pictureContainer.Graphics);
            }
        }
    }
}
