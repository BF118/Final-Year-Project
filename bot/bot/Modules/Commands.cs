using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using Discord.WebSocket;
using Discord.Net.WebSockets;

namespace bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        public ulong UserId { get; }

        public string fileName = Path.Combine(Environment.CurrentDirectory, "setup.txt");


        [Command("Hello")]
        public async Task Hello()
        {
            await ReplyAsync("Hello there");
        }

        [Command("website")]
        public async Task Spawn()
        {
            var builder = new ComponentBuilder()
                .WithButton("Click for website", null, ButtonStyle.Link, url: "http://bf118.webhosting.canterbury.ac.uk/");
            await ReplyAsync("Click here to be taken to the website", components: builder.Build());

        }

        [Command("help")]
        public async Task help()
        {
            EmbedBuilder help = new EmbedBuilder()

            .WithTitle(" = Command List =")
            .AddField("--------------", "!setup will set the bot up for you and the roles needed for it to work (requires admin permissions)")
            .AddField("--------------", "!website Brings up a button to the website")
            .AddField("--------------", "!encounter1-4 time 'starttime' This will create a signup sheet for users starttime is in 24hr format")
            .AddField("--------------", "!role 'rolename' This will assign you the role you want !role help !role list give more information")
            .AddField("--------------", "!removerole 'username' 'role' This will remove roles from users !role help !role list give more information (requires admin permissions)")
            .AddField("--------------", "!welcome shows the welcome message for the server (requires admin permissions)")
            .AddField("--------------", "!purge Will clear all messages in the channel (requires admin permissions)")
            .WithColor(Color.Green);

            var sent = await Context.Channel.SendMessageAsync("", false, help.Build());
        }

        [Command("purge")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task purge()
        {
            var messages = Context.Channel.GetMessagesAsync(1000).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }

        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("welcome")]
        public async Task welcome()
        {
            var encounter1 = new Emoji("1️⃣");
            var encounter2 = new Emoji("2️⃣");
            var encounter3 = new Emoji("3️⃣");
            var encounter4 = new Emoji("4️⃣");

            EmbedBuilder welcome = new EmbedBuilder()

                .WithTitle("welcome to the server")
                .AddField("--------------", "To get Started Assign yourself an Encounter Role")
                .AddField("--------------", "This can be done by typing !encounterrole plus the encounter number")
                .AddField("--------------", "The Amount of Encounter can be seen as reactions on this post")
                .AddField("--------------", "If you need help type !help if you need role help type !role help")
                .WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl() ?? Context.Client.CurrentUser.GetDefaultAvatarUrl())
                .WithColor(Color.DarkBlue);


            var welcomemessage = await Context.Channel.SendMessageAsync("", false, welcome.Build());

            await welcomemessage.AddReactionAsync(encounter1);
            await welcomemessage.AddReactionAsync(encounter2);
            await welcomemessage.AddReactionAsync(encounter3);
            await welcomemessage.AddReactionAsync(encounter4);
        }

        [Command("encounterrole")]
        public async Task encounterrole1(int encounterrole)
        {
            string[] lines = File.ReadAllLines(fileName);

            var Encounter1 = Convert.ToUInt64(lines[0]);
            var Encounter2 = Convert.ToUInt64(lines[1]);
            var Encounter3 = Convert.ToUInt64(lines[2]);
            var Encounter4 = Convert.ToUInt64(lines[3]);

            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }


            if (encounterrole == 1)
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(Encounter1);
            }
            if (encounterrole == 2)
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(Encounter2);
            }
            if (encounterrole == 3)
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(Encounter3);
            }
            if (encounterrole == 4)
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(Encounter4);
            }


        }


        [Command("role")]
        public async Task roles(string role)
        {
            var user = Context.User;
            string[] lines = File.ReadAllLines(fileName);

            #region Get Role ID's
            var baseTank = Convert.ToUInt64(lines[5]);
            var dps = Convert.ToUInt64(lines[6]);
            var bombTank = Convert.ToUInt64(lines[7]);
            var topLure = Convert.ToUInt64(lines[8]);
            var rainShield = Convert.ToUInt64(lines[9]);
            var shatter = Convert.ToUInt64(lines[10]);
            var cleanse = Convert.ToUInt64(lines[11]);
            var realm13 = Convert.ToUInt64(lines[12]);
            var realm24 = Convert.ToUInt64(lines[13]);
            var chinner = Convert.ToUInt64(lines[14]);
            var hammer = Convert.ToUInt64(lines[15]);
            var uminion = Convert.ToUInt64(lines[16]);
            var gminion = Convert.ToUInt64(lines[17]);
            var cminion = Convert.ToUInt64(lines[18]);
            var fminion = Convert.ToUInt64(lines[19]);
            #endregion

            #region Delete Command After Sent
            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
            #endregion

            #region General Roles
            if (role == "basetank")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🛡";
                //});

                Console.WriteLine(baseTank);
                await ((SocketGuildUser)Context.User).AddRoleAsync(baseTank);
                await user.SendMessageAsync("Profile updated basetank role has been given");
            }
            if (role == "dps")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "⚔️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(dps);
                await user.SendMessageAsync("Profile updated dps role has been given");
            }
            #endregion

            #region Encounter2 Roles
            if (role == "bombtank")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "💣";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(bombTank);
                await user.SendMessageAsync("Profile updated bombtank role has been given");
            }
            if (role == "toplure")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "⬆️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(topLure);
                await user.SendMessageAsync("Profile updated toplure role has been given");

            }
            #endregion

            #region Encounter3 Roles
            if (role == "rainshield")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🌧️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(rainShield);
                await user.SendMessageAsync("Profile updated rainshield role has been given");
            }
            if (role == "shatter")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "💥";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(shatter);
                await user.SendMessageAsync("Profile updated shatter role has been given");

            }
            if (role == "cleanse")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🧼";
                //});

                await ((SocketGuildUser)Context.User).AddRoleAsync(cleanse);
                await user.SendMessageAsync("Profile updated Cleanse role has been given");

            }
            if (role == "1/3realm")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "1️⃣";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(realm13);
                await user.SendMessageAsync("Profile updated 1/3 Realm role has been given");

            }
            if (role == "2/4realm")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "2️⃣";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(realm24);
                await user.SendMessageAsync("Profile updated 2/4 Realm role has been given");

            }
            #endregion

            #region Encounter 4 Roles
            //encounter4 Roles
            if (role == "chinner")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🐿️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(chinner);
                await user.SendMessageAsync("Profile updated Chinner role has been given");

            }
            if (role == "hammer")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🔨";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(hammer);
                await user.SendMessageAsync("Profile updated Hammer Realm role has been given");

            }
            if (role == "uminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇺";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(uminion);
                await user.SendMessageAsync("Profile updated Umbra Minion role has been given");

            }
            if (role == "gminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇬";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(gminion);
                await user.SendMessageAsync("Profile updated Glacies Minion role has been given");

            }
            if (role == "cminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇨";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(cminion);
                await user.SendMessageAsync("Profile updated Cruor Minion role has been given");

            }
            if (role == "fminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇫";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(fminion);
                await user.SendMessageAsync("Profile updated Fumus Minion role has been given");

            }
            #endregion

            #region ADD all Roles
            if (role == "general")
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(baseTank);
                await ((SocketGuildUser)Context.User).AddRoleAsync(dps);
                await user.SendMessageAsync("Profile updated all General roles have been given");

            }
            if (role == "allencounter2")
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(bombTank);
                await ((SocketGuildUser)Context.User).AddRoleAsync(topLure);
                await user.SendMessageAsync("Profile updated all encounter2 roles have been given");

            }
            if (role == "allencounter3")
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(rainShield);
                await ((SocketGuildUser)Context.User).AddRoleAsync(shatter);
                await ((SocketGuildUser)Context.User).AddRoleAsync(cleanse);
                await ((SocketGuildUser)Context.User).AddRoleAsync(realm13);
                await ((SocketGuildUser)Context.User).AddRoleAsync(realm24);
            }
            if (role == "allencounter4")
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(chinner);
                await ((SocketGuildUser)Context.User).AddRoleAsync(hammer);
                await ((SocketGuildUser)Context.User).AddRoleAsync(uminion);
                await ((SocketGuildUser)Context.User).AddRoleAsync(gminion);
                await ((SocketGuildUser)Context.User).AddRoleAsync(cminion);
                await ((SocketGuildUser)Context.User).AddRoleAsync(fminion);
            }
            #endregion

            if (role == "list")
            {
                EmbedBuilder rolelist = new EmbedBuilder()

                .WithTitle("Role list")
                .AddField("General Roles", "basetank, dps")
                .AddField("Encounter2 Roles", "bombtank, toplure")
                .AddField("Encounter3 Roles", "rainshield, shatter, cleanse, 1/3realm, 2/4realm")
                .AddField("Encounter4 Roles", "chinner, hammer, uminion(Umbra Minion), gminion(Glacies Minion), cminion(Cruor Minion), fminion(Fumus Minion)")
                .WithColor(Color.DarkRed);


                var sent = await Context.Channel.SendMessageAsync("", false, rolelist.Build());

            }

            if (role == "help")
            {
                EmbedBuilder rolehelp = new EmbedBuilder()

                .WithTitle("Role help")
                .AddField("---------", "!role list ::  Will show a list of all the possible roles that can be given for each encounter")
                .AddField("---------", "!role general  ::  adds all of the general role that apply to all encounters")
                .AddField("---------", "!role 'rolename' ::  adds indiviual role ")
                .AddField("---------", "!role allencounter'2-4'  ::  adds all specific roles for that encounter")
                .AddField("---------", "!roleremove 'rolename' :: Removes indiviual role (requires admin)")
                .AddField("---------", "!roleremove allencounter'2-4'  ::  Removes all specific roles for that encounter(requires admin)")
                .WithColor(Color.DarkRed);

                var sent = await Context.Channel.SendMessageAsync("", false, rolehelp.Build());
            }

            //else
            //{
            //    await user.SendMessageAsync("Role not found type !role list for a list of roles or !role help for any further help");

            //}

        }

        [Command("removerole")]
        [RequireBotPermission(GuildPermission.ManageRoles)]
        [RequireUserPermission(GuildPermission.ManageRoles)]
        public async Task removerole(SocketGuildUser user, string removerole)
        {
            string[] lines = File.ReadAllLines(fileName);

            #region Get Role ID's
            var baseTank = Convert.ToUInt64(lines[5]);
            var dps = Convert.ToUInt64(lines[6]);
            var bombTank = Convert.ToUInt64(lines[7]);
            var topLure = Convert.ToUInt64(lines[8]);
            var rainShield = Convert.ToUInt64(lines[9]);
            var shatter = Convert.ToUInt64(lines[10]);
            var cleanse = Convert.ToUInt64(lines[11]);
            var realm13 = Convert.ToUInt64(lines[12]);
            var realm24 = Convert.ToUInt64(lines[13]);
            var chinner = Convert.ToUInt64(lines[14]);
            var hammer = Convert.ToUInt64(lines[15]);
            var uminion = Convert.ToUInt64(lines[16]);
            var gminion = Convert.ToUInt64(lines[17]);
            var cminion = Convert.ToUInt64(lines[18]);
            var fminion = Convert.ToUInt64(lines[19]);
            #endregion


            if (removerole == "basetank")
            {
                await user.RemoveRoleAsync(baseTank);
                await user.SendMessageAsync("Profile updated dps role has been removed");

            }
            if (removerole == "dps")
            {
                await user.RemoveRoleAsync(dps);
                await user.SendMessageAsync("Profile updated dps role has been removed");
            }

            //encounter2 Roles
            if (removerole == "bombtank")
            {
                await user.RemoveRoleAsync(bombTank);
                await user.SendMessageAsync("Profile updated bombtank role has been removed");
            }
            if (removerole == "toplure")
            {
                await user.RemoveRoleAsync(topLure);
                await user.SendMessageAsync("Profile updated toplure role has been removed");
            }

            //encounter3 Roles
            if (removerole == "rainshield")
            {
                await user.RemoveRoleAsync(rainShield);
                await user.SendMessageAsync("Profile updated rainshield role has been removed");

            }
            if (removerole == "shatter")
            {
                await user.RemoveRoleAsync(shatter);
                await user.SendMessageAsync("Profile updated shatter role has been removed");
            }
            if (removerole == "cleanse")
            {
                await user.RemoveRoleAsync(cleanse);
                await user.SendMessageAsync("Profile updated Cleanse role has been removed");
            }
            if (removerole == "1/3realm")
            {
                await user.RemoveRoleAsync(realm13);
                await user.SendMessageAsync("Profile updated 1/3 Realm role has been removed");

            }
            if (removerole == "2/4realm")
            {
                await user.RemoveRoleAsync(realm24);
                await user.SendMessageAsync("Profile updated 2/4 Realm role has been removed");
            }

            //encounter4 Roles
            if (removerole == "chinner")
            {
                await user.RemoveRoleAsync(chinner);
                await user.SendMessageAsync("Profile updated Chinner role has been given");
            }
            if (removerole == "hammer")
            {
                await user.RemoveRoleAsync(hammer);
                await user.SendMessageAsync("Profile updated Hammer Realm role has been given");
            }
            if (removerole == "uminion")
            {
                await user.RemoveRoleAsync(uminion);
                await user.SendMessageAsync("Profile updated Umbra Minion role has been given");
            }
            if (removerole == "gminion")
            {
                await user.RemoveRoleAsync(gminion);
                await user.SendMessageAsync("Profile updated Glacies Minion role has been given");
            }
            if (removerole == "cminion")
            {
                await user.RemoveRoleAsync(cminion);
                await user.SendMessageAsync("Profile updated Cruor Minion role has been given");
            }
            if (removerole == "fminion")
            {
                await user.RemoveRoleAsync(fminion);
                await user.SendMessageAsync("Profile updated Fumus Minion role has been given");
            }

            else
            {
                await user.SendMessageAsync("Role couldn't be removed type !role list for a list of roles or !role help for any further help");
                await user.SendMessageAsync("To remove role type !removerole theuseryouwanttheroleremovedfrom rolename");
            }


        }
    }





}



