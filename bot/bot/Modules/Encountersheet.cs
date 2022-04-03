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
            string Username { get; }



            //Encounter1 embed
            [Command("encounter1")]
            public async Task encounter1(string time, DateTime starttime)
            {
                //Create Encounter 1 Emojis
                var shieldEmoji = Emoji.Parse(":shield:");
                var dpsEmoji = Emoji.Parse(":crossed_swords:");
                var heartEmoji = Emoji.Parse(":heart:");
                var hatEmoji = Emoji.Parse(":mortar_board:");
                var anyEmoji = Emoji.Parse(":game_die:");

                //Loading screen Embed
                EmbedBuilder Encounter1 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 1 loading", "Please wait")
                .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter1.Build());

                //add reaction emojis to the post
                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(heartEmoji);
                await sent.AddReactionAsync(hatEmoji);
                await sent.AddReactionAsync(anyEmoji);

                var baseTankRole = await sent.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var damageRole = await sent.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var healerRole = await sent.GetReactionUsersAsync(heartEmoji, 100).FlattenAsync();
                var learnerRole = await sent.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();
                var anyRole = await sent.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();

                IEnumerable<string> baseTankUsernames = baseTankRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string baseTanksAsSingleString = string.Join(" ,", baseTankUsernames);
                IEnumerable<string> dpsUsernames = damageRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string dpsAsSingleString = string.Join(" ,", dpsUsernames);
                IEnumerable<string> healerUsernames = healerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string healerAsSingleString = string.Join(" ,", healerUsernames);
                IEnumerable<string> learnerUsernames = learnerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string learnerAsSingleString = string.Join(" ,", learnerUsernames);
                IEnumerable<string> anyRoleUsernames = anyRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string anyRoleAsSingleString = string.Join(" ,", anyRoleUsernames);


                if (baseTanksAsSingleString == string.Empty)
                {
                    baseTanksAsSingleString = ".";
                }
                if (dpsAsSingleString == string.Empty)
                { 
                    dpsAsSingleString = ".";
                }
                if (healerAsSingleString == string.Empty)
                {
                    healerAsSingleString = ".";
                }
                if (learnerAsSingleString == string.Empty)
                {
                    learnerAsSingleString = ".";
                }
                if (anyRoleAsSingleString == string.Empty)
                {
                    anyRoleAsSingleString = ".";
                }








                await sent.ModifyAsync(x =>
                 {
                     EmbedBuilder encounter_edit = new EmbedBuilder()

                    .WithTitle("Test Encounter")
                    .AddField("Time:", starttime)
                    .AddField("Looting:", " test")
                    .AddField("Team size:", " 0/7")
                    .AddField("Reactions:", "Remove your signup and role")
                    .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTanksAsSingleString, true)
                    .AddField("<:crossed_swords:927174860524896276> 1x dps:", dpsAsSingleString,true)
                    .AddField("<:heart:927185322050199612> 1x Healer", healerAsSingleString,true)
                    .AddField("<:game_die:947476766283407370> 1x any role:", anyRoleAsSingleString,true)
                    .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerAsSingleString,true)
                    .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                    .WithCurrentTimestamp()
                    .WithColor(Color.DarkBlue);
                     x.Embed = encounter_edit.Build();
                 });
            }
            //Encounter 2 embed
            [Command("encounter2")]
            public async Task encounter2(string time, DateTime starttime)
            {
                //Creating Encounter 2 Emojis
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
                   .AddField("Time:", starttime)
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

            [Command("encounter3")]
            public async Task encounter3()
            {
                var shieldEmoji = new Emoji("🛡");
                var rainShieldEmoji = new Emoji("🌧️");
                var dpsEmoji = new Emoji("⚔️");
                var shatterEmoji = new Emoji("💥");
                var cleanseEmoji = new Emoji("🧼");
                var firstRealmEmoji = new Emoji("1️⃣");
                var secondRealmEmoji = new Emoji("2️⃣");
                var hatEmoji = new Emoji("🎓");
                var anyEmoji = new Emoji("🎲");

                EmbedBuilder Encounter3 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 3 loading", "Please wait......")
                .AddField("Role", MentionUtils.MentionRole(944968105199796245))
                .WithCurrentTimestamp()
                .WithColor(Color.Purple);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter3.Build());

                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(rainShieldEmoji);
                await sent.AddReactionAsync(shatterEmoji);
                await sent.AddReactionAsync(cleanseEmoji);
                await sent.AddReactionAsync(firstRealmEmoji);
                await sent.AddReactionAsync(secondRealmEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(hatEmoji);
                await sent.AddReactionAsync(anyEmoji);


                var baseTankRole = await Context.Message.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var shieldRole = await Context.Message.GetReactionUsersAsync(rainShieldEmoji, 100).FlattenAsync();
                var shatterRole= await Context.Message.GetReactionUsersAsync(shatterEmoji, 100).FlattenAsync();
                var cleanseRole = await Context.Message.GetReactionUsersAsync(cleanseEmoji, 100).FlattenAsync();
                var firstRealmRole = await Context.Message.GetReactionUsersAsync(firstRealmEmoji, 100).FlattenAsync();
                var secondRealmRole = await Context.Message.GetReactionUsersAsync(secondRealmEmoji, 100).FlattenAsync();
                var damageRole = await Context.Message.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var anyRole = await Context.Message.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();
                var learnerRole = await  Context.Message.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();



                await (sent).ModifyAsync(x =>
                {
                    EmbedBuilder encounter_edit = new EmbedBuilder()

                   .WithTitle("Test Encounter")
                   .AddField("Time:", "starttime")
                   .AddField("Looting:", " test")
                   .AddField("Team size:", " 0/7")
                   .AddField("Reactions:", "Remove your signup and role")
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTankRole,true)       
                   .AddField("<:cloud_rain:947534430891827320> 1x Rain Shield:", shieldRole, true)
                   .AddField("<:boom:947534430891827320> 1x Shatter:", shatterRole, true)
                   .AddField("<:soap:947534430891827320> 1x Cleanse:", cleanseRole, true)
                   .AddField("<:one:947534430891827320> 1x 1/3 Realm:", firstRealmRole, true)
                   .AddField("<:two:947534430891827320> 1x 2/4 Realm:", secondRealmRole, true)
                   .AddField("<:crossed_swords:927174860524896276> 1x dps:", damageRole, true)
                   .AddField("<:game_die:947476766283407370> 1x any role:", anyRole, true)
                   .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerRole, true)
                   .AddField("Role", MentionUtils.MentionRole(944968105199796245))
                   .WithCurrentTimestamp()
                   .WithColor(Color.DarkPurple);
                    x.Embed = encounter_edit.Build();
                });
            }
            [Command("encounter4")]
            public async Task encounter4(string time, DateTime starttime)
            {
                
                var shieldEmoji = new Emoji("🛡");
                var chinnerEmoji = new Emoji("🐿️");
                var hammerEmoji = new Emoji("🔨");
                var uMinionEmoji = new Emoji("🇺");
                var gMinionEmoji = new Emoji("🇬");
                var cMinionEmoji = new Emoji("🇨");
                var fMinionEmoji = new Emoji("🇫");
                var dpsEmoji = new Emoji("⚔️");
                var hatEmoji = new Emoji("🎓");
                var anyEmoji = new Emoji("🎲");

                EmbedBuilder Encounter4 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 4 loading", "Please wait")
                .AddField("Role", MentionUtils.MentionRole(953223221807824898))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkTeal);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter4.Build());

                //add reaction emojis to the post
                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(chinnerEmoji);
                await sent.AddReactionAsync(hammerEmoji);   
                await sent.AddReactionAsync(uMinionEmoji); 
                await sent.AddReactionAsync(gMinionEmoji);
                await sent.AddReactionAsync(cMinionEmoji);
                await sent.AddReactionAsync(fMinionEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(hatEmoji);
                await sent.AddReactionAsync(anyEmoji);

                var baseTankRole = await Context.Message.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var chinnerRole = await Context.Message.GetReactionUsersAsync(chinnerEmoji, 100).FlattenAsync();
                var hammerRole = await Context.Message.GetReactionUsersAsync(hammerEmoji, 100).FlattenAsync();
                var uMinionRole = await Context.Message.GetReactionUsersAsync(uMinionEmoji, 100).FlattenAsync();
                var gMinionRole = await Context.Message.GetReactionUsersAsync(gMinionEmoji, 100).FlattenAsync();
                var cMinionRole = await Context.Message.GetReactionUsersAsync(cMinionEmoji, 100).FlattenAsync();
                var fMinionRole = await Context.Message.GetReactionUsersAsync(fMinionEmoji, 100).FlattenAsync();
                var dpsRole = await Context.Message.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var learnerRole = await Context.Message.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();
                var anyRole = await Context.Message.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();   

                await (sent).ModifyAsync(x =>
                {
                    EmbedBuilder encounter_edit = new EmbedBuilder()

                   .WithTitle("Test Encounter")
                   .AddField("Time:", starttime)
                   .AddField("Looting:", " test")
                   .AddField("Team size:", " 0/7")
                   .AddField("Reactions:", "Remove your signup and role")
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTankRole,true)
                   .AddField("<:chipmunk:953223520446464060> 1x chinner:", chinnerRole,true)
                   .AddField("<:hammer:953223520446464060> 1x hammer:", hammerRole,true)
                   .AddField("<:regional_indicator_u:953229494863429652> 1x U Minion:", uMinionRole,true)
                   .AddField("<:regional_indicator_g:953229494863429652> 1x G Minion:", gMinionRole,true)
                   .AddField("<:regional_indicator_c:953229494863429652> 1x C Minion:", cMinionRole,true)
                   .AddField("<:regional_indicator_f:953229494863429652> 1x F Minion:", fMinionRole,true)
                   .AddField("<:crossed_swords:927174860524896276> 1x dps:", dpsRole,true)
                   .AddField("<:game_die:947476766283407370> 1x any role:", anyRole,true)
                   .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerRole,true)
                   .AddField("Role", MentionUtils.MentionRole(953223221807824898))
                   .WithCurrentTimestamp()
                   .WithColor(Color.DarkPurple);
                    x.Embed = encounter_edit.Build();
                });



            }

        }
    }
}









