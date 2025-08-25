namespace SnakeGame
{
    public abstract class Game
    {
        protected bool isRunning = true;

        public void Run()
        {
            Initialize();

            while (isRunning)
            {
                Update();
                Render();
                System.Threading.Thread.Sleep(150);
            }
        }

        protected abstract void Initialize();
        protected abstract void Update();
        protected abstract void Render();
    }
}
