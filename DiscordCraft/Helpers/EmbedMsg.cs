// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;

using Discord;

namespace DiscordCraft.Helpers
{
    internal static class EmbedMsg
    {
        public static async Task SendEmbedMessage(this IMessageChannel channel, Color color, string title = "",
            string description = "", string footerText = "",
            string iconUrl = "", string footerIconUrl = "", string authorIconUrl = "", string authorName = "",
            string titleUrl = "", bool log = false)
        {
            try
            {
                var embed = new EmbedBuilder()
                    .WithColor(color)
                    .WithTitle(title)
                    .WithUrl(titleUrl)
                    .WithDescription(description)
                    .WithThumbnailUrl(iconUrl)
                    .WithFooter(footer =>
                    {
                        footer.Text = footerText;
                        footer.IconUrl = footerIconUrl;
                    })
                    .WithAuthor(author =>
                    {
                        author.Name = authorName;
                        author.IconUrl = authorIconUrl;
                    }).Build();
                await channel.SendMessageAsync("", false, embed);

                if (log)
                    Console.WriteLine($"[{title}]: {description}");
            }
            catch (Exception ex)
            {
                await SendError(channel, $"{ex.GetType()}: {ex.Message}");
                if (log)
                    Console.WriteLine($"[{ex.GetType()}]: {ex.Message}");
            }
        }

        public static async Task SendError(this IMessageChannel channel, string description, bool log = false)
        {
            try
            {
                var embed = new EmbedBuilder()
                    .WithColor(Color.Red)
                    .WithTitle("Error:")
                    .WithDescription(description)
                    .WithThumbnailUrl(
                        "http://www.myiconfinder.com/uploads/iconsets/128-128-17a5ffdf9ed4846fd11360a2859a5c7f-cross.png")
                    .Build();
                await channel.SendMessageAsync("", false, embed);
                if (log)
                    Console.WriteLine($"[Error]: {description}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{ex.GetType()}]: {ex.Message}");
            }
        }

        public static async Task SendWarning(this IMessageChannel channel, string description, bool log = false)
        {
            try
            {
                var embed = new EmbedBuilder()
                    .WithColor(Color.Orange)
                    .WithTitle("Warning:")
                    .WithDescription(description)
                    .WithThumbnailUrl(
                        "http://www.myiconfinder.com/uploads/iconsets/128-128-0295830eef134e23ed4185483241dc6a-alert.png")
                    .Build();
                await channel.SendMessageAsync("", false, embed);
                if (log)
                    Console.WriteLine($"[Warning]: {description}");
            }
            catch (Exception ex)
            {
                await SendError(channel, $"{ex.GetType()}: {ex.Message}");
            }
        }
    }
}