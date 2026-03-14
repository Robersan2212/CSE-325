namespace ConnectFour;

public enum WinState
{
    None,
    Player1_Wins,
    Player2_Wins,
    Tie
}

/// <summary>
/// Game state kept separate from UI. Injected as singleton.
/// </summary>
public class GameState
{
    public const int Columns = 7;
    public const int Rows = 6;

    // Board[col, row]: 0 = empty, 1 = player 1, 2 = player 2
    private int[,] Board { get; set; } = new int[Columns, Rows];
    private int _turnCount;
    private int _lastCol, _lastRow;
    private readonly List<(int Player, int Column)> _moves = new();

    /// <summary>Current piece index (0–41). Use as index into pieces array.</summary>
    public int CurrentTurn => _turnCount;

    /// <summary>List of moves in the current game (player, column).</summary>
    public IReadOnlyList<(int Player, int Column)> Moves => _moves;

    /// <summary>1 or 2.</summary>
    public int PlayerTurn => (_turnCount % 2) == 0 ? 1 : 2;

    public void ResetBoard()
    {
        Board = new int[Columns, Rows];
        _turnCount = 0;
        _moves.Clear();
    }

    /// <summary>
    /// Play a piece in the given column. Returns the landing row (0–5).
    /// Throws ArgumentException if column is full.
    /// </summary>
    public int PlayPiece(byte col)
    {
        if (col >= Columns)
            throw new ArgumentException("Invalid column.");

        int row = GetLowestEmptyRow(col);
        if (row < 0)
            throw new ArgumentException("Column is full.");

        int player = PlayerTurn;
        Board[col, row] = player;
        _lastCol = col;
        _lastRow = row;
        _moves.Add((player, col));
        _turnCount++;

        return row;
    }

    /// <summary>Returns win state after the last move (or None).</summary>
    public WinState CheckForWin()
    {
        if (_turnCount == 0)
            return WinState.None;

        int player = Board[_lastCol, _lastRow];
        if (CheckWinner(_lastCol, _lastRow))
            return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;

        if (_turnCount >= 42)
            return WinState.Tie;

        return WinState.None;
    }

    private int GetLowestEmptyRow(int col)
    {
        for (int r = Rows - 1; r >= 0; r--)
            if (Board[col, r] == 0)
                return r;
        return -1;
    }

    private bool CheckWinner(int col, int row)
    {
        int player = Board[col, row];
        return CountInDirection(col, row, 1, 0, player) >= 4
            || CountInDirection(col, row, 0, 1, player) >= 4
            || CountInDirection(col, row, 1, 1, player) >= 4
            || CountInDirection(col, row, 1, -1, player) >= 4;
    }

    private int CountInDirection(int col, int row, int dCol, int dRow, int player)
    {
        int count = 0;
        int c = col, r = row;
        while (c >= 0 && c < Columns && r >= 0 && r < Rows && Board[c, r] == player)
        {
            count++;
            c += dCol;
            r += dRow;
        }
        c = col - dCol;
        r = row - dRow;
        while (c >= 0 && c < Columns && r >= 0 && r < Rows && Board[c, r] == player)
        {
            count++;
            c -= dCol;
            r -= dRow;
        }
        return count;
    }
}
