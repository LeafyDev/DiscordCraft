// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using DiscordCraft.Helpers;
using DiscordCraft.HookTypes;

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable MemberCanBeMadeStatic.Local

namespace DiscordCraft
{
    internal sealed class Program
    {
        private readonly CommandService _commands = new CommandService();

        private readonly IServiceCollection _map = new ServiceCollection();
        private DiscordSocketClient _client;

        private IServiceProvider _services;

        public static void Main()
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info,
                MessageCacheSize = 50
            });

            _client.Log += Log;

            _services = _map.BuildServiceProvider();

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.MessageReceived += HandleCommandAsync;

            Config.ParseConfig();

            await _client.LoginAsync(TokenType.Bot, Config.DiscordToken);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            if (!(arg is SocketUserMessage msg)) return;

            var context = new SocketCommandContext(_client, msg);

            var pos = 0;

            if (msg.HasCharPrefix(']', ref pos))
            {
                var result = await _commands.ExecuteAsync(context, pos, _services);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                    await msg.Channel.SendMessageAsync(result.ErrorReason);

                return;
            }

            // Whitelist bot-spam
            if (msg.Channel.Id != 449886304117850132) return;

            // Whitelist webhook messages that don't come from ourself
            if (msg.Source != MessageSource.Webhook) return;

            switch (msg.DetectType())
            {
                case MsgType.Message:
                    await Message.Send(msg);
                    break;
                case MsgType.Join:
                    await Join.Send(msg);
                    break;
                case MsgType.Part:
                    await Part.Send(msg);
                    break;
                case MsgType.SrvStart:
                    await SrvStart.Send();
                    break;
                case MsgType.SrvStop:
                    await SrvStop.Send();
                    break;
                case MsgType.SrvCrash:
                    await SrvCrash.Send();
                    break;
                case MsgType.Cmd:
                    await Command.Send(msg);
                    break;
                case MsgType.Death:
                    await Death.Send(msg);
                    break;
                case MsgType.Achievement:
                    break;
                case null:
                    Console.WriteLine("Found null msgType");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}