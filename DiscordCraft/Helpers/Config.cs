// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.IO;

namespace DiscordCraft.Helpers
{
    internal static class Config
    {
        public static string AvatarUrl { get; private set; }
        public static string DiscordToken { get; private set; }
        public static string DiscordHookUrl { get; private set; }

        public static void ParseConfig()
        {
            var configFile = File.ReadAllLines("config.txt");
            DiscordToken = configFile[0];
            DiscordHookUrl = configFile[1];
            AvatarUrl = configFile[2];
        }
    }
}