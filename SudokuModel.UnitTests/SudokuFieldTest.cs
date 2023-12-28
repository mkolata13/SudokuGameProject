namespace SudokuModel.UnitTests
{
    [TestClass]
    public class SudokuFieldTest
    {
        [TestMethod]
        public void SetSudokuFieldInvalidValueTest()
        {
            SudokuBoard board = new (new BacktrackingSudokuSolver());
            board.SolveGame();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                board.SetFieldValue(1, 1, -5);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                board.SetFieldValue(1, 1, 11);
            });

            try
            {
                board.SetFieldValue(1, 1, -5);
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Value should be between 0-9", exception.Message);
            }
        }
    }
}
