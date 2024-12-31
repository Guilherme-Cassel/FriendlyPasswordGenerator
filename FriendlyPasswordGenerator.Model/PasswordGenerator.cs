using FriendlyPasswordGenerator.Model;
using System.Text;

namespace FriendlyPasswordGenerator;

public static class PasswordGenerator
{
    public static async Task<string> Run(UserSettings uS)
    {
        var fullPattern = await GetPasswordPattern(uS);


        var password = await Global.RunWithTimeout
            (
                GetNewPassword(fullPattern),
                CalculateTimeoutInMilliseconds(uS)
            );




    }


    private static async Task<string> GetNewPassword(List<int> Pattern)
    {


        //if (password.Length < PasswordLenght)
        //    return await GetNewPassword();

        //CurrentPassword = password.ToString();
        //return password.ToString();
    }

    private static async Task<List<int>> GetPasswordPattern(UserSettings uS)
    {
        return await Task.Run(() =>
        {
            List<int> pattern = [];
            for (int i = 0; i < uS.AmountOfWords; i++)
            {
                pattern.AddRange(Randomizer.RandomPattern());
                pattern.Add(2);
            }
            pattern.AddRange(Randomizer.RandomPattern());

            return pattern;
        });
    }

    private static int CalculateTimeoutInMilliseconds(UserSettings userSettings)
    {
        double baseTime = 5.0; // Base time for 40 characters and 3 words
        int baseLength = 40;
        int baseWordCount = 3;

        // Calculate the scaling factor
        double lengthFactor = Math.Log(userSettings.MinimumLenght + 1) / Math.Log(baseLength + 1);
        double wordFactor = Math.Log(userSettings.AmountOfWords + 1) / Math.Log(baseWordCount + 1);

        // Combine the factors to estimate the timeout
        double estimatedTime = baseTime * lengthFactor * wordFactor;

        // Set a maximum timeout limit (e.g., 60 seconds)
        double maxTimeout = 60.0;
        return (int)(Math.Min(estimatedTime, maxTimeout) * 1000);
    }

    private static async Task<string> TranslatePattern(List<int> pattern)
    {
        static Func<string> IntToFunction(int a)
        {
            return a switch
            {
                0 => Randomizer.RandomSymbol,
                1 => Randomizer.RandomNumber,
                2 => Randomizer.RandomWord,
                _ => throw new InvalidDataException($"The following pattern Index doesn't exist: {a}"),
            };
        }

        return await Task.Run(() =>
        {
            StringBuilder result = new();

            foreach (var index in pattern)
            {
                result.Append(IntToFunction(index)());
            }

            return result.ToString();
        });
    }

}
