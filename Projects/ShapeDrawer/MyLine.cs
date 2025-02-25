using SplashKitSDK;
using System;
using System.Net;
using System.IO;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        public Point2D startpoint { get; set; }
        public Point2D endpoint { get; set; }

        public MyLine(Point2D startPoint, Point2D endPoint, Color _color) : base(_color)
        {
            startpoint = startPoint;
            endpoint = endPoint;
        }

        public MyLine() : this(new Point2D(), new Point2D(), Color.Black)
        {
        }

        public override void Draw()
        {
            if (_selected)
            {
                Drawoutline();
            }
            SplashKit.DrawLine(_color, startpoint.X, startpoint.Y, endpoint.X, endpoint.Y);
            Drawoutline();
        }

        public override void Drawoutline()
        {
            const int outlineRadius = 3;
            SplashKit.FillCircle(Color.Black, startpoint.X, startpoint.Y, outlineRadius);
            SplashKit.FillCircle(Color.Black, endpoint.X, endpoint.Y, outlineRadius);
        }

        public override bool IsAt(Point2D pt)
        {
            const int tolerance = 2;
            Line line = SplashKit.LineFrom(startpoint, endpoint);
            return SplashKit.PointOnLine(pt, line, tolerance);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(startpoint.X);
            writer.WriteLine(startpoint.Y);
            writer.WriteLine(endpoint.X);
            writer.WriteLine(endpoint.Y);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            startpoint = new Point2D
            {
                X = reader.ReadInteger(),
                Y = reader.ReadInteger()
            };
            endpoint = new Point2D
            {
                X = reader.ReadInteger(),
                Y = reader.ReadInteger()
            };
        }
    }
}
