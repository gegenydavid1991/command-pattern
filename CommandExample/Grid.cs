using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample
{
    public class Grid
    {
        private Cell[][] cells;

        public int Steps { get; set; }

        public int Size { get { return cells.Count(); } }

        public bool IsFull
        {
            get
            {
                foreach (var row in cells)
                {
                    foreach (var cell in row)
                    {
                        if (cell == Cell.Empty)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool IsEmpty
        {
            get
            {
                foreach (var row in cells)
                {
                    foreach (var cell in row)
                    {
                        if (cell != Cell.Empty)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public Cell this[int i, int j]
        {
            get { return cells[i][j]; }
            set { cells[i][j] = value; }
        }

        public Cell[] this[int i]
        {
            get { return cells[i]; }
        }

        public Grid(int size)
            : this(size, size)
        {

        }

        private Grid(int rows, int columns)
        {
            if (rows != columns)
            {
                throw new ArgumentException("Row count and column count must be the same.");
            }

            cells = new Cell[rows][];

            for (int i = 0; i < rows; i++)
            {
                cells[i] = new Cell[columns];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cells[i][j] = Cell.Empty;
                }
            }
        }

        public Cell CheckForWinner()
        {
            for (int i = 0; i < Size - 4; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (cells[i][j] == Cell.Circle &&
                        cells[i + 1][j] == Cell.Circle &&
                        cells[i + 2][j] == Cell.Circle &&
                        cells[i + 3][j] == Cell.Circle &&
                        cells[i + 4][j] == Cell.Circle
                    )
                    {
                        return Cell.Circle;
                    }

                    if (cells[i][j] == Cell.Cross &&
                        cells[i + 1][j] == Cell.Cross &&
                        cells[i + 2][j] == Cell.Cross &&
                        cells[i + 3][j] == Cell.Cross &&
                        cells[i + 4][j] == Cell.Cross)
                    {
                        return Cell.Cross;
                    }
                }
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size - 4; j++)
                {
                    if (cells[i][j] == Cell.Circle &&
                        cells[i][j + 1] == Cell.Circle &&
                        cells[i][j + 2] == Cell.Circle &&
                        cells[i][j + 3] == Cell.Circle &&
                        cells[i][j + 4] == Cell.Circle
                    )
                    {
                        return Cell.Circle;
                    }

                    if (cells[i][j] == Cell.Cross &&
                        cells[i][j + 1] == Cell.Cross &&
                        cells[i][j + 2] == Cell.Cross &&
                        cells[i][j + 3] == Cell.Cross &&
                        cells[i][j + 4] == Cell.Cross
                        )
                    {
                        return Cell.Cross;
                    }
                }
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    try
                    {
                        if (cells[i][j] == Cell.Cross &&
                            cells[i - 1][j + 1] == Cell.Cross &&
                            cells[i - 2][j + 2] == Cell.Cross &&
                            cells[i - 3][j + 3] == Cell.Cross &&
                            cells[i - 4][j + 4] == Cell.Cross)
                        {
                            return Cell.Cross;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                    try
                    {
                        if (cells[i][j] == Cell.Cross &&
                                        cells[i + 1][j + 1] == Cell.Cross &&
                                        cells[i + 2][j + 2] == Cell.Cross &&
                                        cells[i + 3][j + 3] == Cell.Cross &&
                                        cells[i + 4][j + 4] == Cell.Cross)
                        {
                            return Cell.Cross;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                    try
                    {
                        if (cells[i][j] == Cell.Cross &&
                                            cells[i - 1][j - 1] == Cell.Cross &&
                                            cells[i - 2][j - 2] == Cell.Cross &&
                                            cells[i - 3][j - 3] == Cell.Cross &&
                                            cells[i - 4][j - 4] == Cell.Cross)
                        {
                            return Cell.Cross;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                    try
                    {
                        if (cells[i][j] == Cell.Cross &&
                                            cells[i + 1][j - 1] == Cell.Cross &&
                                            cells[i + 2][j - 2] == Cell.Cross &&
                                            cells[i + 3][j - 3] == Cell.Cross &&
                                            cells[i + 4][j - 4] == Cell.Cross)
                        {
                            return Cell.Cross;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                    try
                    {
                        if (cells[i][j] == Cell.Circle &&
                                            cells[i - 1][j + 1] == Cell.Circle &&
                                            cells[i - 2][j + 2] == Cell.Circle &&
                                            cells[i - 3][j + 3] == Cell.Circle &&
                                            cells[i - 4][j + 4] == Cell.Circle)
                        {
                            return Cell.Circle;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                    try
                    {
                        if (cells[i][j] == Cell.Circle &&
                                            cells[i + 1][j + 1] == Cell.Circle &&
                                            cells[i + 2][j + 2] == Cell.Circle &&
                                            cells[i + 3][j + 3] == Cell.Circle &&
                                            cells[i + 4][j + 4] == Cell.Circle)
                        {
                            return Cell.Circle;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                    try
                    {
                        if (cells[i][j] == Cell.Circle &&
                                            cells[i - 1][j - 1] == Cell.Circle &&
                                            cells[i - 2][j - 2] == Cell.Circle &&
                                            cells[i - 3][j - 3] == Cell.Circle &&
                                            cells[i - 4][j - 4] == Cell.Circle)
                        {
                            return Cell.Circle;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                    try
                    {
                        if (cells[i][j] == Cell.Circle &&
                                            cells[i + 1][j - 1] == Cell.Circle &&
                                            cells[i + 2][j - 2] == Cell.Circle &&
                                            cells[i + 3][j - 3] == Cell.Circle &&
                                            cells[i + 4][j - 4] == Cell.Circle)
                        {
                            return Cell.Circle;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                }
            }

            return Cell.Empty;
        }

        public void Clear()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    cells[i][j] = Cell.Empty;
                }
            }

            Steps = 0;
        }
    }
}
