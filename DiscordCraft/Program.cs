using System;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using DiscordCraft.HookTypes;
using DiscordCraft.WebHooks;

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable MemberCanBeMadeStatic.Local

namespace DiscordCraft
{
    internal sealed class Program
    {
        private DiscordSocketClient _client;
        private readonly CommandService _commands = new CommandService();

        private readonly IServiceCollection _map = new ServiceCollection();

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

            await _client.LoginAsync(TokenType.Bot, "NDQ3NzczNzU5MTczMTY1MDg2.Det_ag.csj5ITxpUZga3xqTdCc63DIpVxs");
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
            if (msg.Source != MessageSource.Webhook || msg.Author.Username == "SkyFactory") return;

            var msgType = msg.DetectType();

            switch (msgType)
            {
                case MsgType.Message:
                    break;
                case MsgType.Join:
                    Join.Send(msg);
                    break;
                case MsgType.Part:
                    Part.Send(msg);
                    break;
                case MsgType.SrvStart:
                    SrvStart.Send();
                    break;
                case MsgType.SrvStop:
                    SrvStop.Send();
                    break;
                case MsgType.SrvCrash:
                    SrvCrash.Send();
                    break;
                case MsgType.Cmd:
                    break;
                case MsgType.Death:
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
