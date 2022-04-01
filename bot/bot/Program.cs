using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Net.WebSockets;
using Discord.Net.Rest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace bot
{
    class Program
    {
        
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
       

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        
        

        public async Task RunBotAsync()
        {

            var config = new DiscordSocketConfig()
            {

                GatewayIntents = GatewayIntents.All
            };

            _client = new DiscordSocketClient(config);
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            _client.UserJoined += UserJoined;

            string token = Environment.GetEnvironmentVariable("Token");
            _client.Log += _client_Log;

            await RegisterCommandAsync();
            
            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;

        }
        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }


        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if(message.HasStringPrefix("!",ref argPos))
            {

                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);

            }
        }
         public async Task UserJoined(SocketGuildUser user)
         {
            
            await user.SendMessageAsync("Welcome to the server" +
                "\n this server is for creating and join teams for bossing encounters" +
                "\n have a look through the server to see how to sign up to an event" +
                "\n if you need any help with the bot and its command type !help which will give you a handy list of commands" +
                "\n I hope you enjoy your stay!!!");

            await user.AddRoleAsync(958001530139721760);
         }
        
    }


}
