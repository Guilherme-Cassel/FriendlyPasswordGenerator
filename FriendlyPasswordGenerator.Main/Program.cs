namespace FriendlyPasswordGenerator.Main;

public static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormPasswordGenerator());
    }
}