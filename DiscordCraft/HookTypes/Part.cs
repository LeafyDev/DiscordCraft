// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Part
    {
        public static async Task Send(SocketUserMessage msg)
        {
            var username = msg.Author.Username;

            if (username.Contains("§")) username = username.Split('§').LastOrDefault()?.Remove(0, 1);

            await WebHook.SendEmbedHook("SkyFactory", msg.Author.GetAvatarUrl(), username, 16711680,
                "**left the server!**");

            Stats.StopPlaying(username);

            await PlayerCount.DelPlayer();
        }
    }
}