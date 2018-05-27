// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using DiscordWebhook;

namespace DiscordCraft.Helpers
{
    internal static class WebHook
    {
        public static async Task SendHook(string content)
        {
            await new Webhook(Config.DiscordHookUrl)
            {
                AvatarUrl = Config.AvatarUrl,
                Username = "SkyFactory",
                Content = content
            }.Send();
        }

        public static async Task SendHook(string AvatarUrl, string Username, string Content)
        {
            await new Webhook(Config.DiscordHookUrl)
            {
                AvatarUrl = AvatarUrl,
                Username = Username,
                Content = Content
            }.Send();
        }

        public static async Task SendEmbedHook(string Username, string AuthorIconUrl, string AuthorName, int color, string description)
        {
            await new Webhook(Config.DiscordHookUrl)
            {
                AvatarUrl = Config.AvatarUrl,
                Username = Username,
                Embeds = new List<Embed>
                {
                    new Embed
                    {
                        Author = new EmbedAuthor
                        {
                            IconUrl = AuthorIconUrl,
                            Name = AuthorName
                        },
                        Color = color,
                        Description = description
                    }
                }
            }.Send();
        }
    }
}