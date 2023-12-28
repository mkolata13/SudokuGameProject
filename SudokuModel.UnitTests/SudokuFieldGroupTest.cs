namespace SudokuModel.UnitTests
{
    public class SudokuCheckTest
    {
        [Fact]
        public void VerifyWithInvalidBoardTest()
        {
            SudokuBoard board = new (new BacktrackingSudokuSolver());
            board.SolveGame();

            board.SetFieldValue(0, 0, 1);
            board.SetFieldValue(0, 1, 1);
            board.SetFieldValue(1, 0, 1);

            Assert.False(board.GetRow(0).Verify());
            Assert.False(board.GetColumn(0).Verify());
            Assert.False(board.GetBox(0, 0).Verify());
        }

        [Fact]
        public void VerifyWithValueEqualZero()
        {
            SudokuBoard board = new (new BacktrackingSudokuSolver());
            board.SolveGame();

            board.SetFieldValue(0, 0, 0);
            Assert.True(board.GetBox(0, 0).Verify());
        }
    }
}