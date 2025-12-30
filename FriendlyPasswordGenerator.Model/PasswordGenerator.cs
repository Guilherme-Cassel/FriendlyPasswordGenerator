using FriendlyPasswordGenerator.Model;

namespace FriendlyPasswordGenerator;

public static class PasswordGenerator
{
    public static List<string> PasswordHistory = [];

    public static async Task<string> Run(UserSettings uS)
    {
        List<int> fullPattern = await GetPasswordPattern(uS);
        int timeout = await CalculateTimeoutInMilliseconds(uS);

        string password = await Global.RunWithTimeout(
            task: GetNewPassword(fullPattern, uS),
            timeout: timeout
            );

        PasswordHistory.Add(password);

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
        return await CalculateTimeoutInMilliseconds(userSettings.MinimumLenght, userSettings.AmountOfWords);
    }

    private static async Task<int> CalculateTimeoutInMilliseconds(int minimumLenght, int amountOfWords)
    {
        return await Task.Run(() =>
        {
            // Calculate the scaling factor
            double lengthFactor = Math.Log(minimumLenght + 1) / Math.Log(PasswordBase.BaseLength + 1);
            double wordFactor = Math.Log(amountOfWords + 1) / Math.Log(PasswordBase.BaseWordCount + 1);

            // Combine the factors to estimate the timeout
            double estimatedTime = PasswordBase.BaseGenerationTime * lengthFactor * wordFactor;

            // Set a maximum timeout limit (e.g., 60 seconds)
            double maxTimeout = 60.0;
            return (int)(Math.Min(estimatedTime, maxTimeout) * 1000);
        });
    }
}
