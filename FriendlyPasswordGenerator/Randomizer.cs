using System.Globalization;

namespace FriendlyPasswordGenerator;

public class Randomizer
{
    public readonly Random @Random = new();
    public bool AllowNonAsciiCaracters = false;

    public string RandomSymbol()
    {
        string symbols = "!@#$%&*";

        char randomSymbol = symbols[@Random.Next(symbols.Length)];

        return randomSymbol.ToString();
    }

    public string RandomNumber()
    {
        return @Random.Next(0, 10).ToString();
    }

    public string RandomWord()
    {
        var file = Properties.Resources.palavras;

        var wordsList = file.Split('\n');

        var word = ToPascalCase(wordsList[@Random.Next(0, wordsList.Length - 1)]);

        if (word.Contains('-') ||
            word.Contains('.'))
            return RandomWord();

        if (!AllowNonAsciiCaracters)
        {
            if (word.Any(x => (int)x >= 128))
                return RandomWord();
        }

        return ToPascalCase(word);
    }

    public static string ToPascalCase(string @string)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        @string = textInfo.ToTitleCase(@string.ToLower());
        return @string.Replace(" ", string.Empty);
    }
}
