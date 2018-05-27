// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Command
    {
        public static async Task Send(SocketUserMessage msg) =>
            await WebHook.SendHook($"executed command: **{msg.Content.Remove(0, 6)}**");
    }
}