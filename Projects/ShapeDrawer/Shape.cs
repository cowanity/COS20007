using System;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        public bool _selected;
        public Color _color { get; set; }
        private float _x, _y;
        private int _width, _height;

        public Shape(Color color)
        {
            _color = color;
        }

        public Shape() : this(Color.Yellow) { }

        public abstract bool IsAt(Point2D pt);

        public void ChangeColor()
        {
            _color = SplashKit.RandomRGBColor(255);
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public abstract void Draw();
        public abstract void Drawoutline();
        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }
        public virtual void LoadFrom(StreamReader reader)
        {
            _color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
