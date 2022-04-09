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
    public class Encountersheet
    {
        public class Commands : ModuleBase<SocketCommandContext>
        {
            
            PostedSignupSheets PostedSignupSheets { get; }

            public Commands(PostedSignupSheets postedSignupSheets)
            {
                PostedSignupSheets = postedSignupSheets ?? throw new ArgumentNullException(nameof(postedSignupSheets));
            }
            public string blankSignUp = "\u200B";
            
            
            
            
            //Encounter1 embed
            [Command("encounter1")]
            public async Task encounter1(string time, DateTime starttime)
            {

                #region Create Reactions Encounter1
                //Create Encounter 1 Emojis
                var shieldEmoji = Emoji.Parse(":shield:");
                var dpsEmoji = Emoji.Parse(":crossed_swords:");
                var hatEmoji = Emoji.Parse(":mortar_board:");
                var anyEmoji = Emoji.Parse(":game_die:");
                #endregion

                #region Loading Screen
                //Loading screen Embed
                EmbedBuilder Encounter1 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 1 loading", "Please wait")
                .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter1.Build());
                #endregion

                #region Add reactions
                //add reaction emojis to the post
                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(anyEmoji);
                await sent.AddReactionAsync(hatEmoji);
                #endregion

                #region Get User Reactions Encounter1
                var baseTankRole = await sent.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var damageRole = await sent.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var anyRole = await sent.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();
                var learnerRole = await sent.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();
                #endregion

                #region Convert role to string
                IEnumerable<string> baseTankUsernames = baseTankRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string baseTanksAsSingleString = string.Join(" ,", baseTankUsernames);
                IEnumerable<string> dpsUsernames = damageRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string dpsAsSingleString = string.Join(" ,", dpsUsernames);
                IEnumerable<string> anyRoleUsernames = anyRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string anyRoleAsSingleString = string.Join(" ,", anyRoleUsernames);
                IEnumerable<string> learnerUsernames = learnerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string learnerAsSingleString = string.Join(" ,", learnerUsernames);
                #endregion

                #region empty signup
                if (baseTanksAsSingleString == string.Empty)
                {
                    baseTanksAsSingleString = blankSignUp;
                }
                if (dpsAsSingleString == string.Empty)
                {
                    dpsAsSingleString = blankSignUp;
                }
                if (learnerAsSingleString == string.Empty)
                {
                    learnerAsSingleString = blankSignUp;
                }
                if (anyRoleAsSingleString == string.Empty)
                {
                    anyRoleAsSingleString = blankSignUp;
                }
                #endregion

                #region Modified Signup Encounter1
                await sent.ModifyAsync(x =>
                 {
                     EmbedBuilder encounter_edit = new EmbedBuilder()

                    .WithTitle("Test Encounter")
                    .AddField("Time:", starttime)
                    .AddField("Looting:", " test")
                    .AddField("Team size:", "0/7")
                    .AddField("Reactions:", "Remove your signup and role")
                    .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTanksAsSingleString, true)
                    .AddField("<:crossed_swords:927174860524896276> 1x DPS:", dpsAsSingleString, true)
                    .AddField("<:game_die:947476766283407370> 1x Any role:", anyRoleAsSingleString, true)
                    .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerAsSingleString, true)
                    .AddField("Role", MentionUtils.MentionRole(933000592362725396))
                    .WithCurrentTimestamp()
                    .WithColor(Color.DarkBlue);
                     x.Embed = encounter_edit.Build();
                 });
                #endregion

                #region Get signup ID's

                var signupSheet = new SignupSheet(sent.Id, Context.Channel.Id, Context.Guild.Id);

                PostedSignupSheets.AddSignupSheet(signupSheet);

                #endregion

            }
            //Encounter 2 embed
            [Command("encounter2")]
            public async Task encounter2(string time, DateTime starttime)
            {
                #region Create Encounter2 Emojis
                //Creating Encounter 2 Emojis
                var shieldEmoji = Emoji.Parse(":shield:");
                var dpsEmoji = Emoji.Parse(":crossed_swords:");
                var anyEmoji = Emoji.Parse(":game_die:");
                var hatEmoji = Emoji.Parse(":mortar_board:");         
                var bombEmoji = Emoji.Parse(":bomb:");
                var toplureEmoji = Emoji.Parse(":arrow_up:");
                #endregion

                #region Loading Screen
                EmbedBuilder Encounter2 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 2 loading", "Please wait......")
                .AddField("Role", MentionUtils.MentionRole(944968068113772594))
                .WithCurrentTimestamp()
                .WithColor(Color.LightOrange);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter2.Build());
                #endregion

                #region add Reaction Encounter2
                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(anyEmoji);
                await sent.AddReactionAsync(hatEmoji);
                await sent.AddReactionAsync(bombEmoji);
                await sent.AddReactionAsync(toplureEmoji);
                #endregion

                #region Get User reactions Encounter2
                var baseTankRole = await Context.Message.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var damageRole = await Context.Message.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var anyroleRole = await Context.Message.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();
                var learnerRole = await Context.Message.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync(); 
                var bombtankRole = await Context.Message.GetReactionUsersAsync(bombEmoji, 100).FlattenAsync();
                var toplureRole = await Context.Message.GetReactionUsersAsync(toplureEmoji, 100).FlattenAsync();
                #endregion

                #region Convert roles to string Encounter2
                IEnumerable<string> baseTankUsernames = baseTankRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string baseTanksAsSingleString = string.Join(" ,", baseTankUsernames);
                IEnumerable<string> dpsUsernames = damageRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string dpsAsSingleString = string.Join(" ,", dpsUsernames);
                IEnumerable<string> anyRoleUsernames = anyroleRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string anyRoleAsSingleString = string.Join(" ,", anyRoleUsernames);
                IEnumerable<string> learnerUsernames = learnerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string learnerAsSingleString = string.Join(" ,", learnerUsernames);
                IEnumerable<string> bombTankUsernames = bombtankRole.Where(x =>x.IsBot == false).Select(user => user.Username);
                string bombTankAsSingleString = string.Join(" ,", bombTankUsernames);
                IEnumerable<string> topLureUsernames = toplureRole.Where(x => x.IsBot == false).Select(user => user.Username);  
                string topLureAsSingleString = string.Join(",",topLureUsernames);
                #endregion

                #region Empty Signup Encounter2
                if (baseTanksAsSingleString == string.Empty)
                {
                    baseTanksAsSingleString = blankSignUp;
                }
                if (dpsAsSingleString == string.Empty)
                {
                    dpsAsSingleString = blankSignUp;
                }
                if (learnerAsSingleString == string.Empty)
                {
                    learnerAsSingleString = blankSignUp;
                }
                if (anyRoleAsSingleString == string.Empty)
                {
                    anyRoleAsSingleString = blankSignUp;
                }
                if(bombTankAsSingleString == string.Empty)
                {
                    bombTankAsSingleString = blankSignUp;
                }
                if(topLureAsSingleString == string.Empty)
                {
                    topLureAsSingleString = blankSignUp;
                }
                #endregion

                #region Modified signup Encounter2
                await (sent).ModifyAsync(x =>
                {
                    EmbedBuilder encounter_edit = new EmbedBuilder()

                   .WithTitle("Encounter2")
                   .AddField("Time:", starttime)
                   .AddField("Looting:", "Energies and weapons are split between team mates")
                   .AddField("Team size:", "0/7")
                   .AddField("Reactions:", "Remove your signup and role")
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTanksAsSingleString)
                   .AddField("<:crossed_swords:927174860524896276> 1x dps:", dpsAsSingleString, true)
                   .AddField("<:game_die:947476766283407370> 1x any role:", anyRoleAsSingleString, true)
                   .AddField("<:mortar_board:927185690867937330> 1x learner:", learnerAsSingleString, true)
                   .AddField("<:bomb:961993455092002886> 1x bomb tank", bombTankAsSingleString, true)
                   .AddField("<:arrow_up:947161060253769758> 1x top lure:", topLureAsSingleString, true) 
                   .AddField("Role", MentionUtils.MentionRole(944968068113772594))
                   .WithCurrentTimestamp()
                   .WithColor(Color.DarkOrange);
                    x.Embed = encounter_edit.Build();
                });
                #endregion

                #region Get Signup ID's
                var signupSheet = new SignupSheet(sent.Id, Context.Channel.Id, Context.Guild.Id);

                PostedSignupSheets.AddSignupSheet(signupSheet);
                #endregion
            }

            [Command("encounter3")]
            public async Task encounter3()
            {
                //Create Encounter3 Emojis
                var shieldEmoji = Emoji.Parse(":shield:");
                var dpsEmoji = Emoji.Parse(":crossed_swords:");
                var anyEmoji = Emoji.Parse(":game_die:");
                var hatEmoji = Emoji.Parse(":mortar_board:");
                var rainShieldEmoji = Emoji.Parse(":cloud_rain:");
                var shatterEmoji = Emoji.Parse(":boom:");
                var cleanseEmoji = Emoji.Parse(":soap:");
                var firstRealmEmoji = Emoji.Parse(":one:");
                var secondRealmEmoji = Emoji.Parse(":two:");
                
                

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
                var shatterRole = await Context.Message.GetReactionUsersAsync(shatterEmoji, 100).FlattenAsync();
                var cleanseRole = await Context.Message.GetReactionUsersAsync(cleanseEmoji, 100).FlattenAsync();
                var firstRealmRole = await Context.Message.GetReactionUsersAsync(firstRealmEmoji, 100).FlattenAsync();
                var secondRealmRole = await Context.Message.GetReactionUsersAsync(secondRealmEmoji, 100).FlattenAsync();
                var damageRole = await Context.Message.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var anyRole = await Context.Message.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();
                var learnerRole = await Context.Message.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();



                await (sent).ModifyAsync(x =>
                {
                    EmbedBuilder encounter_edit = new EmbedBuilder()

                   .WithTitle("Test Encounter")
                   .AddField("Time:", "starttime")
                   .AddField("Looting:", " test")
                   .AddField("Team size:", " 0/7")
                   .AddField("Reactions:", "Remove your signup and role")
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTankRole, true)
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

                var shieldEmoji = Emoji.Parse(":shield:");
                var chinnerEmoji = Emoji.Parse(":chipmunk:");
                var hammerEmoji = Emoji.Parse(":hammer:");
                var uMinionEmoji = Emoji.Parse(":regional_indicator_u:");
                var gMinionEmoji = Emoji.Parse(":regional_indicator_g:");
                var cMinionEmoji = Emoji.Parse(":regional_indicator_c:");
                var fMinionEmoji = Emoji.Parse(":regional_indicator_f:");
                var dpsEmoji = Emoji.Parse(":crossed_swords:");
                var hatEmoji = Emoji.Parse(":mortar_board:");
                var anyEmoji = Emoji.Parse(":game_die:");

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
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTankRole, true)
                   .AddField("<:chipmunk:953223520446464060> 1x chinner:", chinnerRole, true)
                   .AddField("<:hammer:953223520446464060> 1x hammer:", hammerRole, true)
                   .AddField("<:regional_indicator_u:953229494863429652> 1x U Minion:", uMinionRole, true)
                   .AddField("<:regional_indicator_g:953229494863429652> 1x G Minion:", gMinionRole, true)
                   .AddField("<:regional_indicator_c:953229494863429652> 1x C Minion:", cMinionRole, true)
                   .AddField("<:regional_indicator_f:953229494863429652> 1x F Minion:", fMinionRole, true)
                   .AddField("<:crossed_swords:927174860524896276> 1x dps:", dpsRole, true)
                   .AddField("<:game_die:947476766283407370> 1x any role:", anyRole, true)
                   .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerRole, true)
                   .AddField("Role", MentionUtils.MentionRole(953223221807824898))
                   .WithCurrentTimestamp()
                   .WithColor(Color.DarkPurple);
                    x.Embed = encounter_edit.Build();
                });



            }


        }
    }
}









