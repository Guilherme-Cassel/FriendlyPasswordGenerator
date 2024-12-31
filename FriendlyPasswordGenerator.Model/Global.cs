using System.Threading.Tasks;


namespace FriendlyPasswordGenerator.Model;

public static class Global
{
    public static async Task<string> RunWithTimeout(Task<string> _task, int timeout)
    {
        using var cts = new CancellationTokenSource();

        var delayTask = Task.Delay(timeout, cts.Token);

        // Cancel the task if it takes longer than the timeout
        if (await Task.WhenAny(_task, delayTask) == delayTask)
        {
            cts.Cancel();
            throw new OperationCanceledException(cts.Token);
        }
    }
}
