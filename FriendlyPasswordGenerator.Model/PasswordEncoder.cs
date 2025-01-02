using System.Text;

namespace FriendlyPasswordGenerator.Model;

public static class PasswordEncoder
{
    private const int SymbolCode = 0;
    private const int NumberCode = 1;
    private const int WordCode = 2;

    private static Task<string> TranslateCode(int code)
    {
        Task<string> result = code switch
        {
            SymbolCode => Randomizer.RandomSymbol(),
            NumberCode => Randomizer.RandomNumber(),
            WordCode => Randomizer.RandomWord(),
            _ => throw new InvalidDataException($"The following pattern Index doesn't exist: {code}"),
        };

        return result;
    }

    public static async Task<string> TranslatePattern(List<int> pattern)
    {
        StringBuilder result = new();

        foreach (var index in pattern)
        {
            string? translatedValue = await TranslateCode(index);
            result.Append(translatedValue);
        }

        return result.ToString();
    }
}
