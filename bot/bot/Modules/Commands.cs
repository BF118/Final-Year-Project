using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using Discord.WebSocket;
using Discord.Net.WebSockets;

namespace bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        public ulong UserId { get; }
        
        [Command("Hello")]
        public async Task Hello()
        {
            await ReplyAsync("Hello there");
        }
        [Command("website")]
        public async Task Spawn()
        {
            var builder = new ComponentBuilder()
                .WithButton("Click for website", null, ButtonStyle.Link, url: "http://bf118.webhosting.canterbury.ac.uk/");
            await ReplyAsync("Click here to be taken to the website", components: builder.Build());

        }
        
        [Command("help")]
        public async Task help()
        {
            EmbedBuilder help = new EmbedBuilder()

            .WithTitle(" = Command List =")
            .AddField("!website", "Shows a button that will take you to the website")
            .AddField("!encounter1", "Brings up sign up sheet for encounter1 as well as button to said sheet")
            .AddField("!encounter2", "Brings up sign up sheet for encounter2 as well as button to said sheet")
            .AddField("!encounter3", "Brings up sign up sheet for encounter3 as well as button to said sheet")
            .AddField("!encounter4", "Brings up sign up sheet for encounter4 as well as button to said sheet")
            .WithColor(Color.Green);

            var sent = await Context.Channel.SendMessageAsync("", false, help.Build());
        }
        [Command("purge")]
        public async Task purge()
        {
            var messages = Context.Channel.GetMessagesAsync(1000).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }
        [Command("welcome")]
        public async Task welcome()
        {
            var encounter1 = new Emoji("1️⃣");
            var encounter2 = new Emoji("2️⃣");
            var encounter3 = new Emoji("3️⃣");

            ulong roleid1 = 933000592362725396;
            ulong roleid2 = 944968068113772594;
            ulong roleid3 = 944968105199796245;

            var encounter1role = Context.Guild.GetRole(roleid1);
            var encounter2role = Context.Guild.GetRole(roleid2);
            var encounter3role = Context.Guild.GetRole(roleid3);

            EmbedBuilder welcome = new EmbedBuilder()

                .WithTitle("welcome to the server")
                .AddField("To get assigned a role for the encounter you want to do","!")
                .AddField("Type !encounterrolen where n is the encounter you want","!")
                .AddField("All avaiable encounters can be seen with the reactions on this post","!")
                .WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl() ?? Context.Client.CurrentUser.GetDefaultAvatarUrl())
                .WithColor(Color.DarkBlue);


            var welcomemessage = await Context.Channel.SendMessageAsync("", false, welcome.Build());

            await welcomemessage.AddReactionAsync(encounter1);
            await welcomemessage.AddReactionAsync(encounter2);
            await welcomemessage.AddReactionAsync(encounter3);

            var roleencounter1 = Context.Message.GetReactionUsersAsync(encounter1, 100, null);
            var roleencounter2 = Context.Message.GetReactionUsersAsync(encounter2, 100, null);
            var roleencounter3 = Context.Message.GetReactionUsersAsync(encounter3, 100, null); 
        }
        [Command("encounterrole1")]
        public async Task encounterrole1()
        {

            await ((SocketGuildUser)Context.User).AddRoleAsync(933000592362725396);

            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach(var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }
        [Command("encounterrole2")]
        public async Task encounterrole2()
        {
            await ((SocketGuildUser)Context.User).AddRoleAsync(944968068113772594);
            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }
        [Command("encounterrole3")]
        public async Task encounterrole3()
        {
            await ((SocketGuildUser)Context.User).AddRoleAsync(944968105199796245);
            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }
    }
        



    
}



