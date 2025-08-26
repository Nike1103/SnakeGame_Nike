using System;

class Program
{
    static void Main(string[] args)
    {
        int level = 1;

        while (true)
        {
            // Показываем номер уровня
            new ShowTextState($"Уровень {level}", 1500).Enter();
            System.Threading.Thread.Sleep(1500);

            // Создаем игровое состояние
            var gameState = new SnakeGameState();
            gameState.Enter();

            // Игровой цикл
            while (true)
            {
                gameState.Update();

                // Проверяем условия завершения уровня
                if (gameState.Logic.GameOver || gameState.Logic.LevelComplete)
                {
                    // Ждем нажатия любой клавиши
                    Console.ReadKey(true);
                    break;
                }

                // Задержка для плавности игры
                System.Threading.Thread.Sleep(50);
            }

            if (gameState.Logic.LevelComplete)
            {
                level++;
            }
        }
    }
}