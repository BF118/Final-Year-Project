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
    public class setup
    {

        public class Commands : ModuleBase<SocketCommandContext>
        {
            [Command("setup")]
            public async Task ServerSetUp()
            {

                var roles = await Context.Guild.CreateRoleAsync("jail", color: Color.DarkRed, isMentionable: false, isHoisted: false, permissions: GuildPermissions.None);
                var roles2 = await Context.Guild.CreateRoleAsync("jailer", color: Color.DarkRed, isMentionable: false, isHoisted: false, permissions: GuildPermissions.None);


                string roleid = roles.Id.ToString();
                string roleid2 = roles2.Id.ToString();
                string fileName = "setup.txt";
               
                
                
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    streamWriter.Write(roleid + "\n" + roleid2);
                } ;

                
                
            }

        }



    }
}
