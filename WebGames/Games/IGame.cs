using WebGames.Games.Snake;
using WebGames.Shared.Enums;

namespace WebGames.Games;

public interface IGame
{
    string GameTitle { get; set; }
    GameResulution ScreenSize { get; set; }
    int Tick { get; set; }
    int NumberOfPlayers { get; init; }
    PlayerSnake Player { get; set; }

    GameType GameType { get; }

    void AddPlayer(PlayerSnake player);
    void SetScreenSize(int width = 600, int height = 600);
    void Update();
}