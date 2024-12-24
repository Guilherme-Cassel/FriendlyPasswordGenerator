namespace FriendlyPasswordGenerator;

public static class ConsoleUtility
{
    public static void WriteOn(string text, ConsoleColor color)
    {
        var bckpColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = bckpColor;
    }
}
