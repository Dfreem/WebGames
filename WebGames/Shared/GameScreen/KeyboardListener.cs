using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace WebGames.Shared.GameScreen;

public class KeyboardListener
{

    public event EventHandler? OnLeft;
    public event EventHandler? OnRight;
    public event EventHandler? OnUp;
    public event EventHandler? OnDown;

    [JSInvokable]
    public void Left()
    {
        OnLeft?.Invoke(this, new());
    }
    [JSInvokable]
    public void Right()
    {
        OnRight?.Invoke(this, new());
    }
    [JSInvokable]
    public void Up()
    {
        OnUp?.Invoke(this, new());
    }
    [JSInvokable]
    public void Down()
    {
        OnDown?.Invoke(this, new());
    }



}
