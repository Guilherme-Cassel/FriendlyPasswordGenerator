namespace FriendlyPasswordGenerator;

public class Program
{
    public static PasswordGenerator passwordGenerator = new();

    //Main Method waits synchronously all the asynchronous methods, causes Clipboard requires STAThread.
    [STAThread]
    static void Main()
    {
        ConsoleUtility.WriteOn($"""
            Copy Text = Enter
            Generate New = Any Other Key
            AllowNonAsciiCaracters = F8
            Choose Amount of Words = F9
            Choose new Lenght = F10

            """,
            ConsoleColor.Yellow);

        NewPassword().GetAwaiter().GetResult(); //this will never throw an error

        while (true)
        {
            try
            {
                TreatInput().GetAwaiter().GetResult();
            }
            catch (TimeoutException ex)
            {
                ConsoleUtility.WriteOn($"{ex.Message}", ConsoleColor.Yellow);
            }
        }
    }

    private async static Task NewPassword()
    {
        await passwordGenerator.GetNewPassword();

        ConsoleUtility.WriteOn($"New Password: {passwordGenerator.CurrentPassword}",
            ConsoleColor.Green);
    }

    private async static Task TreatInput()
    {
        ConsoleKeyInfo input = Console.ReadKey();

        switch (input.Key)
        {
            case ConsoleKey.Enter:
                passwordGenerator.CopyPassword();
                break;

            case ConsoleKey.F10:
                passwordGenerator.NewLenght();
                break;

            case ConsoleKey.F9:
                passwordGenerator.NewAmoutOfWords();
                break;

            case ConsoleKey.F8:
                passwordGenerator.ToggleAsciiCaracters();
                break;

            default:
                await NewPassword();
                break;
        };
    }
}

