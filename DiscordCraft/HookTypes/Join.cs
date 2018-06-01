// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Join
    {
        public static async Task Send(SocketUserMessage msg)
        {
            var username = msg.Author.Username;

            if (username.Contains("§")) username = username.Split('§').LastOrDefault()?.Remove(0, 1);

            await WebHook.SendEmbedHook("SkyFactory", msg.Author.GetAvatarUrl(), username, 65280,
                "**joined the server!**");

            Stats.AddPlayer(username);

            Stats.StartPlaying(username);

            await PlayerCount.AddPlayer();
        }
    }
}