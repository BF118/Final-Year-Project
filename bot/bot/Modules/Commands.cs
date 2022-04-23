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
            .AddField("!website", "Shows a button that will take you to the website")
            .AddField("!encounter1", "Brings up sign up sheet for encounter1 as well as button to said sheet")
            .AddField("!encounter2", "Brings up sign up sheet for encounter2 as well as button to said sheet")
            .AddField("!encounter3", "Brings up sign up sheet for encounter3 as well as button to said sheet")
            .AddField("!encounter4", "Brings up sign up sheet for encounter4 as well as button to said sheet")
            .AddField("!basetank, !dps, !healer, !bombtank etc","Doing !plus the role you want will add that emoji to username")
            .AddField("!purge", "will clear all messages in the channel if you have permissions to do so")
            .AddField("", "")
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
        [Command("welcome")]
        public async Task welcome()
        {
            var encounter1 = new Emoji("1️⃣");
            var encounter2 = new Emoji("2️⃣");
            var encounter3 = new Emoji("3️⃣");
            var encounter4 = new Emoji("4️⃣");

            ulong encounter1RoleId = 933000592362725396;
            ulong encounter2RoleId = 944968068113772594;
            ulong encounter3RoleId = 944968105199796245;
            ulong encounter4RoleId = 953223221807824898;

            var encounter1role = Context.Guild.GetRole(encounter1RoleId);
            var encounter2role = Context.Guild.GetRole(encounter2RoleId);
            var encounter3role = Context.Guild.GetRole(encounter3RoleId);
            var encounter4role = Context.Guild.GetRole(encounter4RoleId);

            EmbedBuilder welcome = new EmbedBuilder()

                .WithTitle("welcome to the server")
                .AddField("To get assigned a role for the encounter you want to do","!")
                .AddField("Type !encounterrolen where n is the encounter you want","!")
                .AddField("All avaiable encounters can be seen with the reactions on this post","!")
                .WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl() ?? Context.Client.CurrentUser.GetDefaultAvatarUrl())
                .WithColor(Color.DarkBlue);


            var welcomemessage = await Context.Channel.SendMessageAsync("", false, welcome.Build());

            await welcomemessage.AddReactionAsync(encounter1);
            await welcomemessage.AddReactionAsync(encounter2);
            await welcomemessage.AddReactionAsync(encounter3);
            await welcomemessage.AddReactionAsync(encounter4);

            var roleencounter1 = Context.Message.GetReactionUsersAsync(encounter1, 100, null);
            var roleencounter2 = Context.Message.GetReactionUsersAsync(encounter2, 100, null);
            var roleencounter3 = Context.Message.GetReactionUsersAsync(encounter3, 100, null); 
            var roleencounter4 = Context.Message.GetReactionUsersAsync(encounter4, 100, null);
        }
        [Command("encounterrole1")]
        public async Task encounterrole1()
        {

            await ((SocketGuildUser)Context.User).AddRoleAsync(933000592362725396);

            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach(var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }
        [Command("encounterrole2")]
        public async Task encounterrole2()
        {
            await ((SocketGuildUser)Context.User).AddRoleAsync(944968068113772594);
            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }
        [Command("encounterrole3")]
        public async Task encounterrole3()
        {
            await ((SocketGuildUser)Context.User).AddRoleAsync(944968105199796245);
            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }
        [Command("encounterrole4")]
        public async Task encounterrole4()
        {
            await ((SocketGuildUser)Context.User).AddRoleAsync(953223221807824898);
            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
        }      
        [Command("role")]
        public async Task roles(string role)
        {
            var user = Context.User;
            var messages = Context.Channel.GetMessagesAsync(1).Flatten();
            foreach (var i in await messages.ToArrayAsync())
            {
                await this.Context.Channel.DeleteMessageAsync(i);
            }
            
            //General Roles
            if (role == "basetank")
            {

                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🛡";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956556279462113350);
                await user.SendMessageAsync("Profile updated basetank role has been given");
                
            }
            if (role == "dps")
            {

                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "⚔️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956556579174506506);
                await user.SendMessageAsync("Profile updated dps role has been given");
            }
            if (role == "healer")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "❤️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956145603321151518);
                await user.SendMessageAsync("Profile updated healer role has been given");
            }
            
            //encounter2 Roles
            if (role == "bombtank")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "💣";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956562683442921472);
                await user.SendMessageAsync("Profile updated bombtank role has been given");
            }
            if (role == "toplure")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "⬆️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956562683442921472);
                await user.SendMessageAsync("Profile updated toplure role has been given");
                
            }

            //encounter3 Roles
            if (role == "rainshield")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🌧️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956564451253968916);
                await user.SendMessageAsync("Profile updated rainshield role has been given");
                
            }
            if (role == "shatter")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "💥";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956565009285132340);
                await user.SendMessageAsync("Profile updated shatter role has been given");
                
            }
            if (role == "cleanse")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🧼";
                //});

                await ((SocketGuildUser)Context.User).AddRoleAsync(956567001294340137);
                await user.SendMessageAsync("Profile updated Cleanse role has been given");
                
            }
            if (role == "1/3realm")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "1️⃣";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567179086688366);
                await user.SendMessageAsync("Profile updated 1/3 Realm role has been given");
                
            }
            if (role == "2/4realm")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "2️⃣";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567416836608050);
                await user.SendMessageAsync("Profile updated 2/4 Realm role has been given");
                
            }

            //encounter4 Roles
            if (role == "chinner")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🐿️";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567677021863986);
                await user.SendMessageAsync("Profile updated Chinner role has been given");
                
            }
            if (role == "hammer")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🔨";
                //});
                 await ((SocketGuildUser)Context.User).AddRoleAsync(956567677021863986);
                await user.SendMessageAsync("Profile updated Hammer Realm role has been given");
                
            }
            if (role == "uminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇺";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956569612080787567);
                await user.SendMessageAsync("Profile updated Umbra Minion role has been given");
                
            }
            if (role == "gminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇬";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956570089640050688);
                await user.SendMessageAsync("Profile updated Glacies Minion role has been given");
                
            }
            if (role == "cminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇨";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956570691422027786);
                await user.SendMessageAsync("Profile updated Cruor Minion role has been given");
                
            }
            if (role == "fminion")
            {
                //await user.ModifyAsync(x =>
                //{
                //    x.Nickname = user.Nickname + "🇫";
                //});
                await ((SocketGuildUser)Context.User).AddRoleAsync(956571248916312105);
                await user.SendMessageAsync("Profile updated Fumus Minion role has been given");
                
            }

            if(role == "allencounter2")
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(956562683442921472);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956562683442921472);
                await user.SendMessageAsync("Profile updated all encounter2 roles have been given");

            }
            if(role == "allencounter3")
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(956565009285132340);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956565009285132340);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567001294340137);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567179086688366);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567416836608050);
            }
            if(role =="allencounter4")
            {
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567677021863986);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956567677021863986);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956569612080787567);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956570089640050688);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956570691422027786);
                await ((SocketGuildUser)Context.User).AddRoleAsync(956571248916312105);
            }

            if(role == "list")
            {
                EmbedBuilder rolelist = new EmbedBuilder()

                .WithTitle("Role list")
                .AddField("General Roles", "basetank, dps, healer")
                .AddField("Encounter2 Roles","bombtank, toplure")
                .AddField("Encounter3 Roles","rainshield, shatter, cleanse, 1/3realm, 2/4realm")
                .AddField("Encounter4 Roles","chinner, hammer, uminion(Umbra Minion), gminion(Glacies Minion), cminion(Cruor Minion), fminion(Fumus Minion)")

                .WithColor(Color.DarkRed);


                var sent = await Context.Channel.SendMessageAsync("", false, rolelist.Build());

            }



            if(role == "help")
            {
                EmbedBuilder rolehelp = new EmbedBuilder()

                .WithTitle("Role help")
                .AddField("---------","!role list ::  Will show a list of all the possible roles that can be given for each encounter")
                .AddField("---------","!role general  ::  adds all of the general role that apply to all encounters")
                .AddField("---------","!role 'rolename' ::  adds indiviual role ")
                .AddField("---------","!role allencounter'2-4'  ::  adds all specific roles for that encounter")
                .AddField("---------","!roleremove 'rolename' :: Removes indiviual role (requires admin)")
                .AddField("---------","!roleremove allencounter'2-4'  ::  Removes all specific roles for that encounter(requires admin)")
                .WithColor(Color.DarkRed);

                var sent = await Context.Channel.SendMessageAsync("", false, rolehelp.Build());
            }

        }
        [Command("roleremove")]
        [RequireBotPermission(GuildPermission.ManageRoles)]
        [RequireUserPermission(GuildPermission.ManageRoles)]
        public async Task removerole(SocketGuildUser user ,string removerole)
        {



            if (removerole == "basetank")
            { 
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956556279462113350);
                await user.SendMessageAsync("Profile updated dps role has been removed");

            }
            if (removerole == "dps")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956556579174506506);
                await user.SendMessageAsync("Profile updated dps role has been removed");
            }
            if (removerole == "healer")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956145603321151518);
                await user.SendMessageAsync("Profile updated healer role has been removed");
            }

            //encounter2 Roles
            if (removerole == "bombtank")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956562683442921472);
                await user.SendMessageAsync("Profile updated bombtank role has been removed");
            }
            if (removerole == "toplure")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956562683442921472);
                await user.SendMessageAsync("Profile updated toplure role has been removed");
            }

            //encounter3 Roles
            if (removerole == "rainshield")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956564451253968916);
                await user.SendMessageAsync("Profile updated rainshield role has been removed");

            }
            if (removerole == "shatter")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956565009285132340);
                await user.SendMessageAsync("Profile updated shatter role has been removed");
            }
            if (removerole == "cleanse")
            {              
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956567001294340137);
                await user.SendMessageAsync("Profile updated Cleanse role has been removed");
            }
            if (removerole == "1/3realm")
            {              
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956567179086688366);
                await user.SendMessageAsync("Profile updated 1/3 Realm role has been removed");

            }
            if (removerole == "2/4realm")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956567416836608050);
                await user.SendMessageAsync("Profile updated 2/4 Realm role has been removed");
            }

            //encounter4 Roles
            if (removerole == "chinner")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956567677021863986);
                await user.SendMessageAsync("Profile updated Chinner role has been given");
            }
            if (removerole == "hammer")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956568612817219665);
                await user.SendMessageAsync("Profile updated Hammer Realm role has been given");
            }
            if (removerole == "uminion")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956569612080787567);
                await user.SendMessageAsync("Profile updated Umbra Minion role has been given");
            }
            if (removerole == "gminion")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956570089640050688);
                await user.SendMessageAsync("Profile updated Glacies Minion role has been given");
            }
            if (removerole == "cminion")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956570691422027786);
                await user.SendMessageAsync("Profile updated Cruor Minion role has been given");
            }
            if (removerole == "fminion")
            {
                await ((SocketGuildUser)Context.User).RemoveRoleAsync(956571248916312105);
                await user.SendMessageAsync("Profile updated Fumus Minion role has been given");
            }




        }
    }
        



    
}



