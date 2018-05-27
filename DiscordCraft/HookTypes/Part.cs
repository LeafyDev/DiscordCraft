// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;

using Discord.WebSocket;

using DiscordCraft.WebHooks;

using DiscordWebhook;

namespace DiscordCraft.HookTypes
{
    internal static class Part
    {
        public static async void Send(SocketUserMessage msg)
        {
            await new Webhook(DiscordHook._webhookUrl)
            {
                AvatarUrl = DiscordHook._avatarUrl,
                Username = "SkyFactory",
                Embeds = new List<Embed>
                {
                    new Embed
                    {
                        Author = new EmbedAuthor
                        {
                            IconUrl = msg.Author.GetAvatarUrl(),
                            Name = msg.Author.Username
                        },
                        Color = 16711680,
                        Description = "left the server!"
                    }
                }
            }.Send();
        }
    }
}