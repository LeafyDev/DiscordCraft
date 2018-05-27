// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;

using Discord.WebSocket;

using DiscordCraft.WebHooks;

using DiscordWebhook;

namespace DiscordCraft.HookTypes
{
    internal static class Join
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
                        Color = 65280,
                        Description = "joined the server!"
                    }
                }
            }.Send();
        }
    }
}