using System;
using Shared; // подключаем ConsoleRenderer из папки Shared

namespace SnakeGame
{
    public class SnakeGameState : GameState
    {
        private int x = 10;
        private int y = 10;
        private InputHandler inputHandler;
        private ConsoleRenderer renderer;

        public SnakeGameState()
        {
            inputHandler = new InputHandler(Direction.Right);

            // создаём рендерер, передаём палитру цветов
            renderer = new ConsoleRenderer(new ConsoleColor[]
            {
                ConsoleColor.White,   // индекс 0
                ConsoleColor.Green,   // индекс 1
                ConsoleColor.Red,     // индекс 2
                ConsoleColor.Yellow   // индекс 3
            });

            renderer.bgColor = ConsoleColor.Black;
        }

        public override void Update()
        {
            inputHandler.UpdateDirection();

            switch (inputHandler.CurrentDirection)
            {
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
            }
        }

        public override void Render()
        {
            renderer.Clear();

            // рисуем голову змейки (белый квадрат "■")
            renderer.SetPixel(x, y, '■', 0);

            renderer.Render();
        }
    }
}
