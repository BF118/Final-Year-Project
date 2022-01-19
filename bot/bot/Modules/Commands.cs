using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using Discord.WebSocket;

namespace bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

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

    }


}
