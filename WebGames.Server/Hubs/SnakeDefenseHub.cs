using Microsoft.AspNetCore.SignalR;

namespace WebGames.Server.Hubs;

public class SnakeDefenseHub : Hub<ISnakeDefenseClient>
{
    public async Task SendChatMessage(string player, string message)
    {
        await Clients.All.RecieveChatMessage(player, message);
    }

    public async Task PlaceTower(int x, int y)
    {
        await Clients.All.PlaceTower(x, y);
    }

}
