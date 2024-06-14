namespace WebGames.Shared.Enums;

public enum SnakeDirection
{
    North,
    East,
    South,
    West
}

public static class SnakeDirectionExtensions
{
    public static Coords ToCoords(this SnakeDirection direction)
    {
        switch (direction)
        {
            case SnakeDirection.North:
                return new(0, 1);
            case SnakeDirection.East:
                return new(1, 0);
            case SnakeDirection.South:
                return new(0, -1);
            case SnakeDirection.West:
                return new(-1, 0);
            default:
                return new(0, 0);
        }
    }
}

public record Coords(int X, int Y);
