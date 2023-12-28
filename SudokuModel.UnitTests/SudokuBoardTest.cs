namespace SudokuModel.UnitTests
{
    public class SudokuBoardTest
    {
        [Fact]
        public void TwoDifferentBoardTest()
        {
            SudokuBoard board1 = new (new BacktrackingSudokuSolver());
            SudokuBoard board2 = new (new BacktrackingSudokuSolver());
            board1.SolveGame();
            board2.SolveGame();

            bool boardsAreDifferent = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board1.GetFieldValue(i, j) != board2.GetFieldValue(i, j))
                    {
                        boardsAreDifferent = true;
                        break;
                    }
                }
            }

            Assert.True(boardsAreDifferent);
        }
        [Fact]
        public void BoardValidationTest()
        {
            SudokuBoard board = new (new BacktrackingSudokuSolver());
            board.SolveGame();

            bool areRowsValid = true;

            for (int i = 0; i < 9; i++)
            {
                if (!board.GetRow(i).Verify())
                {
                    areRowsValid = false;
                    break;
                }
            }

            bool areColumnsValid = true;

            for (int i = 0; i < 9; i++)
            {
                if (!board.GetColumn(i).Verify())
                {
                    areColumnsValid = false;
                    break;
                }
            }

            bool areBoxesValid = true;

            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    if (!board.GetBox(i, j).Verify())
                    {
                        areBoxesValid = false;
                        break;
                    }
                }
            }

            Assert.True(areRowsValid && areColumnsValid && areBoxesValid);
        }
    }
}