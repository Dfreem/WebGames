using System.Numerics;
using System.Reflection.Metadata;
using System.Security.AccessControl;

using WebGames.Shared.Enums;

namespace WebGames.Games.Snake;


public class PlayerSnake(IGridSection[,] Grid)
{
    public SnakeSection[] Sections { get; set; } = [
        new SnakeSection(0, 0),
        new SnakeSection(1, 0),
        new SnakeSection(2, 0)
    ];

    public SnakeDirection Direction { get; set; } = SnakeDirection.East;

    public bool IsDead { get; set; } = false;

    public void Left()
    {
        Direction = SnakeDirection.West;
    }
 
    public void Right()
    {
        Direction = SnakeDirection.East;
    }
 
    public void Up()
    {
        Direction = SnakeDirection.North;
    }
 
    public void Down()
    {
        Direction = SnakeDirection.South;
    }

    // these are wrong for this game. I remembered the controls incorrectly because I'm old and this game is old so fuck you.
    // but I thought about this for a few minutes and now I have a sunk cost mindset that won't let me delete them.
    //public void Right()
    //{
    //    switch (Direction)
    //    {

    //        case SnakeDirection.North:
    //            Direction = SnakeDirection.West;
    //            break;
    //        case SnakeDirection.East:
    //            Direction = SnakeDirection.North;
    //            break;
    //        case SnakeDirection.South:
    //            Direction = SnakeDirection.East;
    //            break;
    //        case SnakeDirection.West:
    //            Direction = SnakeDirection.South;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //public void Left()
    //{
    //    switch (Direction)
    //    {
    //        case SnakeDirection.North:
    //            Direction = SnakeDirection.East;
    //            break;
    //        case SnakeDirection.East:
    //            Direction = SnakeDirection.South;
    //            break;
    //        case SnakeDirection.South:
    //            Direction = SnakeDirection.West;
    //            break;
    //        case SnakeDirection.West:
    //            Direction = SnakeDirection.North;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void Forward()
    {
        if (Sections.Length < 2 || IsDead) return;
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
        Wrap();
    }

    public bool OutOfRangeY()
    {
        int wallIndex = Sections.GetLength(0);
        return Sections.Any(s => Grid[0, 0].Y > s.Y || s.Y > Grid[wallIndex, wallIndex].Y);
    }

    public bool OutOfRangeX()
    {
        var wallIndex = Grid.GetLength(0) - 1;
        return Sections.Any(s => Grid[0, 0].X > s.X || s.X > Grid[wallIndex, wallIndex].X);
    }

    public void Wrap()
    {
        if (OutOfRangeX())
        {
            Sections[0].X %= 15;
        }
        if (OutOfRangeY())
        {
            Sections[0].Y %= 15;
        }
    }
}
