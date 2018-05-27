// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;

using Discord.WebSocket;

namespace DiscordCraft.HookTypes
{
    internal static class Parser
    {
        internal static MsgType? DetectType(this SocketUserMessage msg)
        {
            switch (msg.Content)
            {
                case "~JOIN~":
                    return MsgType.Join;
                case "~PART~":
                    return MsgType.Part;
                case "~SRV_START~":
                    return MsgType.SrvStart;
                case "~SRV_STOP~":
                    return MsgType.SrvStop;
                case "~SRV_CRASH~":
                    return MsgType.SrvCrash;
                default:
                    if (msg.Content.StartsWith("~MSG~ ", StringComparison.Ordinal))
                        return MsgType.Message;
                    if (msg.Content.StartsWith("~CMD~ ", StringComparison.Ordinal))
                        return MsgType.Cmd;
                    if (msg.Content.StartsWith("~DEATH~ ", StringComparison.Ordinal))
                        return MsgType.Death;
                    if (msg.Content.StartsWith("~ACHIEVEMENT~ ", StringComparison.Ordinal))
                        return MsgType.Achievement;

                    break;
            }

            return null;
        }
    }

    internal enum MsgType
    {
        Message,
        Join,
        Part,
        SrvStart,
        SrvStop,
        SrvCrash,
        Cmd,
        Death,
        Achievement
    }
}