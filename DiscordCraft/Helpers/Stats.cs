// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiscordCraft.Helpers
{
    internal static class Stats
    {
        private const string statsDir = "stats/";
        private const string playerListFile = "players.txt";
        private const string playersFile = statsDir + playerListFile;

        public static List<string> GetPlayerList() => File.ReadAllLines(playersFile).ToList();

        public static bool PlayerExists(string username) => GetPlayerList().Contains(username);

        public static int GetPlayerCount() => File.ReadAllLines(playersFile).ToList().Count;

        public static void AddPlayer(string username)
        {
            if (!PlayerExists(username))
                File.AppendAllText(playersFile, username + Environment.NewLine);
        }

        public static void StartPlaying(string username)
        {
            var path = $"{statsDir}{username}.txt";
            var totalsPath = $"{statsDir}{username}.total.txt";

            if (!File.Exists(path)) File.Create(path).Close();
            if (!File.Exists(path)) File.Create(totalsPath).Close();
        }

        public static void StopPlaying(string username)
        {
            var path = $"{statsDir}{username}.total.txt";

            var timeStarted = File.GetCreationTime($"{statsDir}{username}.txt");
            var timeStopped = DateTime.Now;

            var timeToAdd = timeStopped - timeStarted;

            TimeSpan.TryParse(File.ReadAllText(path).Replace("\n", ""), out var timeOnRecord);

            var newTime = timeToAdd + timeOnRecord;

            File.WriteAllText(path, newTime.ToString());
        }

        public static TimeSpan GetPlayTime(string username)
        {
            var ret = TimeSpan.Zero;

            var path = $"{statsDir}{username}.total.txt";

            if (File.Exists(path)) TimeSpan.TryParse(File.ReadAllText(path).Replace("\n", ""), out ret);

            return ret;
        }
    }
}