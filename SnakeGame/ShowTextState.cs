public class ShowTextState : BaseGameState
{
    private string _text;
    private int _durationMs;
    private DateTime _startTime;

    public ShowTextState(string text, int durationMs = 2000)
    {
        _text = text;
        _durationMs = durationMs;
    }

    public override void Enter()
    {
        _startTime = DateTime.Now;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(Console.WindowWidth / 2 - _text.Length / 2, Console.WindowHeight / 2);
        Console.Write(_text);
    }

    public override void Update()
    {
        if ((DateTime.Now - _startTime).TotalMilliseconds >= _durationMs)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        // Состояние завершает свою работу
    }
}