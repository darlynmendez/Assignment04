using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Form;

namespace connect4
{
    enum Player
    {
        EMPTY, RED, YELLOW
    }
    class Board
    {
        private const int rows = 6;
        private const int cols = 7;
        private Player[,] board = new Player[rows, cols];
    }

    public Board()
    {
        // constructor
        ResetBoard();
    }

    public void ResetBoard()
    {
        // reset the game board to empty
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                board[i, j] = Player.EMPTY;
            }
        }
    }

    public void DrawBoard(Graphics g)
    {
        int start = 50; // board top left corner offset

        g.FillRectangle(Brushes.Navy, start, start, 700, 600);

        // draw the board columns
        for (int i = 100; i <= 600; i = i + 100)
            g.DrawLine(Pens.White, start + i, start, start + i, start + 600);

        // draw the board rows
        for (int i = 100; i <= 500; i = i + 100)
            g.DrawLine(Pens.White, start, start + i, start + 700, start + i);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (Board[i,j] == Player.RED)
                {
                    g.FillEllipse(Brushes.Red, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                }
                else if (Board[i, j] == Player.YELLOW)
                {
                    g.FillEllipse(Brushes.Yellow, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                }
                else
                {
                    g.FillEllipse(Brushes.White, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                }
            }
        }
    }
}

