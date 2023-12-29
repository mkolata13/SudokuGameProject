using SudokuModel;

public class App
{
    public static void Main(string[] args)
    {
        SudokuBoard board = new SudokuBoard(new BacktrackingSudokuSolver());
        board.SolveGame();
        board.PrintBoard();
    }
}