// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

using Discord.Commands;

using DiscordCraft.HookTypes;

// ReSharper disable UnusedMember.Global

namespace DiscordCraft.Modules
{
    public class TestCMD : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task Test(string type)
        {
            switch (type)
            {
                case "join":
                    await Join.Send(Context.Message);
                    break;
                case "part":
                    await Part.Send(Context.Message);
                    break;
                case "message":
                    await Message.Send(Context.Message);
                    break;
                case "achievement":
                    await Achievement.Send(Context.Message);
                    break;
                case "death":
                    await Death.Send(Context.Message);
                    break;
                case "srvcrash":
                    await SrvCrash.Send();
                    break;
                case "srvstart":
                    await SrvStart.Send();
                    break;
                case "srvstop":
                    await SrvStop.Send();
                    break;
            }
        }
    }
}