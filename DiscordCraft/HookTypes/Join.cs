// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Join
    {
        public static async Task Send(SocketUserMessage msg) =>
            await WebHook.SendEmbedHook("SkyFactory", msg.Author.GetAvatarUrl(), msg.Author.Username, 65280, "**joined the server!**");
    }
}