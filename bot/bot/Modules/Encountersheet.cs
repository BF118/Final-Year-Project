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
            string Discriminator { get; }

            //Encounter1 embed
            [Command("encounter1")]
            public async Task encounter1()//string time, DateTime starttime)
            {
                var shieldEmoji = new Emoji("🛡");
                var dpsEmoji = new Emoji("⚔️");
                var heartEmoji = new Emoji("❤️");
                var hatEmoji = new Emoji("🎓");
                var anyEmoji = new Emoji("🎲");

                EmbedBuilder Encounter1 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 1 loading","Please wait")
                .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter1.Build());

                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(heartEmoji);
                await sent.AddReactionAsync(hatEmoji);
                await sent.AddReactionAsync(anyEmoji);

                var baseTankRole = await Context.Message.GetReactionUsersAsync(shieldEmoji, 10).FlattenAsync();
                var damageRole = await Context.Message.GetReactionUsersAsync(dpsEmoji, 10).FlattenAsync();
                var healerRole = await Context.Message.GetReactionUsersAsync(heartEmoji, 10).FlattenAsync();
                var learnerRole = await Context.Message.GetReactionUsersAsync(hatEmoji, 10).FlattenAsync();
                var anyRole = await Context.Message.GetReactionUsersAsync(anyEmoji, 10).FlattenAsync();

                

                await (sent).ModifyAsync(x =>
                 {
                     EmbedBuilder encounter_edit = new EmbedBuilder()

                    .WithTitle("Test Encounter")
                    .AddField("Time:", "starttime")
                    .AddField("Looting:", " test")
                    .AddField("Team size:", " 0/7")
                    .AddField("Reactions:", "Remove your signup and role")
                    .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTankRole)
                    .AddField("<:crossed_swords:927174860524896276> 1x dps:", damageRole)
                    .AddField("<:heart:927185322050199612> 1x Healer", healerRole)
                    .AddField("<:game_die:947476766283407370> 1x any role:", anyRole)
                    .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerRole)
                    .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                    .WithCurrentTimestamp()
                    .WithColor(Color.DarkBlue);
                     x.Embed = encounter_edit.Build();
                 });


                if (!(baseTankRole is null))
                {

                    var User = baseTankRole;

                    await (sent).ModifyAsync(x =>
                    {
                        EmbedBuilder encounter_edit = new EmbedBuilder()

                       .WithTitle("Test Encounter")
                       .AddField("Time:", "starttime")
                       .AddField("Looting:", " test")
                       .AddField("Team size:", " 0/7")
                       .AddField("Reactions:", "Remove your signup and role")
                       .AddField("<:shield:927174765058326558> 1x Base Tank:", User)
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


            //Encounter 2 embed
            [Command("encounter2")]
            public async Task encounter2()
            {
                var shieldEmoji = new Emoji("🛡");
                var dpsEmoji = new Emoji("⚔️");
                var bombEmoji = new Emoji("💣");
                var toplureEmoji = new Emoji("⬆️");
                var hatEmoji = new Emoji("🎓");
                var anyEmoji = new Emoji("🎲");


                EmbedBuilder Encounter2 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 2 loading", "Please wait......")
                .AddField("Role", MentionUtils.MentionRole(944968068113772594))
                .WithCurrentTimestamp()
                .WithColor(Color.LightOrange);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter2.Build());

                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(bombEmoji);
                await sent.AddReactionAsync(toplureEmoji);
                await sent.AddReactionAsync(hatEmoji);
                await sent.AddReactionAsync(anyEmoji);


                var baseTankRole = await Context.Message.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var damageRole = await Context.Message.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var bombtankRole = await Context.Message.GetReactionUsersAsync(bombEmoji, 100).FlattenAsync();
                var toplureRole = await Context.Message.GetReactionUsersAsync(toplureEmoji, 100).FlattenAsync();
                var learnerRole = await Context.Message.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();
                var anyroleRole = await Context.Message.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();

                await (sent).ModifyAsync(x =>
                {
                    EmbedBuilder encounter_edit = new EmbedBuilder()

                   .WithTitle("Encounter2")
                   .AddField("Time:", "starttime")
                   .AddField("Looting:", "Energies and weapons are split between team mates")
                   .AddField("Team size:", "+1")
                   .AddField("Reactions:", "Remove your signup and role")
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTankRole)
                   .AddField("<:crossed_swords:927174860524896276> 4x dps:", damageRole, true)
                   .AddField("<:heart:927185322050199612> 1x bomb tank", bombtankRole, true)
                   .AddField("<:mortar_board:927185690867937330> 1x top lure:", toplureRole, true)
                   .AddField("<:game_die:947476766283407370> 1x any role:", anyroleRole, true)
                   .AddField("<:arrow_up:947161060253769758> 1x learner:", learnerRole, true)
                   .AddField("Role", MentionUtils.MentionRole(944968068113772594))
                   .WithCurrentTimestamp()
                   .WithColor(Color.DarkOrange);
                    x.Embed = encounter_edit.Build();
                });

            }

        }
    }
}









