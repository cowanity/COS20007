using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private float _width;
        private float _height;

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public float X { get; set; }
        public float Y { get; set; }

        public MyRectangle(Color _color, float x, float y, int width, int height) : base(_color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {
        }

        public override void Draw()
        {
            if (_selected)
            {
                Drawoutline();
            }
            SplashKit.FillRectangle(_color, X, Y, Width, Height);
        }

        public override void Drawoutline()
        {
            float outlineX = X - 2;
            float outlineY = Y - 2;
            float outlineWidth = Width + 4;
            float outlineHeight = Height + 4;
            SplashKit.DrawRectangle(Color.Black, outlineX, outlineY, outlineWidth, outlineHeight);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.X >= X && pt.X <= X + Width && pt.Y >= Y && pt.Y <= Y + Height;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
