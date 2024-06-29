namespace WebGames.Shared.Games.Snake;

public class FoodGridSection(int x, int y) : IGridSection
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public SectionType SectionType => SectionType.Food;
}