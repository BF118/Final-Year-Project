using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
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
    }

}
