namespace SudokuModel
{
    public abstract class SudokuCheck
    {
        private SudokuField[] _fields;

        public SudokuCheck(SudokuField[] fields)
        {
            this._fields = new SudokuField[fields.Length];
            Array.Copy(fields, this._fields, fields.Length);
        }   

        public bool Verify()
        {
            bool[] valuesChecked = new bool[10];
            foreach (SudokuField field in _fields)
            {
                int value = field.GetFieldValue();
                if (value != 0)
                {
                    if (valuesChecked[value])
                    {
                        return false;
                    }
                    valuesChecked[value] = true;
                }
            }
            return true;
        }

        public bool Contains(int number)
        {
            foreach (SudokuField field in _fields)
            {
                if (field.GetFieldValue() == number)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
