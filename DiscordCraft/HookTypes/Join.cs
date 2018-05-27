// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;

using Discord;
using Discord.WebSocket;

using DiscordCraft.WebHooks;

namespace DiscordCraft.HookTypes
{
    internal static class Join
    {
        public static async void Send(SocketUserMessage msg)
        {
            await DiscordHook.Send(new WebHookMessage
            {
                AvatarUrl = DiscordHook._avatarUrl,
                Username = "SkyFactory",
                Embeds = new List<Embed>
                {
                    new EmbedBuilder
                    {
                        Author = new EmbedAuthorBuilder
                        {
                            IconUrl = msg.Author.GetAvatarUrl(),
                            Name = msg.Author.Username
                        },
                        Color = Color.Green,
                        Description = "joined the server!"
                    }.Build()
                }
            });
        }
    }
}