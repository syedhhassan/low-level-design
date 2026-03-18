class Game
{
    private readonly Board _board;
    private readonly Player _player1;
    private readonly Player _player2;
    private GameState _gameState;
    private Symbol _currentTurn = Symbol.X;
    private int _movesPlayed = 0;

    public Game(Player player1, Player player2, int rows, int cols)
    {
        _board = new Board(rows, cols);
        _player1 = player1;
        _player2 = player2;
        _gameState = GameState.InProgress;
    }

    public MoveResult Play(int row, int col)
    {
        if (_gameState != GameState.InProgress)
            return new MoveResult{ IsValid = false, Message = "Game is already over." };

        try
        {
            _board.PlaceSymbol(row, col, _currentTurn);
        }
        catch (InvalidOperationException e)
        {
            return new MoveResult{ IsValid = false, Message = e.Message };
        }
        _movesPlayed++;

        var winner = CheckWinner();
        if (winner != null)
        {
            _gameState = GameState.Won;
            return new MoveResult{IsValid = true, Message = $"Player {winner.Value} wins!"};
        }
        if (CheckDraw())    
        {
            _gameState = GameState.Draw;
            return new MoveResult{IsValid = true, Message = "Draw!"};
        }

        SwitchTurn();
        return new MoveResult{IsValid = true, Message = $"Player {_currentTurn} moves to ({row}, {col})"};
    }

    private void SwitchTurn()
    {
        _currentTurn = _currentTurn == Symbol.X ? Symbol.O : Symbol.X;
    }

    private bool CheckDraw() => _movesPlayed == _board.Rows * _board.Columns && CheckWinner() == null;

    private Symbol? CheckWinner() => CheckRows() ?? CheckCols() ?? CheckMainDiagonal() ?? CheckAntiDiagonal();

    private Symbol? CheckRows()
    {
        for (int i = 0; i < _board.Rows; i++)
        {
            var first = _board.GetCell(i, 0);
            if (first == null) continue;

            bool isWinningRow = true;
            for (int j = 1; j < _board.Columns; j++)
            {
                if (_board.GetCell(i, j) != first) { isWinningRow = false; break; }
            }
            if (isWinningRow) return first;
        }
        return null;
    }

    private Symbol? CheckCols()
    {
        for (int i = 0; i < _board.Columns; i++)
        {
            var first = _board.GetCell(0, i);
            if (first == null) continue;

            bool isWinningCol = true;
            for (int j = 1; j < _board.Rows; j++)
            {
                if (_board.GetCell(j, i) != first) { isWinningCol = false; break; }
            }
            if (isWinningCol) return first;
        }
        return null;
    }
    
    private Symbol? CheckMainDiagonal()
    {
        Symbol? first = null;
        bool isWinning = true;
        var n = _board.Rows;
        for (int i = 0; i < n; i++)
        {
            first = i == 0 ? _board.GetCell(i, i) : first;
            if (first == null) return null;
            if (_board.GetCell(i, i) != first) { isWinning = false; break; }
        }
        return isWinning ? first : null;
    }

    private Symbol? CheckAntiDiagonal()
    {
        Symbol? first = null;
        bool isWinning = true;
        var n = _board.Rows;
        for (int i = 0; i < n; i++)
        {
            first = i == 0 ? _board.GetCell(i, n - i - 1) : first;
            if (first == null) return null;
            if (_board.GetCell(i, n - i - 1) != first) { isWinning = false; break; }
        }
        return isWinning ? first : null;
    }
}