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
                .WithButton("Click for website",null,ButtonStyle.Link, url: "http://bf118.webhosting.canterbury.ac.uk/");
          

            await ReplyAsync("Click here to be taken to the website", components: builder.Build());
            
        }

    }


}
