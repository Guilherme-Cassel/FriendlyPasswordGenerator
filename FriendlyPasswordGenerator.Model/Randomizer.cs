using System.Globalization;
using System.Text;

namespace FriendlyPasswordGenerator.Model;

public static class Randomizer
{
    private static readonly Random @Random = new();

    public static async Task<string> RandomSymbol()
    {
        string symbols = "!@#$%&*";

        return await Task.Run(() =>
        {
            char randomSymbol = symbols[@Random.Next(symbols.Length)];

            return randomSymbol.ToString();
        });
    }

    public static async Task<string> RandomNumber()
    {
        return await Task.Run(() =>
        {
            return @Random.Next(0, 10).ToString();
        });
    }

    public static async Task<string> RandomWord()
    {
        return await Task.Run(async () =>
        {
            var file = Properties.Resources.FullBrazillianDictionary;

            var wordsList = file.Split('\n');

            var word = wordsList[@Random.Next(0, wordsList.Length - 1)];

            if (word.Contains('-') ||
                word.Contains('.'))
                return await RandomWord();

            return await ToPascalCase(word);
        });
    }

    public static async Task<List<int>> RandomPattern(int lenght = 3)
    {
        return await Task.Run(() =>
        {
            List<int> middle = [];
            for (int j = 0; j < lenght; j++)
            {
                middle.Add(@Random.Next(0, 2));
            }
            return middle;
        });
    }

    public static async Task<string> ToPascalCase(string @string)
    {
        return await Task.Run(() =>
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            @string = textInfo.ToTitleCase(@string.ToLower());
            return @string.Replace(" ", string.Empty);
        });
    }
}
