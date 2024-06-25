namespace WebGames.Extensions;

public static class StringExtensions
{
    public static string Toggle(this string stringContent, string remove) => stringContent.Contains(remove) ? stringContent.Replace(remove, "") : stringContent + remove;
}
