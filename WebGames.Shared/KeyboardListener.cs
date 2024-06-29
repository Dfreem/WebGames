using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace WebGames.Shared;

public class KeyboardListener
{
    const string ArrowUp = "ArrowUp";
    const string ArrowDown = "ArrowDown";
    const string ArrowLeft = "ArrowLeft";
    const string ArrowRight = "ArrowRight";
    const string KeyEscape = "Escape";
    const string KeyEnter = "Enter";

    public event EventHandler? OnLeft;
    public event EventHandler? OnRight;
    public event EventHandler? OnUp;
    public event EventHandler? OnDown;
    public event EventHandler? OnEnter;
    public event EventHandler? OnEsc;

    public void Left()
    {
        OnLeft?.Invoke(this, new());
    }
    public void Right()
    {
        OnRight?.Invoke(this, new());
    }
    public void Up()
    {
        OnUp?.Invoke(this, new());
    }
    public void Down()
    {
        OnDown?.Invoke(this, new());
    }
    public void Enter()
    {
       OnEnter?.Invoke(this, EventArgs.Empty); 
    }
    public void Escape()
    {
        OnEsc?.Invoke(this, EventArgs.Empty);
    }

    [JSInvokable]
    public void GetKey(string pressedKey)
    {
        switch (pressedKey)
        {
            case(KeyEnter):
                Enter();
                break;
            case(KeyEscape):
                Escape();
                break;
            case(ArrowDown):
                Down();
                break;
            case(ArrowUp):
                Up();
                break;
            case(ArrowLeft):
                Left();
                break;
            case(ArrowRight):
                Right();
                break;
            default:
                break;
        }
    }

}

