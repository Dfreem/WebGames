using WebGames.Shared.Enums;

namespace WebGames.Games.Snake
{
    public interface IPlayer
    {
        SnakeDirection Direction { get; set; }
        bool IsDead { get; set; }

        event EventHandler? Snake_Collide;
        event EventHandler? Snake_Dead;
        event EventHandler? Snake_Feed;

        bool CheckForCollision();
        bool CheckForWall();
        void Kill();

    }
}