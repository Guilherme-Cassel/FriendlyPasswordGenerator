using FriendlyPasswordGenerator.Model;
using System.Text;

namespace FriendlyPasswordGenerator;

public static class PasswordGenerator
{
    public static async Task<string> Run(UserSettings uS)
    {
        List<int> fullPattern = await GetPasswordPattern(uS);
        int timeout = await CalculateTimeoutInMilliseconds(uS);

        string password = await Global.RunWithTimeout(
            task: GetNewPassword(fullPattern, uS),
            timeout: timeout
            );

        return password;
    }

    private static async Task<string> GetNewPassword(List<int> Pattern, UserSettings uS)
    {
        string password = await PasswordEncoder.TranslatePattern(Pattern, uS);

        if (password.Length < uS.MinimumLenght)
            return await GetNewPassword(Pattern, uS);

        return password;
    }

    private static async Task<List<int>> GetPasswordPattern(UserSettings uS)
    {
        return await Task.Run(async () =>
        {
            List<int> pattern = [];
            for (int i = 0; i < uS.AmountOfWords; i++)
            {
                pattern.AddRange(await Randomizer.RandomPattern());
                pattern.Add(2);
            }
            pattern.AddRange(await Randomizer.RandomPattern());

            return pattern;
        });
    }

    private static async Task<int> CalculateTimeoutInMilliseconds(UserSettings userSettings)
    {
        return await Task.Run(() =>
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
        });
    }
}
