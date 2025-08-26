public class SnakeGameLogic
{
    public List<Cell> Snake { get; private set; }
    public Cell Food { get; private set; }
    public Direction CurrentDirection { get; set; }
    public bool GameOver { get; private set; }
    public bool LevelComplete { get; private set; }
    public int Score { get; private set; }
    public int FoodToWin { get; private set; }
    public int Speed { get; private set; }

    private int _width;
    private int _height;
    private Random _random;
    private int _updateCounter;
    private int _updatesPerMove;

    public SnakeGameLogic(int width, int height, int foodToWin = 5, int initialSpeed = 5)
    {
        _width = width;
        _height = height;
        _random = new Random();
        FoodToWin = foodToWin;
        Speed = initialSpeed;
        _updatesPerMove = 10 - Speed; // Меньше значение = быстрее движение

        InitializeGame();
    }

    private void InitializeGame()
    {
        Snake = new List<Cell>
        {
            new Cell(_width / 2, _height / 2, '■', ConsoleColor.Green)
        };

        CurrentDirection = Direction.Right;
        GameOver = false;
        LevelComplete = false;
        Score = 0;
        SpawnFood();
    }

    public void Update()
    {
        if (GameOver || LevelComplete) return;

        _updateCounter++;

        // Двигаем змейку только каждый N-ный кадр
        if (_updateCounter >= _updatesPerMove)
        {
            _updateCounter = 0;
            MoveSnake();
            CheckCollisions();
        }
    }

    private void MoveSnake()
    {
        // Сохраняем текущую позицию головы
        var head = Snake[0];
        int newX = head.X;
        int newY = head.Y;

        // Вычисляем новую позицию головы
        switch (CurrentDirection)
        {
            case Direction.Up: newY--; break;
            case Direction.Down: newY++; break;
            case Direction.Left: newX--; break;
            case Direction.Right: newX++; break;
        }

        // Создаем новую голову
        var newHead = new Cell(newX, newY, '■', ConsoleColor.Green);

        // Добавляем новую голову в начало
        Snake.Insert(0, newHead);

        // Если не съели еду, удаляем хвост
        if (!newHead.CollidesWith(Food))
        {
            Snake.RemoveAt(Snake.Count - 1);
        }
        else
        {
            // Съели еду
            Score++;
            if (Score >= FoodToWin)
            {
                LevelComplete = true;
            }
            else
            {
                SpawnFood();
                // Увеличиваем скорость
                if (Speed < 8) Speed++;
                _updatesPerMove = Math.Max(2, 10 - Speed);
            }
        }
    }

    private void SpawnFood()
    {
        int x, y;
        bool validPosition;

        do
        {
            x = _random.Next(2, _width - 2);
            y = _random.Next(2, _height - 2);
            validPosition = true;

            // Проверяем, чтобы еда не появилась на змейке
            foreach (var segment in Snake)
            {
                if (segment.X == x && segment.Y == y)
                {
                    validPosition = false;
                    break;
                }
            }
        } while (!validPosition);

        Food = new Cell(x, y, '♥', ConsoleColor.Red);
    }

    private void CheckCollisions()
    {
        var head = Snake[0];

        // Столкновение со стеной
        if (head.X <= 1 || head.X >= _width - 1 || head.Y <= 1 || head.Y >= _height - 1)
        {
            GameOver = true;
            return;
        }

        // Столкновение с собой (кроме головы и сразу следующего сегмента)
        for (int i = 1; i < Snake.Count; i++)
        {
            if (head.CollidesWith(Snake[i]))
            {
                GameOver = true;
                return;
            }
        }
    }

    public void Reset()
    {
        InitializeGame();
    }
}