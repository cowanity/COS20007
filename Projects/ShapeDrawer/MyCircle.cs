using System.Collections.Generic;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float _radius { get; set; }

        public MyCircle(Color _color, float x, float y, float radius) : base(_color)
        {
            X = x;
            Y = y;
            _radius = radius;
        }

        public MyCircle() : this(Color.Blue, 0, 0, 50)
        {
        }

        public override void Draw()
        {
            if (_selected)
            {
                Drawoutline();
            }
            SplashKit.FillCircle(_color, X, Y, _radius);
        }

        public override void Drawoutline()
        {
            float outlineX = X - _radius;
            float outlineY = Y - _radius;
            float outlineDiameter = _radius * 2;
            SplashKit.DrawCircle(Color.Black, X, Y, outlineDiameter);
        }

        public override bool IsAt(Point2D pt)
        {
            double distance = System.Math.Sqrt(System.Math.Pow(pt.X - X, 2) + System.Math.Pow(pt.Y - Y, 2));
            return distance <= _radius;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
