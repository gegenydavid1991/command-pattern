using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandExample
{
    public partial class CommandForm : Form
    {
        private Grid grid = new Grid(20);

        private int steps = 0;

        public int CellWidth { get { return canvas.Width / grid.Size; } }
        public int CellHeight { get { return canvas.Height / grid.Size; } }

        public CommandForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 1; i <= canvas.Height / 20; i++)
            {
                g.DrawLine(
                    new Pen(Color.Black, 2),
                    0,
                    i * CellHeight,
                    canvas.Width,
                    i * CellHeight
                );

                g.DrawLine(
                    new Pen(Color.Black, 2),
                    i * CellWidth,
                    0,
                    i * CellWidth,
                    canvas.Height
                );
            }


            for (int i = 0; i < grid.Size; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    if (grid[i][j] == Cell.Circle)
                    {
                        g.DrawEllipse(
                            new Pen(Color.Blue, 2),
                            j * CellWidth,
                            i * CellHeight,
                            CellWidth,
                            CellHeight
                        );
                    }

                    if (grid[i][j] == Cell.Cross)
                    {
                        g.DrawLine(
                            new Pen(Color.Red, 2),
                            j * CellWidth,
                            i * CellHeight,
                            (j + 1) * CellWidth,
                            (i + 1) * CellHeight
                        );

                        g.DrawLine(
                            new Pen(Color.Red, 2),
                            j * CellWidth,
                            (i + 1) * CellHeight,
                            (j + 1) * CellWidth,
                            i * CellHeight
                        );
                    }
                }
            }

            //canvas.Refresh();
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            int i = e.Y / CellHeight;
            int j = e.X / CellWidth;

            if (i >= grid.Size || j >= grid.Size)
            {
                return;
            }

            if (grid[i][j] == Cell.Empty)
            {
                if (steps % 2 == 0)
                {
                    // X lép
                }
                else
                {
                    // O lép
                }

                steps++;
            }

            canvas.Refresh();

            Cell winner = grid.CheckForWinner();

            if (winner != Cell.Empty)
            {
                MessageBox.Show(this, "The winner is " + (winner == Cell.Circle ? "O." : "X."), "Message");
                grid.Clear();
                steps = 0;
                canvas.Refresh();
                return;
            }

            if (grid.IsFull)
            {
                MessageBox.Show(this, "The grid is full.", "Message");
                grid.Clear();
                steps = 0;
                canvas.Refresh();
                return;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid.Clear();
            steps = 0;
            canvas.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TicTacToeForm_Resize(object sender, EventArgs e)
        {
            canvas.Refresh();
        }

        private void CommandForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {
                undoToolStripMenuItem_Click(sender, e);
                return;
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Y)
            {
                redoToolStripMenuItem_Click(sender, e);
                return;
            }

        }
    }
}
