using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.IO;
using Discord;
using Discord.WebSocket;
using System.Windows.Forms;


namespace bot.Modules
{
    class Encountersheet
    {
        public class Commands : ModuleBase<SocketCommandContext>
        {
            [Command("Test")]
            public async Task testEncounter()
            {
                

                var SMILE = new Emoji(":smile:922137680161148958");
      

                EmbedBuilder Aod = new EmbedBuilder();


                Aod.WithTitle("Test Example");
                Aod.AddField("Time:"," n/a");
                Aod.AddField("Looting:"," Test");
                Aod.AddField("Team size:"," 0/7");
                Aod.AddField("Reactions:","Remove your signup and role");
                Aod.AddField("<:bt:732207759122104370> 1x Base Tank:",",",true);
                Aod.AddField("<:swh:731181630361960560> 1x Hammer:"," .",true);
                Aod.AddField("<:mt:732207758711062538> 4x Mt", ". ", true);
                Aod.AddField("<:learner:732207758648279051> 1x Learner:", ".", true);

                Aod.WithCurrentTimestamp();
                Aod.WithColor(Color.Purple);


                var sent = await Context.Channel.SendMessageAsync("", false, Aod.Build());
                
                
                
                await sent.AddReactionAsync(SMILE);

                
            }

        }
    }
}









