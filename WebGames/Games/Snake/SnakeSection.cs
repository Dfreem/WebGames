namespace WebGames.Games.Snake;


public class SnakeSection(int x, int y) : IGridSection
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public SectionType SectionType { get => SectionType.SnakeSection; }
}

