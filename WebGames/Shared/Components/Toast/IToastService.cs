namespace WebGames.Shared.Components.Toast
{
    public interface IToastService
    {
        string ToastLocation { get; set; }

        event EventHandler<ToastEventArgs> ToastEvent;

        void Error(string message);
        void Success(string message);
        void Warning(string message);
        void Info(string message);
    }
}