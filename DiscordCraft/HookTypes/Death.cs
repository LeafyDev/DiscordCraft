// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord.WebSocket;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class Death
    {
        public static async Task Send(SocketUserMessage msg)
        {
            await WebHook.SendHook(
                "https://orig00.deviantart.net/3437/f/2010/320/d/5/chibi_grim_reaper_by_xdoodlezx-d330n8z.png",
                "Grim Reaper", $"*took the soul of:* **{msg.Author.Username}** ({msg.Content.Remove(0, 8)})");
        }
    }
}