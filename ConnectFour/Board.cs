namespace ConnectFour;

public class Board
{
    public const char PLAYER_1 = 'x';
    public const char PLAYER_2 = 'o';
    public const char EMPTY = '_';
    private const int ROWS = 6;
    private const int COLS = 7;
    private const int CONNECT_HOW_MANY = 4;

    public Board()
    {
        fields = new char[ROWS][];
        for (var r = 0; r < fields.Length; r++)
        {
            fields[r] = new char[COLS];
            for (var c = 0; c < fields[r].Length; c++)
            {
                fields[r][c] = EMPTY;
            }
        }
    }
    private char[][] fields;

    public void Output()
    {
        for (var c = 0; c < fields[0].Length; c++)
        {
            Console.Write($"{c} ");
        }
        Console.WriteLine();
        for (var r = 0; r < fields.Length; r++)
        {
            for (var c = 0; c < fields[r].Length; c++)
            {
                Console.Write($"{fields[r][c]} ");
            }
            Console.WriteLine();
        }
    }

    public int MakeMove(char player, int column)
    {
        for (var r = fields.Length - 1; r >= 0; r--)
        {
            if (fields[r][column] == EMPTY)
            {
                fields[r][column] = player;
                return r;
            }
        }
        return -1;
    }

    public char Winner(char player, int row, int col)
    {
        var horizontal = HorizontalWinner(player, row);
        if (horizontal != EMPTY)
        {
            return horizontal;
        }
        var vertical = VerticalWinner(player, col);
        if (vertical != EMPTY)
        {
            return vertical;
        }
        var diagonal = DiagonalWinner(player, row, col);
        if (diagonal != EMPTY)
        {
            return diagonal;
        }
        return EMPTY;
    }

    private char HorizontalWinner(char player, int r)
    {
        char[] row = GetRow(r);
        var line = new string(row);
        var win = new string(player, CONNECT_HOW_MANY);
        if (line.Contains(win))
        {
            return player;
        }
        return EMPTY;
    }
    private char VerticalWinner(char player, int c)
    {
        char[] col = GetCol(c);
        var line = new string(col);
        var win = new string(player, CONNECT_HOW_MANY);
        if (line.Contains(win))
        {
            return player;
        }
        return EMPTY;
    }

    private char DiagonalWinner(char player, int r, int c)
    {
        var diagonals = GetDiagonals(r, c);
        return HasWinningSequence(diagonals[0], player) || HasWinningSequence(diagonals[1], player)
            ? player
            : EMPTY;
    }

    private bool HasWinningSequence(char[] diagonal, char player)
    {
        int count = 0;
        foreach (var cell in diagonal)
        {
            if (cell == player)
            {
                count++;
                if (count == CONNECT_HOW_MANY)
                {
                    return true;
                }
            }
            else
            {
                count = 0;
            }
        }
        return false;
    }


    private char[] GetRow(int r)
    {
        var row = new char[COLS];
        for (int i = 0; i < COLS; i++)
        {
            row[i] = fields[r][i];
        }
        return row;
    }

    private char[] GetCol(int c)
    {
        var col = new char[ROWS];
        for (int i = 0; i < ROWS; i++)
        {
            col[i] = fields[i][c];
        }
        return col;
    }

    private char[][] GetDiagonals(int r, int c)
    {
        var raising = new List<char>();
        var falling = new List<char>();

        int i = r, j = c;
        while (i >= 0 && j >= 0)
        {
            i--; j--;
        }
        i++; j++;
        while (i < ROWS && j < COLS)
        {
            raising.Add(fields[i][j]);
            i++; j++;
        }

        i = r; j = c;
        while (i < ROWS && j >= 0)
        {
            i++; j--;
        }
        i--; j++;
        while (i >= 0 && j < COLS)
        {
            falling.Add(fields[i][j]);
            i--; j++;
        }

        return new char[][] { raising.ToArray(), falling.ToArray() };
    }

}
