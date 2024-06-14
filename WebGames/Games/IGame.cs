using WebGames.Games.Snake;

namespace WebGames.Games;

public interface IGame
{
    string GameTitle { get; set; }
    GameResulution ScreenSize { get; set; }
    int Tick { get; set; }

    void SetScreenSize(int width = 600, int height = 600);
}