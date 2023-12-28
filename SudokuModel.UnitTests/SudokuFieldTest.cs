namespace SudokuModel.UnitTests
{
    public class SudokuFieldTest
    {
        [Fact]
        public void SetSudokuFieldInvalidValueTest()
        {
            SudokuBoard board = new(new BacktrackingSudokuSolver());
            board.SolveGame();

            Assert.Throws<ArgumentException>(() =>
            {
                board.SetFieldValue(1, 1, -5);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                board.SetFieldValue(1, 1, 11);
            });

            try
            {
                board.SetFieldValue(1, 1, -5);
            }
            catch (ArgumentException exception)
            {
                Assert.Equal("Value should be between 0-9", exception.Message);
            }
        }
    }
}