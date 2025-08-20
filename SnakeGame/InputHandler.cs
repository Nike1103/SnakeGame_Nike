using System;

namespace SnakeGame
{
    public class InputHandler
    {
        public Direction CurrentDirection { get; private set; }

        public InputHandler(Direction initialDirection)
        {
            CurrentDirection = initialDirection;
        }

        public void UpdateDirection()
        {
            if (!Console.KeyAvailable) return;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (CurrentDirection != Direction.Down)
                        CurrentDirection = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (CurrentDirection != Direction.Up)
                        CurrentDirection = Direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (CurrentDirection != Direction.Right)
                        CurrentDirection = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (CurrentDirection != Direction.Left)
                        CurrentDirection = Direction.Right;
                    break;
            }
        }
    }
}
