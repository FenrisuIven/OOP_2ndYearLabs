using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace l3t2_VoronoiDiagram.Classes
{
    public class VoronoiDiagram
    {
        private Random _rnd = new();
        
        public Stopwatch DrawTimer;
        public string GetElapsedMilliseconds
        {
            get => DrawTimer.ElapsedMilliseconds + " ms";
        }
        
        public Bitmap BMP;
        public int BMPWidth;
        public int BMPHeight;

        private List<VoronoiPoint> _points = new();
        public int AmountPfRandomPoints = 2;
        
        public void Initialize()
        {
            BMP = new(BMPWidth, BMPHeight);
            DrawTimer = new();
        }


        public void PointAction(VoronoiPoint newPoint)
        {
            var p = _points.Find(elem => Distance(elem, newPoint) <= 5);
            
            if (p != null)
            {
                _points.Remove(p);
            }
            else
            {
                _points.Add(newPoint);
            }
            
            RedrawVertices();
            RequestInvalidation?.Invoke();
        }
        public void GenerateRandomPoints(int amount)
        {
            AmountPfRandomPoints = amount;
            ClearBMP();
            GeneratePoints();
        }

        private void GeneratePoints()
        {
            for (int i = _points.Count; i < AmountPfRandomPoints; i++)
            {
                _points.Add(new VoronoiPoint(_rnd.Next(BMPWidth), _rnd.Next(BMPHeight)));
            }
        }
        private double Distance(VoronoiPoint p1, VoronoiPoint p2)
        {
            int x = p2.X - p1.X;
            int y = p2.Y - p1.Y;
            return Math.Sqrt(x * x + y * y);
        }
        private double Distance(Point p1, VoronoiPoint p2)
        {
            int x = p2.X - p1.X;
            int y = p2.Y - p1.Y;
            return Math.Sqrt(x * x + y * y);
        }
        
        public void DrawVertices()
        {
            var g = Graphics.FromImage(BMP);
            foreach (var point in _points)
            {
                point.DrawPoint(g);
            }
        }
        
        public void DrawSingleThread()
        {
            DrawTimer.Restart();
            using var g = Graphics.FromImage(BMP);
            
            for (int x = 0; x < BMPWidth; x++)
            {
                for (int y = 0; y < BMPHeight; y++)
                {
                    var closestPoint = FindClosestPoint(new Point(x,y));
                    int index = _points.IndexOf(closestPoint);
                    _points[index].DrawPixel(g, x, y);
                }
            }
            DrawTimer.Stop();
            RequestInvalidation?.Invoke();
            RequestTimeLabelUpdate?.Invoke();
        }

        public void DrawMultiThread()
        {
            DrawTimer.Restart();
            var g = Graphics.FromImage(BMP);
            
            int segmentWidth = (int)Math.Ceiling((double)BMPWidth / Environment.ProcessorCount);
            int segmentHeight = BMPHeight;

            List<Task> tasks = new();

            for (int t = 0; t < Environment.ProcessorCount; t++)
            {
                int startX = t * segmentWidth;
                int endX = Math.Min((t + 1) * segmentWidth, BMPWidth);

                tasks.Add(Task.Run(() =>
                {
                    for (int x = startX; x < endX; x++)
                    {
                        for (int y = 0; y < segmentHeight; y++)
                        {
                            var closestPoint = FindClosestPoint(new Point(x, y));
                            int idx = _points.IndexOf(closestPoint);
                            lock (g)
                            {
                                _points[idx].DrawPixel(g, x, y);
                            }
                        }
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            DrawTimer.Stop();
            RequestInvalidation?.Invoke();
            RequestTimeLabelUpdate?.Invoke();
        }

        private VoronoiPoint FindClosestPoint(Point p)
        {
            var closestPoint = _points[0];
            
            double minDistance = Distance(p, closestPoint);

            foreach(var point in _points)
            {
                var distance = Distance(p, point);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }
        
        public void ClearBMP()
        {
            var g = Graphics.FromImage(BMP);
            _points = new();
            g.Clear(Color.White);
            
            DrawTimer.Reset();
            RequestInvalidation?.Invoke();
            RequestTimeLabelUpdate?.Invoke();
        }
        public void RedrawVertices()
        {
            var g = Graphics.FromImage(BMP);
            g.Clear(Color.White);
            DrawVertices();
        }
        
        public delegate void Parameterless();

        public event Parameterless RequestInvalidation;
        public event Parameterless RequestTimeLabelUpdate;
    }
}