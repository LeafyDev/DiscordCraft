// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using DiscordCraft.Helpers;

namespace DiscordCraft.HookTypes
{
    internal static class SrvStart
    {
        public static async Task Send() => await WebHook.SendHook("Server Started!");
    }
}