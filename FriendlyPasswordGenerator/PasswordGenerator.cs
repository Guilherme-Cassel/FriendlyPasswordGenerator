using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Windows.Devices.Power;

namespace FriendlyPasswordGenerator;

public class PasswordGenerator : Randomizer
{
    public string CurrentPassword = null!;
    public int PasswordLenght = 40;
    public int NumberOfWords = 3;
    public const int TimeOutInSecondsPerWord = 5;

    public async Task<string> GetNewPassword()
    {
        Task timeoutTask = Task.Delay(Convert.ToInt32(CalculateTimeout() * 1000));
        Task<string> task = Task.Run(GenerateNewPassword);

        Task completedTask = await Task.WhenAny(task, timeoutTask);

        if (completedTask == task)
        {
            // Task completed within timeout
            return await task;
        }
        else
        {
            throw new TimeoutException($"""
                Generation Timed Out!
                Consider increasing the amount of words ({NumberOfWords}), or decreasing the minimum lenght ({PasswordLenght}).
                """);
        }
    }

    private async Task<string> GenerateNewPassword()
    {
        Dictionary<int, Func<string>> passwordPatternIndex = new()
        {
            {0, base.RandomSymbol},
            {1, base.RandomNumber},
            {2, base.RandomWord},
        };

        StringBuilder password = new();
        List<int> pattern = RandomPattern();

        foreach (var index in pattern)
        {
            var dictIndex = passwordPatternIndex.Where(x => x.Key == index).First();

            password.Append(dictIndex.Value());
        }

        if (password.Length < PasswordLenght)
            return await GenerateNewPassword();

        CurrentPassword = password.ToString();
        return password.ToString();
    }

    private List<int> RandomPattern()
    {
        List<int> newInBetweenWordsPattern()
        {
            List<int> middle = [];
            for (int j = 0; j < 3; j++)
            {
                middle.Add(Random.Next(0, 2));
            }
            return middle;
        }

        List<int> pattern = [];
        for (int i = 0; i < NumberOfWords; i++)
        {
            pattern.AddRange(newInBetweenWordsPattern());
            pattern.Add(2);
        }
        pattern.AddRange(newInBetweenWordsPattern());

        return pattern;
    }

    private double CalculateTimeout()
    {
        double baseTime = 5.0; // Base time for 40 characters and 3 words
        int baseLength = 40;
        int baseWordCount = 3;

        // Calculate the scaling factor
        double lengthFactor = Math.Log(PasswordLenght + 1) / Math.Log(baseLength + 1);
        double wordFactor = Math.Log(NumberOfWords + 1) / Math.Log(baseWordCount + 1);

        // Combine the factors to estimate the timeout
        double estimatedTime = baseTime * lengthFactor * wordFactor;

        // Set a maximum timeout limit (e.g., 60 seconds)
        double maxTimeout = 60.0;
        return Math.Min(estimatedTime, maxTimeout);
    }

    public void CopyPassword()
    {
        Clipboard.SetText(CurrentPassword);
        ConsoleUtility.WriteOn($"Password Copied!", ConsoleColor.Red);
    }

    public void NewLenght()
    {
        ConsoleUtility.WriteOn($"Write new Lenght (integer):", ConsoleColor.Blue);
        PasswordLenght = Convert.ToInt32(Console.ReadLine());
    }

    public void NewAmoutOfWords()
    {
        ConsoleUtility.WriteOn($"Write the new amount of Words (integer):",
            ConsoleColor.Blue);

        var amount = Convert.ToInt32(Console.ReadLine());

        if (amount <= 0)
        {
            ConsoleUtility.WriteOn("O valor não pode ser zero",
                ConsoleColor.Yellow);
            return;
        }

        NumberOfWords = amount;
    }

    public void ToggleAsciiCaracters()
    {
        AllowNonAsciiCaracters = !AllowNonAsciiCaracters;
        ConsoleUtility.WriteOn($"AllowNonAsciiCaracters = {AllowNonAsciiCaracters}",
            ConsoleColor.Blue);
    }
}
