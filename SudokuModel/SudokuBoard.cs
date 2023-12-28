Console.WriteLine("Working");

namespace SudokuModel
{
    public class SudokuBoard
    {
        private SudokuField[,] _board;
        public const int BoardSize = 9;
        private ISudokuSolver _solver;

        public SudokuBoard(ISudokuSolver solver)
        {
            _board = new SudokuField[BoardSize, BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    this._board[i, j] = new SudokuField();
                }
            }

            this._solver = solver ?? throw new ArgumentNullException(nameof(solver));
        }

        public int GetCell(int row, int col)
        {
            return _board[row, col].GetFieldValue();
        }

        public void SetCell(int row, int col, int value)
        {
            _board[row, col].SetFieldValue(value);
        }

        public void SolveGame()
        {
            _solver.Solve(this);
        }

        public SudokuRow GetRow(int y)
        {
            SudokuField[] row = new SudokuField[BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                row[i] = _board[y, i];
            }
            return new SudokuRow(row);
        }

        public SudokuColumn GetColumn(int x)
        {
            SudokuField[] column = new SudokuField[BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                column[i] = _board[i, x];
            }
            return new SudokuColumn(column);
        }

        public SudokuBox GetBox(int x, int y)
        {
            SudokuField[] box = new SudokuField[BoardSize];
            int rowBoxStart = y - y % 3;
            int columnBoxStart = x - x % 3;
            int index = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box[index] = _board[i + columnBoxStart, j + rowBoxStart];
                    index++;
                }
            }

            return new SudokuBox(box);
        }


        public bool IsValidMove(SudokuBoard board, int row, int column, int number)
        {
            return !board.GetRow(row).Contains(number)
                   && !board.GetColumn(column).Contains(number)
                   && !board.GetBox(row, column).Contains(number);
        }
    }
}