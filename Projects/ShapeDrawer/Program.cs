using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line,
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = null;
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newCircle.X = SplashKit.MouseX();
                        newCircle.Y = SplashKit.MouseY();
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newRect.X = SplashKit.MouseX();
                        newRect.Y = SplashKit.MouseY();
                        newShape = newRect;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();
                        newLine.startpoint = new Point2D()
                        {
                            X = SplashKit.MouseX(),
                            Y = SplashKit.MouseY()
                        };
                        newShape = newLine;
                    }

                    if (newShape != null)
                    {
                        drawing.AddShape(newShape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    float x = SplashKit.MouseX();
                    float y = SplashKit.MouseY();
                    Point2D mouseposition = new Point2D()
                    {
                        X = x,
                        Y = y
                    };
                    drawing.SelectShapeAt(mouseposition);
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.Save("/Users/vufanity/Desktop/TestDrawing.txt");
                    Console.WriteLine("File saved at /Users/vufanity/Desktop/TestDrawing.txt");
                }
                drawing.Draw();
                SplashKit.RefreshScreen();

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("/Users/vufanity/Desktop/TestDrawing.txt");
                        Console.WriteLine("File loaded from /Users/vufanity/Desktop/TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                drawing.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}