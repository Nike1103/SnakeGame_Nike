public class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
    public ConsoleColor Color { get; set; }

    public Cell(int x, int y, char symbol = ' ', ConsoleColor color = ConsoleColor.White)
    {
        X = x;
        Y = y;
        Symbol = symbol;
        Color = color;
    }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y);
        Console.Write(Symbol);
    }

    public bool CollidesWith(Cell other)
    {
        return X == other.X && Y == other.Y;
    }
}