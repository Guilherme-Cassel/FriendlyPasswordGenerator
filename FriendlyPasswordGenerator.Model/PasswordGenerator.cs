using FriendlyPasswordGenerator.Model;
using System.Text;

namespace FriendlyPasswordGenerator;

public static class PasswordGenerator
{
    public static async Task<string> Run(UserSettings uS)
    {
        var fullPattern = await GetPasswordPattern(uS);
        var timeout = CalculateTimeoutInMilliseconds(uS);

        var password = await Global.RunWithTimeout(
            task: GetNewPassword(fullPattern),
            timeout: timeout
            );

        return password;
    }


    private static async Task<string> GetNewPassword(List<int> Pattern)
    {
        string password = await PasswordEncoder.TranslatePattern(Pattern);

        return password;
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
}
