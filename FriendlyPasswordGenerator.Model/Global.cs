namespace FriendlyPasswordGenerator.Model;

public static class Global
{
    public static async Task<T> RunWithTimeout<T>(Task<T> task, int timeout)
    {
        var delayTask = Task.Delay(timeout);

        // Cancel the task if it takes longer than the timeout
        if (await Task.WhenAny(task, delayTask) == delayTask)
        {
            throw new TimeoutException("Operation Timed Out! Try matching the paremeters with resonable values");
        }

        return await task;
    }
}
