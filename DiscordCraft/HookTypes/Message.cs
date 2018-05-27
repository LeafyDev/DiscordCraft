// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Message
    {
        public static async Task Send(SocketUserMessage msg) =>
            await WebHook.SendHook(msg.Author.GetAvatarUrl(), msg.Author.Username, msg.Content.Remove(0, 6));
    }
}