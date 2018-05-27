// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Command
    {
        public static async Task Send(SocketUserMessage msg)
        {
            var content = msg.Content.Remove(0, 6);
            if (content.StartsWith("say ", StringComparison.Ordinal))
                return;

            await WebHook.SendHook($"executed command: **{content}**");
        }
    }
}