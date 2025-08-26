public class ConsoleRenderer
{
    private int _width;
    private int _height;

    public ConsoleRenderer(int width, int height)
    {
        _width = width;
        _height = height;
        Console.CursorVisible = false;

        try
        {
            Console.SetWindowSize(width + 1, height + 2);
            Console.SetBufferSize(width + 1, height + 2);
        }
        catch
        {
            // Игнорируем ошибки изменения размера консоли
        }
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void DrawBorder()
    {
        Console.ForegroundColor = ConsoleColor.White;

        // Верхняя и нижняя границы
        for (int x = 1; x < _width - 1; x++)
        {
            Console.SetCursorPosition(x, 1);
            Console.Write('─');
            Console.SetCursorPosition(x, _height - 1);
            Console.Write('─');
        }

        // Левая и правая границы
        for (int y = 1; y < _height - 1; y++)
        {
            Console.SetCursorPosition(1, y);
            Console.Write('│');
            Console.SetCursorPosition(_width - 1, y);
            Console.Write('│');
        }

        // Углы
        Console.SetCursorPosition(1, 1);
        Console.Write('┌');
        Console.SetCursorPosition(_width - 1, 1);
        Console.Write('┐');
        Console.SetCursorPosition(1, _height - 1);
        Console.Write('└');
        Console.SetCursorPosition(_width - 1, _height - 1);
        Console.Write('┘');
    }

    public void Draw(Cell cell)
    {
        if (cell.X >= 0 && cell.X < _width && cell.Y >= 0 && cell.Y < _height)
        {
            Console.ForegroundColor = cell.Color;
            Console.SetCursorPosition(cell.X, cell.Y);
            Console.Write(cell.Symbol);
        }
    }

    public void DrawText(int x, int y, string text, ConsoleColor color = ConsoleColor.White)
    {
        if (x >= 0 && x < _width && y >= 0 && y < _height)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}