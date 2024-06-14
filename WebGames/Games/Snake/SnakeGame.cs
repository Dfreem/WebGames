namespace WebGames.Games.Snake;

public class SnakeGame(int tick = 1000/4) : IGame
{
    public string GameTitle { get; set; } = "Snake";
    public GameResulution ScreenSize { get; set; } = new();
    public int Tick { get; set; } = tick;

    public void SetScreenSize(int width = 600, int height = 600)
    {
        ScreenSize = new(width, height);
    }
}
public record GameResulution(int Width = 600, int Height = 600);
