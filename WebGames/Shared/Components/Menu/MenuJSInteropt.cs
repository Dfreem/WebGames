using Microsoft.JSInterop;

namespace WebGames.Shared.Components.Menu;

public class MenuJSInteropt(IJSRuntime _js)
{
    public IJSObjectReference Module { get; set; } = default!;

    public async Task ToggleModalAsync(string menuId)
    {
        Module = await _js.InvokeAsync<IJSObjectReference>("import", "/Shared/Components/Menu/Menu.razor.js");
        await Module.InvokeVoidAsync("toggleModal", menuId);
    }
    public async Task ShowModalAsync(string menuId)
    {
        Module = await _js.InvokeAsync<IJSObjectReference>("import", "/Shared/Components/Menu/Menu.razor.js");
        await Module.InvokeVoidAsync("showModal", menuId);
    }
    public async Task HideModalAsync(string menuId)
    {
        Module = await _js.InvokeAsync<IJSObjectReference>("import", "/Shared/Components/Menu/Menu.razor.js");
        await Module.InvokeVoidAsync("hideModal", menuId);
    }
}
