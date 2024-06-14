namespace WebGames.Games;

public class GameManager(IGame CurrentGame)
{
    public event EventHandler? GameStarted;

    public event EventHandler? GameEnded;

    public event EventHandler? GamePaused;

    public event EventHandler? Update;

    public bool IsRunning { get; set; } = false;

    public async Task Run()
    {
        IsRunning = true;
        GameStarted?.Invoke(this, EventArgs.Empty);
        while (IsRunning)
        {
            Update?.Invoke(this, EventArgs.Empty);
            await Task.Delay(CurrentGame.Tick);
        }
    }

}
