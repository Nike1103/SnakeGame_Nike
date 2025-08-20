using System;

namespace SnakeGame
{
    public class SnakeGameState : GameState
    {
        private int x = 10;
        private int y = 10;
        private InputHandler inputHandler;

        public SnakeGameState()
        {
            inputHandler = new InputHandler(Direction.Right);
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
            Console.Clear();
            Console.WriteLine($"Snake head: X={x}, Y={y}");
        }
    }
}
