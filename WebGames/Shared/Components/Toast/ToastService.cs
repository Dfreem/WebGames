namespace WebGames.Shared.Components.Toast;
public class ToastService() : IToastService
{
    List<Task> _queue = new();

    public event EventHandler<ToastEventArgs> ToastEvent = default!;

    bool _isToasting = false;

    public string ToastLocation { get; set; } = "top";

    public void Success(string message)
    {

        ToastEventArgs args = new(message, "toast-success", ToastLocation);
        AddToQ(args);
    }

    public void Error(string message)
    {
        ToastEventArgs args = new(message, "toast-error", ToastLocation);
        AddToQ(args);
    }


    public void Warning(string message)
    {
        ToastEventArgs args = new(message, "toast-warning", ToastLocation);
        AddToQ(args);
    }

    public void Info(string message)
    {
        ToastEventArgs args = new(message, "toast-info", ToastLocation);
        AddToQ(args);
    }

    private void AddToQ(ToastEventArgs args)
    {
        _queue.Add(RaiseToastEvent(args));
        if (!_isToasting) _ = ProcessToastEventsAsync();

    }

    protected virtual async Task RaiseToastEvent(ToastEventArgs args)
    {
        ToastEvent?.Invoke(this, args);
        await Task.CompletedTask;
    }

    private async Task ProcessToastEventsAsync()
    {
        _isToasting = true;
        while (_queue.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(_queue);
            _queue.Remove(finishedTask);
            await finishedTask;
        }
        _isToasting = false;
    }

}

public class ToastEventArgs(string message = "", string cssClass = "", string location = "top") : EventArgs
{
    public string Message { get; set; } = message;

    // TODO upgrade to Enum
    public string CssClass { get; set; } = cssClass;

    public string Location { get; set; } = location;
}