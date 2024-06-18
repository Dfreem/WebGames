using System.Numerics;
using System.Reflection.Metadata;
using System.Security.AccessControl;

using WebGames.Shared.Enums;

namespace WebGames.Games.Snake;


public class PlayerSnake : IPlayer
{
    public event EventHandler? Snake_Collide;
    public event EventHandler? Snake_Dead;
    public event EventHandler? Snake_Feed;

    private SnakeSection[] _sections;

    public PlayerSnake(int gridWidth, int gridHeight)
    {
        _gridHeight = gridHeight;
        _gridWidth = gridWidth;
        var startX = _gridWidth / 2;
        var startY = _gridHeight / 2;
        _sections = [
            new SnakeSection(startX + 2, startY),
            new SnakeSection(startX + 1, startY),
            new SnakeSection(startX, startY)
        ];
        Direction = _directionLock = SnakeDirection.East;
    }

    public SnakeSection Head { get => _sections[0]; }

    public SnakeSection[] Sections { get => _sections; }

    public SnakeDirection Direction { get; set; } = SnakeDirection.East;

    private SnakeDirection _directionLock;

    int _gridWidth;

    int _gridHeight;

    public int Score { get => _sections.Length; }

    public bool IsDead { get; set; } = false;

    public void Left()
    {        if (Direction != SnakeDirection.East && _directionLock != SnakeDirection.East) Direction = SnakeDirection.West;
    }

    public void Right()
    {
        if (Direction != SnakeDirection.West && _directionLock != SnakeDirection.West) Direction = SnakeDirection.East;
    }

    public void Up()
    {
        if (Direction != SnakeDirection.South && _directionLock != SnakeDirection.South) Direction = SnakeDirection.North;
    }

    public void Down()
    {
        if (Direction != SnakeDirection.North && _directionLock != SnakeDirection.North) Direction = SnakeDirection.South;
    }
 
    public void Forward()
    {
        var directionVector = Direction.ToDirectionVec();
        SnakeSection tail = _sections[^1];
        _sections = _sections[..^1];
        tail.X = Head.X + directionVector.X;
        tail.Y = Head.Y + directionVector.Y;
        _sections = [tail, .. _sections];
        _directionLock = Direction;
    }
    public void Kill()
    {
        IsDead = true;
        Snake_Dead?.Invoke(this, EventArgs.Empty);
    }

    public bool CheckForWall()
    {
        bool hitTop = 0 > Head.Y && Direction == SnakeDirection.North;
        bool hitBottom = Head.Y > _gridHeight && Direction == SnakeDirection.South;
        bool hitLeft = 0 > Head.X && Direction == SnakeDirection.West;
        bool hitRight = Head.X > _gridWidth & Direction == SnakeDirection.East;
        return hitTop || hitBottom || hitLeft || hitRight;
    }

    public bool CheckForCollision()
    {
        var body = _sections[1..];
        return body.Any(s => s.X == Head.X && s.Y == Head.Y);
    }

    public void Wrap()
    {
        switch (Direction)
        {
            case SnakeDirection.West:
                Head.X = _gridWidth;
                break;
            case SnakeDirection.East:
                Head.X = 0;
                break;
            case SnakeDirection.North:
                Head.Y = _gridHeight;
                break;
            case SnakeDirection.South:
                Head.Y = 0;
                break;
            default:
                break;
        }
    }

    public void Eat()
    {
        var directionVector = Direction.ToDirectionVec();
        _sections = [new(Head.X + directionVector.X, Head.Y + directionVector.Y), .. _sections];
    }
}
