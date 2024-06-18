using System.Reflection.Metadata.Ecma335;

using WebGames.Shared.Enums;

namespace WebGames.Games.Snake;

public class SnakeGame : IGame
{
    public SnakeGame(int tick = 1000 / 4)
    {
        Tick = tick;
        SetScreenSize();
        BuildGrid();
        Player = new(Grid.GetLength(1), Grid.GetLength(0));
        Player.Snake_Feed += (sender, args) => GenerateFood();
        _directionVector = Player.Direction.ToDirectionVec();
    }

    DirectionVector _directionVector;
    public int NumberOfPlayers { get; init; } = 1;

    public void AddPlayer(PlayerSnake player) => Player = player;

    public GameType GameType { get => GameType.Snake;  }

    public PlayerSnake Player { get; set; }

    public string GameTitle { get; set; } = "Snake";

    public IGridSection[,] Grid { get; set; } = default!;

    public GameResulution ScreenSize { get; set; } = new();
    public FoodGridSection? Food { get; set; }

    public int Tick { get; set; }
    /// <summary>
    /// The length of one side of a grid section. Sections are square
    /// </summary>
    public int GridSectionSize { get; set; } = 35;

    /// <summary>
    /// The number of <see cref="IGridSection"/>s the fit evenly into the <see cref="ScreenSize"/> in the x axis
    /// </summary>
    public int SectionsWide { get => ScreenSize.Width / GridSectionSize; }

    /// <summary>
    /// The number of <see cref="IGridSection"/>s the fit evenly into the <see cref="ScreenSize"/> in the y axis
    /// </summary>
    public int SectionsTall { get => ScreenSize.Height / GridSectionSize; }

    public void Update()
    {
        _directionVector = Player.Direction.ToDirectionVec();
        if (Player.Sections.Length < 2 || Player.IsDead) return;
        Player.Forward();
        if (Player.CheckForWall()) Player.Wrap();
        if (Player.Head.X == Food?.X && Player.Head.Y == Food?.Y)
        {
            Player.Eat();
            GenerateFood();
        }
        if (Player.CheckForCollision())
        {
            Player.Kill();
        }    
    }

    public void SetScreenSize(int width = 600, int height = 600)
    {
        width = width - (width % GridSectionSize);
        height = height - (height % GridSectionSize);
        ScreenSize = new(width, height);
    }
    public void BuildGrid()
    {
        Grid = new IGridSection[SectionsWide, SectionsTall];
        if (Food == null) GenerateFood();
        for (int y = 0; y < SectionsTall; y++)
        {
            for (int x = 0; x < SectionsWide; x++)
            {
                if (Food?.X == x && Food?.Y == y)
                {
                    Grid[x, y] = new FoodGridSection(x, y);
                }
                else if (Player != null && Player.Sections.Any(s => s.X == x && s.Y == y))
                {
                    Grid[x, y] = new SnakeSection(x, y);
                }
                else
                {
                    Grid[x, y] = new GridSection(x, y);
                }
            }
        }
        Grid[Food!.X, Food!.Y] = Food;

    }

    public void GenerateFood()
    {
        Random random = new();
        Food = new(random.Next(Grid.GetLength(0) - 1), random.Next(Grid.GetLength(1) - 1));
        Grid[Food.X, Food.Y] = Food;
        BuildGrid();
    }

    public bool CheckCollision(IGridSection section)
    {
        for(int x = 1;x < Player.Sections.Length; x++)
        {
            if (section.X == Player.Head.X && section.Y == Player.Head.Y)
            {
                return true;
            }
        }
        return false;
    }
    //private bool OutOfBounds() => Player.Head.X >= Grid.GetLength(1) - 1 || Player.Head.Y >= Grid.GetLength(0) - 1 || Player.Head.X < 0 || Player.Head.Y < 0;

}


public record GameResulution(int Width = 600, int Height = 600);
