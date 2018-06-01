// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using DiscordCraft.Helpers;

// ReSharper disable UnusedMember.Global

namespace DiscordCraft.Modules
{
    public class AboutCMD : ModuleBase<SocketCommandContext>
    {
        [Command("about")]
        public async Task About() => await ReplyAsync(
                                         "I am a Discord Webhook to Webhook bridge for Minecraft integration by LeafyDev," +
                                         " find out more here: https://github.com/LeafyDev/DiscordCraft");

        [Command("ip"), Alias("map")]
        public async Task EchoIp() => await Context.Channel.SendEmbedMessage(Color.DarkGreen, "Server information:",
                                          $"Minecraft address: goofygoober.ddns.net{Environment.NewLine}" +
                                          "You can find the Dynamic Minecraft Map here: <http://goofygoober.ddns.net:8123>");

        [Command("stats")]
        public async Task EchoStats()
        {
            var stats = Format.Bold("General info:") + "\n";
            stats += $"Known player count: {Stats.GetPlayerCount()}\n";
            stats += $"Currently playing: {PlayerCount.CurrentPlayers}\n\n";
            /*stats += $"Total game time tracked: {Stats.TotalPlayTime()}\n\n";
            stats += Format.Bold("Longest player:") + "\n";
            stats += Format.Italics(Stats.LongestPlayer().Name) + ": " + Stats.LongestPlayer().Time + "\n";
            stats += Format.Italics(Stats.ShortestPlayer().Name) + ": " + Stats.ShortestPlayer().Time + "\n";*/

            await Context.Channel.SendEmbedMessage(Color.Teal, "Statistics:", stats);
        }
    }
}