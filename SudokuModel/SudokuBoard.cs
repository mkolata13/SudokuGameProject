namespace SudokuModel
{
    public class SudokuBoard
    {
        private int[][] _board;
        public const int BoardSize = 9;
        private SudokuSolver solver;

        public SudokuBoard()
        {
            _board = new int[BoardSize][];
            for (int i = 0; i < BoardSize; i++)
            {
                _board[i] = new int[BoardSize];
            }
            this.solver ??= new BacktrackingSudokuSolver();
        }

        public int getCell(int row, int col)
        {
            return _board[row][col];
        }

        public void setCell(int row, int col, int value)
        {
            _board[row][col] = value;
        }

        public void solveGame()
        {
            solver.Solve(this);
        }

        private bool isNumberInRow(SudokuBoard board, int row, int number)
        {
            for (int column = 0; column < BoardSize; column++)
            {
                if (board.getCell(row, column) == number)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isNumberInColumn(SudokuBoard board, int column, int number)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                if (board.getCell(row, column) == number)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isNumberInBox(SudokuBoard board, int row, int column, int number)
        {
            int rowBoxStart = row - row % 3;
            int columnBoxStart = column - column % 3;
            for (int i = rowBoxStart; i < rowBoxStart + 3; i++)
            {
                for (int j = columnBoxStart; j < columnBoxStart + 3; j++)
                {
                    if (board.getCell(i, j) == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isValidMove(SudokuBoard board, int row, int column, int number)
        {
            return !board.isNumberInRow(board, row, number)
                   && !board.isNumberInColumn(board, column, number)
                   && !board.isNumberInBox(board, row, column, number);
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("abc");
        }
    }
}