using System;

namespace SudokuModel
{
    public class SudokuField
    {
        private int _value;

        public SudokuField()
        {
        }

        public int GetFieldValue()
        {
            return _value;
        }

        public void SetFieldValue(int value)
        {
            if (value < 0 || value > 9)
            {
                throw new ArgumentException("Value should be between 0-9");
            }

            this._value = value;
        }
    }
}

