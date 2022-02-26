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
            bool IsBot { get; }
          
            [Command("t")]
            public async Task testEncounter()//string time, DateTime starttime)
            {
                var shield = new Emoji("🛡");
                var dps = new Emoji("⚔️");
                var heart = new Emoji("❤️");
                var hat = new Emoji("🎓");

                var basetank = await Context.Message.GetReactionUsersAsync(shield, 10).FlattenAsync();
                var damage = await Context.Message.GetReactionUsersAsync(dps, 10).FlattenAsync();
                var healer = await Context.Message.GetReactionUsersAsync(heart, 10).FlattenAsync();
                var learner = await Context.Message.GetReactionUsersAsync(hat, 10).FlattenAsync();

                EmbedBuilder Encounter1 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 1 loading","Please wait")
                .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                .WithCurrentTimestamp()
                .WithColor(Color.Purple);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter1.Build());

                await sent.AddReactionAsync(shield);
                await sent.AddReactionAsync(dps);
                await sent.AddReactionAsync(heart);
                await sent.AddReactionAsync(hat);

                
                await (sent).ModifyAsync(x =>
                 {
                     EmbedBuilder encounter_edit = new EmbedBuilder()

                    .WithTitle("Test Encounter")
                    .AddField("Time:", "starttime")
                    .AddField("Looting:", " test")
                    .AddField("Team size:", " 0/7")
                    .AddField("Reactions:", "Remove your signup and role")
                    .AddField("<:shield:927174765058326558> 1x Base Tank:", basetank)
                    .AddField("<:crossed_swords:927174860524896276> 4x dps:", damage, true)
                    .AddField("<:heart:927185322050199612> 1x Healer", healer, true)
                    .AddField("<:mortar_board:927185690867937330> 1x Learner:", learner, true)
                    .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                    .WithCurrentTimestamp()
                    .WithColor(Color.DarkBlue);
                     x.Embed = encounter_edit.Build();
                 });

                if ((basetank is null))
                {
                    
                    await (sent).ModifyAsync(x =>
                    {
                        EmbedBuilder encounter_edit = new EmbedBuilder()

                       .WithTitle("Test Encounter")
                       .AddField("Time:", "starttime")
                       .AddField("Looting:", " test")
                       .AddField("Team size:", " 0/7")
                       .AddField("Reactions:", "Remove your signup and role")
                       .AddField("<:shield:927174765058326558> 1x Base Tank:", basetank)
                       .AddField("<:crossed_swords:927174860524896276> 4x dps:", ".", true)
                       .AddField("<:heart:927185322050199612> 1x Healer", ".", true)
                       .AddField("<:mortar_board:927185690867937330> 1x Learner:", ".", true)
                       .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                       .WithCurrentTimestamp()
                       .WithColor(Color.DarkRed);
                        x.Embed = encounter_edit.Build();
                    });
                }

            }
            [Command("encounter2")]
            public async Task encounter2()
            {
                var shield = new Emoji("🛡");
                var dps = new Emoji("⚔️");
                var bombtank = new Emoji("💣");
                var toplure = new Emoji(":947153862664540231:");
                var hat = new Emoji("🎓");


                EmbedBuilder Encounter2 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 1 loading", "Please wait")
                .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                .WithCurrentTimestamp()
                .WithColor(Color.Purple);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter2.Build());

                await sent.AddReactionAsync(shield);
                await sent.AddReactionAsync(dps);
                await sent.AddReactionAsync(bombtank);
                await sent.AddReactionAsync(toplure);
                await sent.AddReactionAsync(hat);


            }

        }
    }
}









