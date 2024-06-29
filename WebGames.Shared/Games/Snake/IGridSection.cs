namespace WebGames.Shared.Games.Snake;


public interface IGridSection
{
    int X { get; set; }
    int Y { get; set; }
    SectionType SectionType { get; }
}

public enum SectionType
{
    DefaultSection,
    SnakeSection,
    Food
}
