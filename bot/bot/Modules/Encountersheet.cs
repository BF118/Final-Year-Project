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
            public Optional<IUser> User { get; }

          
            [Command("encounter1")]
            public async Task testEncounter()
            {
                var shield = new Emoji("🛡");
                var dps = new Emoji("⚔️");
                var healer = new Emoji("❤️");
                var learner = new Emoji("🎓");

                EmbedBuilder Encounter1 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 1 loading","Please wait")
                .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                .WithCurrentTimestamp()
                .WithColor(Color.Purple);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter1.Build());

                await sent.AddReactionAsync(shield);
                await sent.AddReactionAsync(dps);
                await sent.AddReactionAsync(healer);
                await sent.AddReactionAsync(learner);


                var myid = 380426938432618496;
                var roleencounter1 = Context.Message.GetReactionUsersAsync(shield, 100, null) as SocketGuildUser;
                var role1 = Convert.ToUInt64(roleencounter1);
                var role2 = Convert.ToUInt64(myid);



                await (sent).ModifyAsync(x =>
                 {
                     EmbedBuilder encounter_edit = new EmbedBuilder()

                    .WithTitle("Test Encounter")
                    .AddField("Time:", " n/a")
                    .AddField("Looting:", " test")
                    .AddField("Team size:", " 0/7")
                    .AddField("Reactions:", "Remove your signup and role")
                    .AddField("<:shield:927174765058326558> 1x Base Tank:", MentionUtils.MentionUser(role1))
                    .AddField("<:crossed_swords:927174860524896276> 4x dps:", " .", true)
                    .AddField("<:heart:927185322050199612> 1x Healer", ". ", true)
                    .AddField("<:mortar_board:927185690867937330> 1x Learner:", ".", true)
                    .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                    .WithCurrentTimestamp()
                    .WithColor(Color.DarkBlue);
                     x.Embed = encounter_edit.Build();
                 });
                if((roleencounter1 is null))
                {
                    await (sent).ModifyAsync(x =>
                    {
                        EmbedBuilder encounter_edit = new EmbedBuilder()

                       .WithTitle("Test Encounter")
                       .AddField("Time:", " n/a")
                       .AddField("Looting:", " test")
                       .AddField("Team size:", " 0/7")
                       .AddField("Reactions:", "Remove your signup and role")
                       .AddField("<:shield:927174765058326558> 1x Base Tank:", MentionUtils.MentionUser(role1))
                       .AddField("<:crossed_swords:927174860524896276> 4x dps:", MentionUtils.MentionUser(role2), true)
                       .AddField("<:heart:927185322050199612> 1x Healer", MentionUtils.MentionUser(role1), true)
                       .AddField("<:mortar_board:927185690867937330> 1x Learner:", MentionUtils.MentionUser(role1), true)
                       .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                       .WithCurrentTimestamp()
                       .WithColor(Color.DarkRed);
                        x.Embed = encounter_edit.Build();
                    });
                }

            }
            

        }
    }
}









