using System.Numerics;
using System.Reflection.Metadata;
using System.Security.AccessControl;

using WebGames.Shared.Enums;

namespace WebGames.Games.Snake;


public class PlayerSnake
{
    public SnakeSection[] Sections { get; set; } = [
        new SnakeSection(0, 0),
        new SnakeSection(1, 0),
        new SnakeSection(2, 0)
    ];

    public SnakeDirection Direction { get; set; } = SnakeDirection.East;

    public bool IsDead { get; set; } = false;

    public void Right()
    {
        switch (Direction)
        {

            case SnakeDirection.North:
                Direction = SnakeDirection.West;
                break;
            case SnakeDirection.East:
                Direction = SnakeDirection.North;
                break;
            case SnakeDirection.South:
                Direction = SnakeDirection.East;
                break;
            case SnakeDirection.West:
                Direction = SnakeDirection.South;
                break;
            default:
                break;
        }
    }

    public void Left()
    {
        switch (Direction)
        {
            case SnakeDirection.North:
                Direction = SnakeDirection.East;
                break;
            case SnakeDirection.East:
                Direction = SnakeDirection.South;
                break;
            case SnakeDirection.South:
                Direction = SnakeDirection.West;
                break;
            case SnakeDirection.West:
                Direction = SnakeDirection.North;
                break;
            default:
                break;
        }
    }

    public void Forward()
    {
        if (Sections.Length < 2) return;
        var direction = Direction.ToCoords();
        SnakeSection tail = Sections[^1];
        SnakeSection head = Sections[0];
        Sections = Sections[..^1];
        tail.X = head.X + direction.X;
        tail.Y = head.Y + direction.Y;
        Sections = [tail, .. Sections];
    }

    public void Update()
    {
        Forward();
    }
}
