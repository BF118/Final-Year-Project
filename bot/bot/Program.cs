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
        int i = 0;
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
                .AddSingleton<PostedSignupSheets>()
                .BuildServiceProvider();

            _client.UserJoined += UserJoined;

            string token = Environment.GetEnvironmentVariable("Token");
            _client.Log += _client_Log;

            _client.ReactionAdded += ReactionAdded_Event;
            _client.ReactionRemoved += ReactionRemoved_Event;

            await RegisterCommandAsync();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task ReactionRemoved_Event(Cacheable<IUserMessage, ulong> userid, Cacheable<IMessageChannel, ulong> msgid, SocketReaction reaction)
        {
            var blankSignUp = "\u200B";
            if (!reaction.User.Value.IsBot)
            {
                var postedSignupSheets = _services.GetRequiredService<PostedSignupSheets>();
                if (postedSignupSheets.SignupSheets.Any(x => x.MessagesId == userid.Id && x.ChannelsId == msgid.Id))
                {
                    var message = await userid.GetOrDownloadAsync();

                    var newEmbedBuilder = message.Embeds.First().ToEmbedBuilder();

                    #region Remove general roles
                    if (reaction.Emote.Name == "🛡️")//Get basetank reaction
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:shield:927174765058326558> 1x Base Tank:");
                        newEmbedBuilder.Fields[4].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i+"/7";
                    }
                    if (reaction.Emote.Name == "⚔️")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:crossed_swords:927174860524896276> 1x DPS:");
                        newEmbedBuilder.Fields[5].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "🎲")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:game_die:947476766283407370> 1x Any role:");
                        i--;
                        newEmbedBuilder.Fields[6].Value = blankSignUp;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "🎓")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:mortar_board:927185690867937330> 1x Learner:");
                        i--;
                        newEmbedBuilder.Fields[7].Value = blankSignUp;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    #endregion

                    #region Encounter2 specific remove
                    if (reaction.Emote.Name == "💣")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:bomb:961993455092002886> 1x bomb tank");
                        newEmbedBuilder.Fields[8].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "⬆️")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:arrow_up:947161060253769758> 1x top lure:");
                        newEmbedBuilder.Fields[9].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }

                    #endregion

                    #region Encounter3 Specific Remove
                    if (reaction.Emote.Name == "🌧️")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:cloud_rain:947534430891827320> 1x Rain Shield:");
                        newEmbedBuilder.Fields[8].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "💥")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:boom:947534430891827320> 1x Shatter:");
                        newEmbedBuilder.Fields[9].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "🧼")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:soap:947534430891827320> 1x Cleanse: 1x Shatter:");
                        newEmbedBuilder.Fields[10].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "1️⃣")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:one:947534430891827320> 1x 1/3 Realm:");
                        newEmbedBuilder.Fields[11].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "2️⃣")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:two:947534430891827320> 1x 2/4 Realm:");
                        newEmbedBuilder.Fields[12].Value = blankSignUp;
                        i--;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    #endregion

                    await message.ModifyAsync(x => x.Embed = newEmbedBuilder.Build());
                }

            }
            Console.WriteLine("role removed");
            throw new NotImplementedException();
        }

        private async Task ReactionAdded_Event(Cacheable<IUserMessage, ulong> userid, Cacheable<IMessageChannel, ulong> msgid, SocketReaction reaction)
        {           
            if (!reaction.User.Value.IsBot)
            {
                var postedSignupSheets = _services.GetRequiredService<PostedSignupSheets>();
                if (postedSignupSheets.SignupSheets.Any(x => x.MessagesId == userid.Id && x.ChannelsId == msgid.Id))
                {

                    var message = await userid.GetOrDownloadAsync();

                    var newEmbedBuilder = message.Embeds.First().ToEmbedBuilder();

                    #region add General Roles
                    if (reaction.Emote.Name == "🛡️")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:shield:927174765058326558> 1x Base Tank:");
                        newEmbedBuilder.Fields[4].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i+"/7";
                    }
                    if (reaction.Emote.Name == "⚔️")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:crossed_swords:927174860524896276> 1x DPS:");
                        newEmbedBuilder.Fields[5].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i+"/7";
                    }
                    if (reaction.Emote.Name == "🎲")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:game_die:947476766283407370> 1x Any role:");
                        i++;
                        newEmbedBuilder.Fields[6].Value = reaction.User.Value.Username;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "🎓")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:mortar_board:927185690867937330> 1x Learner:");
                        i++;
                        newEmbedBuilder.Fields[7].Value = reaction.User.Value.Username;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    #endregion

                    #region Encounter2 specific roles add
                    if(reaction.Emote.Name == "💣")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:bomb:961993455092002886> 1x bomb tank");
                        newEmbedBuilder.Fields[8].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "⬆️")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:arrow_up:947161060253769758> 1x top lure:");
                        newEmbedBuilder.Fields[9].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    #endregion

                    #region Encounter3 Specific Roles Add
                    if (reaction.Emote.Name == "🌧️")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:cloud_rain:947534430891827320> 1x Rain Shield:");
                        newEmbedBuilder.Fields[8].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "💥")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:boom:947534430891827320> 1x Shatter:");
                        newEmbedBuilder.Fields[9].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "🧼")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:soap:947534430891827320> 1x Cleanse: 1x Shatter:");
                        newEmbedBuilder.Fields[10].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "1️⃣")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:one:947534430891827320> 1x 1/3 Realm:");
                        newEmbedBuilder.Fields[11].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }
                    if (reaction.Emote.Name == "2️⃣")
                    {
                        newEmbedBuilder.Fields.Select(x => x.Name == "<:two:947534430891827320> 1x 2/4 Realm:");
                        newEmbedBuilder.Fields[12].Value = reaction.User.Value.Username;
                        i++;
                        newEmbedBuilder.Fields[2].Value = i + "/7";
                    }

                    #endregion
                    
                    
                    
                    
                    
                    await message.ModifyAsync(x => x.Embed = newEmbedBuilder.Build());

      

                }
            }


            Console.WriteLine("Signupadded");
            throw new NotImplementedException();
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
            if (message.HasStringPrefix("!", ref argPos))
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
