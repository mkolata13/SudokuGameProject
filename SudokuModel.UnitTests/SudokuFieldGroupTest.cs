using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SudokuModel.UnitTests 
{
    [TestClass]
    public class SudokuCheckTest
    {
        [TestMethod]
        public void VerifyWithInvalidBoardTest()
        {
            SudokuBoard board = new (new BacktrackingSudokuSolver());
            board.SolveGame();

            board.SetFieldValue(0, 0, 1);
            board.SetFieldValue(0, 1, 1);
            board.SetFieldValue(1, 0, 1);

            Assert.IsFalse(board.GetRow(0).Verify());
            Assert.IsFalse(board.GetColumn(0).Verify());
            Assert.IsFalse(board.GetBox(0, 0).Verify());
        }

        [TestMethod]
        public void VerifyWithValueEqualZero()
        {
            SudokuBoard board = new (new BacktrackingSudokuSolver());
            board.SolveGame();

            board.SetFieldValue(0, 0, 0);
            Assert.IsTrue(board.GetBox(0, 0).Verify());
        }
    }
}