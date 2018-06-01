// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using DiscordCraft.Extensions;
using DiscordCraft.Helpers;

// ReSharper disable UnusedMember.Global

namespace DiscordCraft.Modules
{
    public class StatsCMD : ModuleBase<SocketCommandContext>
    {
        [Command("ustats"), Alias("userstats")]
        public async Task Ustats()
        {
            string username;

            switch (Context.User.Id)
            {
                case 106865594376208384:
                    username = "LeafyDev";
                    break;
                case 142307301057888256:
                    username = "Ninnette";
                    break;
                case 190613006768537601:
                    username = "ladyloo17";
                    break;
                case 233997571826253824:
                    username = "SynShawn";
                    break;
                default:
                    await Context.Channel.SendError("No user found.");
                    return;
            }

            var msg = string.Empty;

            if (File.Exists($"stats/{username}.totals.txt"))
            {
                var startedPlaying = File.GetCreationTime($"stats/{username}.totals.txt");

                msg = $"{Format.Bold(username)} has been playing since {Format.Bold($"{startedPlaying:F}")} ({startedPlaying.TimeAgo(DateTime.Now)})";
                // TODO: Add last seen / currently playing
            }

            if(!string.IsNullOrEmpty(msg))
                await Context.Channel.SendEmbedMessage(Color.DarkBlue, "User Statistics:", msg);
        }
    }
}