﻿using System;
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
            public string fileName = Path.Combine(Environment.CurrentDirectory, "setup.txt");


            public Commands(PostedSignupSheets postedSignupSheets)
            {
                PostedSignupSheets = postedSignupSheets ?? throw new ArgumentNullException(nameof(postedSignupSheets));
            }
            public string blankSignUp = "\u200B";
            
            
            
            
            //Encounter1 embed
            [Command("encounter1")]
            public async Task encounter1(string time, DateTime starttime)
            {
                string[] encounter1Line = File.ReadAllLines(fileName);
                var encounter1Role = Convert.ToUInt64(encounter1Line[0]);

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
                .AddField("Role", MentionUtils.MentionRole(encounter1Role))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkBlue);

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
                    .AddField("Role", MentionUtils.MentionRole(encounter1Role))
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
                string[] encounter2Line = File.ReadAllLines(fileName);
                var encounter2Role = Convert.ToUInt64(encounter2Line[1]);

                #region Create Reactions Encounter2 
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
                .AddField("Role", MentionUtils.MentionRole(encounter2Role))
                .WithCurrentTimestamp()
                .WithColor(Color.Teal);

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
                var baseTankRole = await sent.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var damageRole = await sent.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var anyroleRole = await sent.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();
                var learnerRole = await sent.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync(); 
                var bombtankRole = await sent.GetReactionUsersAsync(bombEmoji, 100).FlattenAsync();
                var toplureRole = await sent.GetReactionUsersAsync(toplureEmoji, 100).FlattenAsync();
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
                   .AddField("Role", MentionUtils.MentionRole(encounter2Role))
                   .WithCurrentTimestamp()
                   .WithColor(Color.Teal);
                    x.Embed = encounter_edit.Build();
                });
                #endregion

                #region Get Signup ID's
                var signupSheet = new SignupSheet(sent.Id, Context.Channel.Id, Context.Guild.Id);

                PostedSignupSheets.AddSignupSheet(signupSheet);
                #endregion
            }

            [Command("encounter3")]
            public async Task encounter3(string time, DateTime starttime)
            {
                string[] encounter3Line = File.ReadAllLines(fileName);
                var encounter3Role = Convert.ToUInt64(encounter3Line[2]);

                #region Create Reactions Encounter3
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
                #endregion

                #region Loading Screen
                EmbedBuilder Encounter3 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 3 loading", "Please wait......")
                .AddField("Role", MentionUtils.MentionRole(encounter3Role))
                .WithCurrentTimestamp()
                .WithColor(Color.Green);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter3.Build());
                #endregion

                #region Add Reactions
                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(anyEmoji);
                await sent.AddReactionAsync(hatEmoji);
                await sent.AddReactionAsync(rainShieldEmoji);
                await sent.AddReactionAsync(shatterEmoji);
                await sent.AddReactionAsync(cleanseEmoji);
                await sent.AddReactionAsync(firstRealmEmoji);
                await sent.AddReactionAsync(secondRealmEmoji);
                #endregion

                #region Get User Reactions Encounter3
                var baseTankRole = await sent.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();              
                var damageRole = await sent.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var anyRole = await sent.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();
                var learnerRole = await sent.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();
                var shieldRole = await sent.GetReactionUsersAsync(rainShieldEmoji, 100).FlattenAsync();
                var shatterRole = await sent.GetReactionUsersAsync(shatterEmoji, 100).FlattenAsync();
                var cleanseRole = await sent.GetReactionUsersAsync(cleanseEmoji, 100).FlattenAsync();
                var firstRealmRole = await sent.GetReactionUsersAsync(firstRealmEmoji, 100).FlattenAsync();
                var secondRealmRole = await sent.GetReactionUsersAsync(secondRealmEmoji, 100).FlattenAsync();
                #endregion

                #region Convert roles to string
                IEnumerable<string> baseTankUsernames = baseTankRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string baseTanksAsSingleString = string.Join(" ,", baseTankUsernames);
                IEnumerable<string> dpsUsernames = damageRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string dpsAsSingleString = string.Join(" ,", dpsUsernames);
                IEnumerable<string> anyRoleUsernames = anyRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string anyRoleAsSingleString = string.Join(" ,", anyRoleUsernames);
                IEnumerable<string> learnerUsernames = learnerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string learnerAsSingleString = string.Join(" ,", learnerUsernames);
                IEnumerable<string> rainShieldUsernames = shieldRole.Where(x=> x.IsBot == false).Select(user => user.Username);
                string rainShieldAsSingleString = string.Join(" ,", rainShieldUsernames);
                IEnumerable<string> shatterUsernames = shatterRole.Where(x=> x.IsBot == false).Select(user => user.Username);
                string shatterAsSingleString = string.Join(" ,", shatterUsernames);
                IEnumerable<string> cleanseUsernames = cleanseRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string cleanseAsSingleString = string.Join(" ,", cleanseUsernames);
                IEnumerable<string> firstRealmUsernames = firstRealmRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string firstRealmAsSingleString = string.Join(" ,", firstRealmUsernames);
                IEnumerable<string> secondRealmUsernames = secondRealmRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string secondRealmAsSingleString = string.Join(" ,", secondRealmUsernames);
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
                if(rainShieldAsSingleString == string.Empty)
                {
                    rainShieldAsSingleString = blankSignUp;
                }
                if(shatterAsSingleString == string.Empty)
                {
                    shatterAsSingleString = blankSignUp;
                }
                if(cleanseAsSingleString == string.Empty)
                {
                    cleanseAsSingleString = blankSignUp;
                }
                if(firstRealmAsSingleString == string.Empty)
                {
                    firstRealmAsSingleString = blankSignUp;
                }
                if(secondRealmAsSingleString == string.Empty) 
                {                 
                    secondRealmAsSingleString= blankSignUp;
                }
                #endregion

                #region Modified Signup Encounter3
                await (sent).ModifyAsync(x =>
                {
                    EmbedBuilder encounter_edit = new EmbedBuilder()

                   .WithTitle("Test Encounter")
                   .AddField("Time:", starttime)
                   .AddField("Looting:", " test")
                   .AddField("Team size:", " 0/7")
                   .AddField("Reactions:", "Remove your signup and role")
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTanksAsSingleString, true)
                   .AddField("<:crossed_swords:927174860524896276> 1x dps:", dpsAsSingleString, true)
                   .AddField("<:game_die:947476766283407370> 1x any role:", anyRoleAsSingleString, true)
                   .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerAsSingleString, true)
                   .AddField("<:cloud_rain:947534430891827320> 1x Rain Shield:", rainShieldAsSingleString, true)
                   .AddField("<:boom:947534430891827320> 1x Shatter:", shatterAsSingleString, true)
                   .AddField("<:soap:947534430891827320> 1x Cleanse:", cleanseAsSingleString, true)
                   .AddField("<:one:947534430891827320> 1x 1/3 Realm:", firstRealmAsSingleString, true)
                   .AddField("<:two:947534430891827320> 1x 2/4 Realm:", secondRealmAsSingleString, true)
                   .AddField("Role", MentionUtils.MentionRole(encounter3Role))
                   .WithCurrentTimestamp()
                   .WithColor(Color.Green);
                    x.Embed = encounter_edit.Build();
                });
                #endregion

                #region Get signup ID's

                var signupSheet = new SignupSheet(sent.Id, Context.Channel.Id, Context.Guild.Id);

                PostedSignupSheets.AddSignupSheet(signupSheet);

                #endregion

            }
            [Command("encounter4")]
            public async Task encounter4(string time, DateTime starttime)
            {
                string[] encounter4Line = File.ReadAllLines(fileName);
                var encounter4Role = Convert.ToUInt64(encounter4Line[3]);

                #region Creation Reactions Encounter 4
                var shieldEmoji = Emoji.Parse(":shield:");
                var dpsEmoji = Emoji.Parse(":crossed_swords:");
                var anyEmoji = Emoji.Parse(":game_die:");
                var hatEmoji = Emoji.Parse(":mortar_board:");
                var chinnerEmoji = Emoji.Parse(":chipmunk:");
                var hammerEmoji = Emoji.Parse(":hammer:");
                var uMinionEmoji = Emoji.Parse(":regional_indicator_u:");
                var gMinionEmoji = Emoji.Parse(":regional_indicator_g:");
                var cMinionEmoji = Emoji.Parse(":regional_indicator_c:");
                var fMinionEmoji = Emoji.Parse(":regional_indicator_f:");
                #endregion

                #region Loading Screen
                EmbedBuilder Encounter4 = new EmbedBuilder()

                .WithTitle("Loading....")
                .AddField("Encounter 4 loading", "Please wait")
                .AddField("Role", MentionUtils.MentionRole(953223221807824898))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkPurple);

                var sent = await Context.Channel.SendMessageAsync("", false, Encounter4.Build());
                #endregion

                #region Add Reactions
                //add reaction emojis to the post
                await sent.AddReactionAsync(shieldEmoji);
                await sent.AddReactionAsync(dpsEmoji);
                await sent.AddReactionAsync(anyEmoji);
                await sent.AddReactionAsync(hatEmoji);  
                await sent.AddReactionAsync(chinnerEmoji);
                await sent.AddReactionAsync(hammerEmoji);
                await sent.AddReactionAsync(uMinionEmoji);
                await sent.AddReactionAsync(gMinionEmoji);
                await sent.AddReactionAsync(cMinionEmoji);
                await sent.AddReactionAsync(fMinionEmoji);
                #endregion

                #region Get User Reactions Encounter4
                var baseTankRole = await sent.GetReactionUsersAsync(shieldEmoji, 100).FlattenAsync();
                var dpsRole = await sent.GetReactionUsersAsync(dpsEmoji, 100).FlattenAsync();
                var anyRole = await sent.GetReactionUsersAsync(anyEmoji, 100).FlattenAsync();
                var learnerRole = await sent.GetReactionUsersAsync(hatEmoji, 100).FlattenAsync();
                var chinnerRole = await sent.GetReactionUsersAsync(chinnerEmoji, 100).FlattenAsync();
                var hammerRole = await sent.GetReactionUsersAsync(hammerEmoji, 100).FlattenAsync();
                var uMinionRole = await sent.GetReactionUsersAsync(uMinionEmoji, 100).FlattenAsync();
                var gMinionRole = await sent.GetReactionUsersAsync(gMinionEmoji, 100).FlattenAsync();
                var cMinionRole = await sent.GetReactionUsersAsync(cMinionEmoji, 100).FlattenAsync();
                var fMinionRole = await sent.GetReactionUsersAsync(fMinionEmoji, 100).FlattenAsync();
                #endregion

                #region Convert roles to string
                IEnumerable<string> baseTankUsernames = baseTankRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string baseTanksAsSingleString = string.Join(" ,", baseTankUsernames);
                IEnumerable<string> dpsUsernames = dpsRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string dpsAsSingleString = string.Join(" ,", dpsUsernames);
                IEnumerable<string> anyRoleUsernames = anyRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string anyRoleAsSingleString = string.Join(" ,", anyRoleUsernames);
                IEnumerable<string> learnerUsernames = learnerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string learnerAsSingleString = string.Join(" ,", learnerUsernames);
                IEnumerable<string> chinnerUsernames = chinnerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string chinnerAsSingleString = string.Join(" ,", chinnerUsernames);
                IEnumerable<string> hammerUsername = hammerRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string hammerAsSingleString = string.Join(" ,", hammerUsername);
                IEnumerable<string> uMinionUsernames = uMinionRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string uMinionAsSingleString = string.Join(" ,", uMinionUsernames);
                IEnumerable<string> gMinionUsernames = gMinionRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string gMinionAsSingleString = string.Join(" ,", gMinionUsernames);
                IEnumerable<string> cMinionUsernames = cMinionRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string cMinionAsSingleString = string.Join(" ,", cMinionUsernames);
                IEnumerable<string> fMinionUsernames = fMinionRole.Where(x => x.IsBot == false).Select(user => user.Username);
                string fMinionAsSingleString = string.Join(" ,", fMinionUsernames);
                #endregion

                #region empty String
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
                if(chinnerAsSingleString == string.Empty)
                {
                    chinnerAsSingleString = blankSignUp;
                }
                if(hammerAsSingleString == string.Empty)
                {
                    hammerAsSingleString = blankSignUp;
                }
                if(uMinionAsSingleString == string.Empty)
                {
                    uMinionAsSingleString = blankSignUp;
                }
                if(gMinionAsSingleString== string.Empty)
                {
                    gMinionAsSingleString = blankSignUp;
                }
                if(cMinionAsSingleString == string.Empty)
                {
                    cMinionAsSingleString = blankSignUp;
                }
                if(fMinionAsSingleString == string.Empty)
                {
                    fMinionAsSingleString = blankSignUp;
                }
                #endregion

                #region Modified Signup Encounter4
                await (sent).ModifyAsync(x =>
                {
                    EmbedBuilder encounter_edit = new EmbedBuilder()

                   .WithTitle("Test Encounter")
                   .AddField("Time:", starttime)
                   .AddField("Looting:", "test")
                   .AddField("Team size:", "0/7")
                   .AddField("Reactions:", "Remove your signup and role")
                   .AddField("<:shield:927174765058326558> 1x Base Tank:", baseTanksAsSingleString, true)
                   .AddField("<:crossed_swords:927174860524896276> 1x dps:", dpsAsSingleString, true)
                   .AddField("<:game_die:947476766283407370> 1x any role:", anyRoleAsSingleString, true)
                   .AddField("<:mortar_board:927185690867937330> 1x Learner:", learnerAsSingleString, true)
                   .AddField("<:chipmunk:953223520446464060> 1x chinner:", chinnerAsSingleString, true)
                   .AddField("<:hammer:953223520446464060> 1x hammer:", hammerAsSingleString, true)
                   .AddField("<:regional_indicator_u:953229494863429652> 1x U Minion:", uMinionAsSingleString, true)
                   .AddField("<:regional_indicator_g:953229494863429652> 1x G Minion:", gMinionAsSingleString, true)
                   .AddField("<:regional_indicator_c:953229494863429652> 1x C Minion:", cMinionAsSingleString, true)
                   .AddField("<:regional_indicator_f:953229494863429652> 1x F Minion:", fMinionAsSingleString, true)
                   .AddField("Role", MentionUtils.MentionRole(953223221807824898))
                   .WithCurrentTimestamp()
                   .WithColor(Color.DarkPurple);
                    x.Embed = encounter_edit.Build();
                });
                #endregion

                #region Get signup ID's

                var signupSheet = new SignupSheet(sent.Id, Context.Channel.Id, Context.Guild.Id);

                PostedSignupSheets.AddSignupSheet(signupSheet);

                #endregion


            }


        }
    }
}









