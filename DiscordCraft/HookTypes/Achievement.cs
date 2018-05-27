// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Achievement
    {
        public static async Task Send(SocketUserMessage msg)
        {
            var ach_name = msg.Content.Remove(0, 14).Split('^')[0];
            var ach_desc = msg.Content.Split('^')[1];
            await WebHook.SendEmbedHook("Achievement Unlocked", msg.Author.GetAvatarUrl(), msg.Author.Username,
                16776960, $"{Format.Bold(ach_name)}\n{Format.Italics(ach_desc)}");
        }
    }
}