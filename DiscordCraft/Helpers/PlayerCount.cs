// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Data;
using System.Threading.Tasks;

namespace DiscordCraft.Helpers
{
    internal static class PlayerCount
    {
        private static int CurrentPlayers { get; set; }

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
            await Program._client.SetGameAsync($"SkyFactory 2.4: {CurrentPlayers} online");
        }
    }
}