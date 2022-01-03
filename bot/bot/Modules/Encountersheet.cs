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
            [Command("Encounter1")]
            public async Task testEncounter()
            {
                

                var shield = new Emoji("🛡");
                var dps = new Emoji("⚔️");
                var healer = new Emoji("❤️");
                var learner = new Emoji("🎓");
      
                
                EmbedBuilder Encounter1 = new EmbedBuilder();



                Encounter1.WithTitle("Test Encounter");
                Encounter1.AddField("Time:"," n/a");
                Encounter1.AddField("Looting:"," test");
                Encounter1.AddField("Team size:"," 0/7");
                Encounter1.AddField("Reactions:","Remove your signup and role");
                Encounter1.AddField("<:shield:927174765058326558> 1x Base Tank:", ",",true);
                Encounter1.AddField("<:crossed_swords:927174860524896276> 4x dps:", " .",true);
                Encounter1.AddField("<:heart:927185322050199612> 1x Healer", ". ", true);
                Encounter1.AddField("<:mortar_board:927185690867937330> 1x Learner:", ".", true);

                Encounter1.WithCurrentTimestamp();
                Encounter1.WithColor(Color.Purple);


                var sent = await Context.Channel.SendMessageAsync("", false, Encounter1.Build());



                await sent.AddReactionAsync(shield);
                await sent.AddReactionAsync(dps);
                await sent.AddReactionAsync(healer);
                await sent.AddReactionAsync(learner);
                
            }

        }
    }
}









