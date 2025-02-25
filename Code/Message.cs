using System;
using SplashKit;

class Program
{
    static void Main()
    {
        // Initialize SplashKit
        SplashKit.Init();

        // Open a white window
        Window mainWindow = new Window("My White Window", 800, 600);
        mainWindow.Clear(Color.White);
        SplashKit.RefreshScreen();

        // Wait for a few seconds (e.g., 5 seconds)
        SplashKit.Delay(5000); // Delay for 5000 milliseconds (5 seconds)

        // Close the window and clean up
        SplashKit.CloseWindow(mainWindow);
        SplashKit.Quit();
    }
}
