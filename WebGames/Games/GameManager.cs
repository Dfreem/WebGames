namespace WebGames.Games;

public class GameManager
{
    public event EventHandler? GameStarted;

    public event EventHandler? GameEnded;

    public event EventHandler? GamePaused;

    public event EventHandler? Update;

    public IGame CurrentGame { get; set; }

    public GameManager(IGame game)
    {

        CurrentGame = game;
        _cancelSource = new();
        _cancelToken = _cancelSource.Token;
    }

    CancellationTokenSource _cancelSource;

    CancellationToken _cancelToken;

    public void Quit()
    {
        GameEnded?.Invoke(this, EventArgs.Empty);
        _cancelSource.Cancel();
        
    }

    public bool IsRunning { get; set; } = false;

    public async Task Run()
    {
        IsRunning = true;
        GameStarted?.Invoke(this, EventArgs.Empty);
        while (IsRunning)
        {
            if (_cancelToken.IsCancellationRequested) IsRunning = false;
            Update?.Invoke(this, EventArgs.Empty);
            await Task.Delay(CurrentGame.Tick);
        }
    }

}
