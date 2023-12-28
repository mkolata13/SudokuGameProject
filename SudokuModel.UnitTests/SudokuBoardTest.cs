using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SudokuModel.UnitTests
{
    [TestClass]
    public class SudokuBoardTest
    {
        [TestMethod]
        public void TwoDifferentBoardTest()
        {
            SudokuBoard board1 = new();
            SudokuBoard board2 = new();
            board1.SolveGame();
            board2.SolveGame();

            bool boardsAreDifferent = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board1.GetCell(i, j) != board2.GetCell(i, j))
                    {
                        boardsAreDifferent = true;
                        break;
                    }
                }
            }

            Assert.IsTrue(boardsAreDifferent);
        }
        [TestMethod]
        public void BoardValidationTest()
        {
            SudokuBoard board = new();
            board.SolveGame();

            bool areRowsValid = true;
            bool areColumnsValid = true;

            for (int i = 0; i < 9; i++)
            {
                HashSet<int> rowSet = new HashSet<int>();
                HashSet<int> colSet = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    if (rowSet.Contains(board.GetCell(i, j)))
                    {
                        areRowsValid = false;
                        break;
                    }
                    rowSet.Add(board.GetCell(i, j));

                    if (colSet.Contains(board.GetCell(j, i)))
                    {
                        areColumnsValid = false;
                        break;
                    }
                    colSet.Add(board.GetCell(j, i));
                }
            }

            bool areBoxesValid = true;

            for (int i = 0; i < 9; i += 3)
            {
                HashSet<int> boxSet = new HashSet<int>();
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (boxSet.Contains(board.GetCell(row + i, col)))
                        {
                            areBoxesValid = false;
                            break;
                        }
                        boxSet.Add(board.GetCell(row + i, col));
                    }
                }
            }

            Assert.IsTrue(areRowsValid && areColumnsValid && areBoxesValid);
        }
    }
}
