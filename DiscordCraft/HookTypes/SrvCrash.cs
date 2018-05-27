﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using DiscordCraft.WebHooks;

namespace DiscordCraft.HookTypes
{
    internal static class SrvCrash
    {
        public static async void Send()
        {
            await DiscordHook.Send(new WebHookMessage
            {
                AvatarUrl = DiscordHook._avatarUrl,
                Content = "Server Crashed!",
                Username = "SkyFactory"
            });
        }
    }
}