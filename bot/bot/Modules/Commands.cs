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


        }
        [Command("welcome")]
        public async Task welcome(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)
        {

            

            var encounter1 = new Emoji("1️⃣");
            var encounter2 = new Emoji("2️⃣");
            var encounter3 = new Emoji("3️⃣");



            EmbedBuilder welcome = new EmbedBuilder()

                .WithTitle("welcome to the server")
                .WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl() ?? Context.Client.CurrentUser.GetDefaultAvatarUrl())
                .WithColor(Color.DarkBlue);


            var welcomemessage = await Context.Channel.SendMessageAsync("", false, welcome.Build());

            await welcomemessage.AddReactionAsync(encounter1);
            await welcomemessage.AddReactionAsync(encounter2);
            await welcomemessage.AddReactionAsync(encounter3);


            var user = await Context.Channel.GetUserAsync(reaction.UserId) as SocketGuildUser;
            if (reaction.Emote.Name.Equals("1️⃣"))
            {
                await user.AddRoleAsync(roleId: 933000592362725396);


            }



            await user.AddRoleAsync(roleId: 933000592362725396);
            
            await user.RemoveRoleAsync(roleId: 933000592362725396);

        }

    }


}
