using System;
using System.Collections.Generic;
using System.Drawing;
using SplashKitSDK;
using static System.Runtime.CompilerServices.RuntimeHelpers;

class Tetris
{
    const int Rows = 20;
    const int Columns = 10;
    const int BlockSize = 30;

    static int[,] grid = new int[Rows, Columns];
    static List<Point2D> currentBlock = new List<Point2D>();

    static void Main()
    {
        SplashKit.OpenWindow("Tetris", Columns * BlockSize, Rows * BlockSize);

        while (!SplashKit.WindowCloseRequested("Tetris"))
        {
            HandleInput();
            Update();
            Draw();

            SplashKit.RefreshScreen();
            SplashKit.Delay(16); // Cap the frame rate
        }

        SplashKit.CloseWindow("Tetris");
    }

    static void HandleInput()
    {
        if (SplashKit.KeyDown(KeyCode.RightKey) && CanMove(1, 0))
        {
            Move(1, 0);
        }
        else if (SplashKit.KeyDown(KeyCode.LeftKey) && CanMove(-1, 0))
        {
            Move(-1, 0);
        }
        else if (SplashKit.KeyTyped(KeyCode.UpKey))
        {
            Rotate();
        }
        else if (SplashKit.KeyDown(KeyCode.DownKey) && CanMove(0, 1))
        {
            Move(0, 1);
        }
    }

    static void Update()
    {
        if (CanMove(0, 1))
        {
            Move(0, 1);
        }
        else
        {
            PlaceBlock();
            CheckForCompletedRows();
            SpawnBlock();
        }
    }

    static void Draw()
    {
        DrawGrid();
        DrawBlock();
    }

    static void DrawGrid()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (grid[row, col] == 1)
                {
                    SplashKit.FillRectangle(SplashKitSDK.Color.Gray, col * BlockSize, row * BlockSize, BlockSize, BlockSize);
                }
            }
        }
    }

    static void DrawBlock()
    {
        foreach (var point in currentBlock)
        {
            SplashKit.FillRectangle(SplashKitSDK.Color.Black, point.X, point.Y, BlockSize, BlockSize);
        }
    }

    static void SpawnBlock()
    {
        currentBlock.Clear();

        // Example: spawning a block at the top center
        int startX = Columns / 2 * BlockSize;
        int startY = 0;

        currentBlock.Add(new Point2D() { X = startX, Y = startY });
        currentBlock.Add(new Point2D() { X = startX + BlockSize, Y = startY });
        currentBlock.Add(new Point2D() { X = startX, Y = startY + BlockSize });
        currentBlock.Add(new Point2D() { X = startX + BlockSize, Y = startY + BlockSize });
    }

    static void Move(int xOffset, int yOffset)
    {
        for (int i = 0; i < currentBlock.Count; i++)
        {
            currentBlock[i] = new Point2D() { X = currentBlock[i].X + xOffset * BlockSize, Y = currentBlock[i].Y + yOffset * BlockSize };
        }
    }

    static void Rotate()
    {
        // Add rotation logic here if needed
    }

    static bool CanMove(int xOffset, int yOffset)
    {
        foreach (var point in currentBlock)
        {
            int col = (int)(point.X / BlockSize) + xOffset;
            int row = (int)(point.Y / BlockSize) + yOffset;

            if (col < 0 || col >= Columns || row >= Rows || (row >= 0 && grid[row, col] == 1))
            {
                return false;
            }
        }

        return true;
    }

    static void PlaceBlock()
    {
        foreach (var point in currentBlock)
        {
            int col = (int)(point.X / BlockSize);
            int row = (int)(point.Y / BlockSize);

            grid[row, col] = 1;
        }
    }

    static void CheckForCompletedRows()
    {
        for (int row = Rows - 1; row >= 0; row--)
        {
            bool isRowComplete = true;

            for (int col = 0; col < Columns; col++)
            {
                if (grid[row, col] == 0)
                {
                    isRowComplete = false;
                    break;
                }
            }

            if (isRowComplete)
            {
                ClearRow(row);
                ShiftRowsDown(row);
            }
        }
    }

    static void ClearRow(int row)
    {
        for (int col = 0; col < Columns; col++)
        {
            grid[row, col] = 0;
        }
    }

    static void ShiftRowsDown(int startRow)
    {
        for (int row = startRow - 1; row >= 0; row--)
        {
            for (int col = 0; col < Columns; col++)
            {
                grid[row + 1, col] = grid[row, col];
            }
        }
    }
}