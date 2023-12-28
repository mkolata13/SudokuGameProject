using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuModel
{
    public class BacktrackingSudokuSolver : ISudokuSolver
    {
        public BacktrackingSudokuSolver()
        {
        }

        public void Solve(SudokuBoard board)
        {
            SolveBoard(board);
        }

        private bool SolveBoard(SudokuBoard board)
        {
            for (int row = 0; row < SudokuBoard.BoardSize; row++)
            {
                for (int column = 0; column < SudokuBoard.BoardSize; column++)
                {
                    if (board.GetFieldValue(row, column) == 0)
                    {
                        List<int> numbers = new List<int>();
                        for (int k = 1; k <= SudokuBoard.BoardSize; k++)
                        {
                            numbers.Add(k);
                        }
                        Shuffle(numbers);
                        foreach (int number in numbers)
                        {
                            if (board.IsValidMove(board, row, column, number))
                            {
                                board.SetFieldValue(row, column, number);
                                if (SolveBoard(board))
                                {
                                    return true;
                                }
                                else
                                {
                                    board.SetFieldValue(row, column, 0);
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }
    }
}

