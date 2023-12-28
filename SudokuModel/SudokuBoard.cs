Console.WriteLine("Working");

namespace SudokuModel
{
    public class SudokuBoard
    {
        private int[][] _board;
        public const int BoardSize = 9;
        private ISudokuSolver _solver;

        public SudokuBoard()
        {
            _board = new int[BoardSize][];
            for (int i = 0; i < BoardSize; i++)
            {
                _board[i] = new int[BoardSize];
            }
            this._solver ??= new BacktrackingSudokuSolver();
        }

        public int GetCell(int row, int col)
        {
            return _board[row][col];
        }

        public void SetCell(int row, int col, int value)
        {
            _board[row][col] = value;
        }

        public void SolveGame()
        {
            _solver.Solve(this);
        }

        private bool IsNumberInRow(SudokuBoard board, int row, int number)
        {
            for (int column = 0; column < BoardSize; column++)
            {
                if (board.GetCell(row, column) == number)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumberInColumn(SudokuBoard board, int column, int number)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                if (board.GetCell(row, column) == number)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumberInBox(SudokuBoard board, int row, int column, int number)
        {
            int rowBoxStart = row - row % 3;
            int columnBoxStart = column - column % 3;
            for (int i = rowBoxStart; i < rowBoxStart + 3; i++)
            {
                for (int j = columnBoxStart; j < columnBoxStart + 3; j++)
                {
                    if (board.GetCell(i, j) == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsValidMove(SudokuBoard board, int row, int column, int number)
        {
            return !board.IsNumberInRow(board, row, number)
                   && !board.IsNumberInColumn(board, column, number)
                   && !board.IsNumberInBox(board, row, column, number);
        }
    }
}