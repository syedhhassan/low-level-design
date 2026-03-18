class Board
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly Symbol?[,] _cells;

    public Board(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        _cells = new Symbol?[rows, columns];
    }

    public void PlaceSymbol(int row, int col, Symbol symbol){
        if (row < 0 || row >= _rows) 
            throw new ArgumentOutOfRangeException(nameof(row));
        if (col < 0 || col >= _columns) 
            throw new ArgumentOutOfRangeException(nameof(col));
        if (GetCell(row, col) != null) 
            throw new InvalidOperationException("Cell is already occupied.");
        _cells[row, col] = symbol;
    }

    public Symbol? GetCell(int row, int col)
    {
        if (row < 0 || row >= _rows)
            throw new ArgumentOutOfRangeException(nameof(row));
        if (col < 0 || col >= _columns)
            throw new ArgumentOutOfRangeException(nameof(col));
        return _cells[row, col];
    }
    
    public int Rows => _rows;
    public int Columns => _columns;
}

