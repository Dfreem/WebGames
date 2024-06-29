namespace WebGames.Server.Hubs
{
    public interface ISnakeDefenseClient
    {
        public Task SendChatMessage(string player, string message);
        public Task RecieveChatMessage(string player, string message);
        public Task PlaceTower(int x, int y);
    }
}
