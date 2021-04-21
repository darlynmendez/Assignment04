// Name: Darlyn Mendez
// CSC339 - Spring 2021
// Assignment 4


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connect4
{
    public partial class Form1 : Form
    {
        private Board board;
        public Form1()
        {
            InitializeComponent();

            // Adds the event handler for when the screen is painted
            this.Paint += new PaintEventHandler(pic_board_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Gets called when the main form is loaded
            board = new Board();
        }

        private void connect4MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pic_board_Paint(object sender, PaintEventArgs e)
        {
            // Gets called whenever the screen is painted
            board.DrawBoard(e.Graphics);
        }

        private void Form1_MousClick(object sender, MouseEventArgs e)
        {
            int colsIndex = this.ColsNumber(e.Location);
            if (colsIndex != -1)
            {
                int indexRows = this.EmptyRow(colsIndex);
                if (indexRows != -1)
                {
                    this.board[indexRows, colsIndex] = this.turn;
                    if (this.turn == 1)
                    {
                        Graphics g == this.CreateGraphics();
                        g.FillEllipse(Brushes.Red, 32 + 48 * colsIndex, 32 + 48 * indexRows, 32, 32);
                    }
                    else if (this.turn == 2)
                    {
                        Graphics g = this.CreateGraphics();
                        g.FillEllipse(Brushes.Yellow, 32 + 48 * colsIndex, 32 + 48 * indexRows, 32, 32);
                    }
                }
            }
        }

        private int ColsNumber(Point mouse)
        {
            for (int i = 0; i < this.board.Length; i++)
            {
                if ((mouse.X >= this.board[i].X) && (mouse.Y >= this.board[i].Y))
                {
                    if((mouse.X <= this.board[i].X + this.board[i].Width)&&(mouse.Y <= this.board[i].Y+this.board[i].Height))
                    {
                        return i;
                    }
                }
        }
            return -1;
    }


}
