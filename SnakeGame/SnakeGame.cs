namespace SnakeGame
{
    public class SnakeGame : Game
    {
        private GameState currentState;

        protected override void Initialize()
        {
            currentState = new SnakeGameState();
        }

        protected override void Update()
        {
            currentState.Update();
        }

        protected override void Render()
        {
            currentState.Render();
        }
    }
}
