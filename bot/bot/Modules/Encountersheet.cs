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
            [Command("encounter1")]
            public async Task testEncounter()
            {
                

                var shield = new Emoji("🛡");
                var dps = new Emoji("⚔️");
                var healer = new Emoji("❤️");
                var learner = new Emoji("🎓");
      
                
                EmbedBuilder Encounter1 = new EmbedBuilder()



                .WithTitle("Test Encounter")
                .AddField("Time:"," n/a")
                .AddField("Looting:"," test")
                .AddField("Team size:"," 0/7")
                .AddField("Reactions:","Remove your signup and role")
                .AddField("<:shield:927174765058326558> 1x Base Tank:", ",",true)
                .AddField("<:crossed_swords:927174860524896276> 4x dps:", " .",true)
                .AddField("<:heart:927185322050199612> 1x Healer", ". ", true)
                .AddField("<:mortar_board:927185690867937330> 1x Learner:", ".", true)
                .AddField("Roles", string.Join(" ", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)))
                .WithCurrentTimestamp()
                .WithColor(Color.Purple);


                var sent = await Context.Channel.SendMessageAsync("", false, Encounter1.Build());



                await sent.AddReactionAsync(shield);
                await sent.AddReactionAsync(dps);
                await sent.AddReactionAsync(healer);
                await sent.AddReactionAsync(learner);
                
            }

        }
    }
}









