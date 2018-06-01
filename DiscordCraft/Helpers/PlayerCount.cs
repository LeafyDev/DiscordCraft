// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace DiscordCraft.Helpers
{
    internal static class PlayerCount
    {
        public static int CurrentPlayers { get; private set; }

        public static async Task AddPlayer()
        {
            CurrentPlayers++;
            await Update();
        }

        public static async Task DelPlayer()
        {
            CurrentPlayers--;
            await Update();
        }

        public static async Task Update()
        {
            await Program._client.SetGameAsync($"{Config.DiscordGame}: {CurrentPlayers} online");
        }
    }
}