// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord.Commands;

// ReSharper disable UnusedMember.Global

namespace DiscordCraft.Modules
{
    public class AboutCMD : ModuleBase<SocketCommandContext>
    {
        [Command("about")]
        public async Task About()
        {
            await ReplyAsync(
                "I am a Discord Webhook to Webhook bridge for Minecraft integration by LeafyDev," +
                " find out more here: https://github.com/LeafyDev/DiscordCraft");
        }
    }
}