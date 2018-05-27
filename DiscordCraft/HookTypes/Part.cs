// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Part
    {
        public static async Task Send(SocketUserMessage msg) =>
            await WebHook.SendEmbedHook("SkyFactory", msg.Author.GetAvatarUrl(), msg.Author.Username, 16711680, "**left the server!**");
    }
}