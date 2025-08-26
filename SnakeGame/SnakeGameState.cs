public class SnakeGameState : BaseGameState
{
    public SnakeGameLogic Logic { get; private set; }
    private ConsoleRenderer _renderer;
    private int _width;
    private int _height;

    public SnakeGameState(int width = 40, int height = 20)
    {
        _width = width;
        _height = height;
        _renderer = new ConsoleRenderer(width, height);
        Logic = new SnakeGameLogic(width, height);
    }

    public override void Enter()
    {
        Logic.Reset();
    }

    public override void Update()
    {
        // Обрабатываем ВСЕ доступные клавиши
        while (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            // Обрабатываем только стрелки
            switch (key)
            {
                case ConsoleKey.UpArrow when Logic.CurrentDirection != Direction.Down:
                    Logic.CurrentDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow when Logic.CurrentDirection != Direction.Up:
                    Logic.CurrentDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow when Logic.CurrentDirection != Direction.Right:
                    Logic.CurrentDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow when Logic.CurrentDirection != Direction.Left:
                    Logic.CurrentDirection = Direction.Right;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        Logic.Update();
        Render();
    }

    private void Render()
    {
        _renderer.Clear();
        _renderer.DrawBorder();

        // Рисуем змейку
        foreach (var segment in Logic.Snake)
        {
            _renderer.Draw(segment);
        }

        // Рисуем еду
        _renderer.Draw(Logic.Food);

        // Рисуем счет
        _renderer.DrawText(2, _height, $"Счет: {Logic.Score}/{Logic.FoodToWin}", ConsoleColor.Yellow);
        _renderer.DrawText(20, _height, $"Скорость: {Logic.Speed}", ConsoleColor.Cyan);

        if (Logic.GameOver)
        {
            _renderer.DrawText(_width / 2 - 5, _height / 2, "GAME OVER!", ConsoleColor.Red);
            _renderer.DrawText(_width / 2 - 8, _height / 2 + 1, "Нажмите любую клавишу", ConsoleColor.White);
        }
        else if (Logic.LevelComplete)
        {
            _renderer.DrawText(_width / 2 - 6, _height / 2, "УРОВЕНЬ ПРОЙДЕН!", ConsoleColor.Green);
            _renderer.DrawText(_width / 2 - 8, _height / 2 + 1, "Нажмите любую клавишу", ConsoleColor.White);
        }
    }

    public override void Exit()
    {
        // Очищаем буфер ввода
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
}