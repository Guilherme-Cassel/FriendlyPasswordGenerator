using System.Globalization;
using System.Text;

namespace FriendlyPasswordGenerator.Model;

public static class Randomizer
{
    private static readonly Random @Random = new();

    public static string RandomSymbol()
    {
        string symbols = "!@#$%&*";

        char randomSymbol = symbols[@Random.Next(symbols.Length)];

        return randomSymbol.ToString();
    }

    public static string RandomNumber()
    {
        return @Random.Next(0, 10).ToString();
    }

    public static string RandomWord()
    {
        var file = Properties.Resources.FullBrazillianDictionary;

        var wordsList = file.Split('\n');

        var word = ToPascalCase(wordsList[@Random.Next(0, wordsList.Length - 1)]);

        if (word.Contains('-') ||
            word.Contains('.'))
            return RandomWord();

        //if (!userSettings.AllowNonAsciiCaracters)
        //{
        //    if (word.Any(x => (int)x >= 128))
        //        return RandomWord();
        //}

        return ToPascalCase(word);
    }

    public static List<int> RandomPattern(int lenght = 3)
    {
        List<int> middle = [];
        for (int j = 0; j < lenght; j++)
        {
            middle.Add(@Random.Next(0, 2));
        }
        return middle;
    }

    public static string ToPascalCase(string @string)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        @string = textInfo.ToTitleCase(@string.ToLower());
        return @string.Replace(" ", string.Empty);
    }
}
