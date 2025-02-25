using System.Collections.Generic;
using System.Drawing;
using System.IO;
using SplashKitSDK;
using Color = SplashKitSDK.Color;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White)
        {
        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape shape in _shapes)
                {
                    if (shape.Selected)
                    {
                        result.Add(shape);
                    }
                }
                return result;
            }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
            SplashKit.RefreshScreen();
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsAt(pt))
                {
                    shape.Selected = true;
                }
                else
                {
                    shape.Selected = false;
                }
            }
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                try
                {
                    writer.WriteColor(Background);
                    writer.WriteLine(ShapeCount);
                    foreach (Shape s in _shapes)
                    {
                        s.SaveTo(writer);
                    }
                }
                finally
                {
                    writer.Close();
                }
            }
        }

        public void Load(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                try
                {
                    Background = reader.ReadColor();
                    int count = reader.ReadInteger();
                    _shapes.Clear();

                    for (int i = 0; i < count; i++)
                    {
                        string kind = reader.ReadLine();
                        Shape s = null;
                        switch (kind)
                        {
                            case "Rectangle":
                                s = new MyRectangle();
                                break;
                            case "Circle":
                                s = new MyCircle();
                                break;
                            case "Line":
                                s = new MyLine();
                                break;
                            default:
                                throw new InvalidDataException("Unknown shape kind: " + kind);
                        }
                        s.LoadFrom(reader);
                        _shapes.Add(s);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
        }
    }
}
