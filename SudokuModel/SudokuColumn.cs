using System;

namespace SudokuModel
{
    public class SudokuColumn(SudokuField[] fields) : SudokuCheck(fields)
    {
    }
}