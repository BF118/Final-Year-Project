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
            [RequireBotPermission(GuildPermission.ManageRoles)]
            [RequireUserPermission(GuildPermission.Administrator)]
            [Command("setup")]
            public async Task ServerSetUp()
            {
                string fileName = @"E:\GITHUB UNI\fyp\bot\bot\Modules\setup.txt";

                Console.WriteLine("Setup Underway......");

                #region Encounter Roles
                var encounter1 = await Context.Guild.CreateRoleAsync("Encounter1", color: Color.LightGrey, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var encounter2 = await Context.Guild.CreateRoleAsync("Encounter2", color: Color.LightGrey, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var encounter3 = await Context.Guild.CreateRoleAsync("Encounter3", color: Color.LightGrey, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var encounter4 = await Context.Guild.CreateRoleAsync("Encounter3", color: Color.LightGrey, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var member = await Context.Guild.CreateRoleAsync("member", color: Color.LighterGrey, isMentionable: false, isHoisted: false, permissions: GuildPermissions.None);
                Console.WriteLine("Encounter Roles created....");
                #endregion

                #region General Roles Created
                var baseTank = await Context.Guild.CreateRoleAsync("BaseTank", color: Color.Blue, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var dps = await Context.Guild.CreateRoleAsync("DPS", color:Color.Orange, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                Console.WriteLine("General Roles Created.....");
                #endregion

                #region Encounter 2 Roles Created
                var bombtank = await Context.Guild.CreateRoleAsync("BombTank", color: Color.Blue, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var toplure = await Context.Guild.CreateRoleAsync("Toplure", color:Color.DarkPurple, isMentionable: true, isHoisted: false, permissions:GuildPermissions.None);
                Console.WriteLine("Encounter 2 Roles Created.....");
                #endregion

                #region Encounter 3 Roles Created
                var rainshield = await Context.Guild.CreateRoleAsync("RainShield", color: Color.Purple, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var shatter = await Context.Guild.CreateRoleAsync("Shatter", color:Color.LightOrange, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var cleanse = await Context.Guild.CreateRoleAsync("Cleanse", color: Color.Magenta, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var realm13 = await Context.Guild.CreateRoleAsync("Realm 1/3", color: Color.Green, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var realm24 = await Context.Guild.CreateRoleAsync("Realm 2/4", color: Color.DarkGreen, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                Console.WriteLine("Encounter 3 Roles Created.....");
                #endregion

                #region Encounter 4 Roles Created
                var chinner = await Context.Guild.CreateRoleAsync("Chinner", color: Color.Teal, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var hammer = await Context.Guild.CreateRoleAsync("Hammer", color:Color.DarkOrange, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var Uminion = await Context.Guild.CreateRoleAsync("Umbra Minion", color: Color.DarkPurple, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var Gminion = await Context.Guild.CreateRoleAsync("Glacies Minion", color: Color.Teal, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var Cminion = await Context.Guild.CreateRoleAsync("Cruor Minion", color: Color.DarkRed, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                var Fminion = await Context.Guild.CreateRoleAsync("Fumus Minion", color: Color.DarkerGrey, isMentionable: true, isHoisted: false, permissions: GuildPermissions.None);
                Console.WriteLine("Encounter 4 Roles created.....");
                #endregion

                Console.WriteLine("All Roles Created......");

                #region Convert to String Encounter Roles
                string encounter1RoleId = encounter1.Id.ToString();
                string encounter2RoleId = encounter2.Id.ToString();
                string encounter3RoleId = encounter3.Id.ToString();
                string encounter4RoleId = encounter4.Id.ToString();
                string memberRoleId = member.Id.ToString();
                #endregion

                #region Convert to String General Roles
                string baseTankRoleId = baseTank.Id.ToString(); 
                string dpsRoleId = dps.Id.ToString();
                #endregion

                #region Convert to String Encounter 2 Roles
                string bombTankRoleId = bombtank.Id.ToString();
                string topLureRoleId = toplure.Id.ToString();
                #endregion

                #region Convert to String Encounter 3 Roles
                string rainShieldRoleId = rainshield.Id.ToString();
                string shatterRoleId = shatter.Id.ToString();
                string cleanseRoleId = cleanse.Id.ToString();
                string realm13RoleId = realm13.Id.ToString();
                string realm24RoleId = realm24.Id.ToString();
                #endregion

                #region Convert to String Encounter 4 Roles
                string chinnerRoleId = chinner.Id.ToString();
                string hammerRoleId = hammer.Id.ToString();
                string uMinionRoleId = Uminion.Id.ToString();
                string gMinionRoleId = Gminion.Id.ToString();
                string cMinionRoleId = Cminion.Id.ToString();
                string fMinionRoleId = Fminion.Id.ToString();
                #endregion


                Console.WriteLine("Converting Roles......");

                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    streamWriter.Write(encounter1RoleId + "\n" + encounter2RoleId
                        + "\n" + encounter3RoleId + "\n" + encounter4RoleId + "\n" + memberRoleId + "\n" + baseTankRoleId +
                        "\n" + dpsRoleId + "\n" + bombTankRoleId + "\n" + topLureRoleId + "\n" + rainShieldRoleId + "\n" + shatterRoleId + "\n" + cleanseRoleId +
                        "\n" + cleanseRoleId + "\n" + realm13RoleId + "\n" + realm24RoleId + "\n" + chinnerRoleId + "\n" + hammerRoleId + "\n" + uMinionRoleId + 
                        "\n" + uMinionRoleId + "\n" + gMinionRoleId + "\n" + cMinionRoleId + "\n"+ fMinionRoleId) ;
                } ;

                Console.WriteLine("ID Saved......");
                Console.WriteLine("Setup Complete.....");
            }

        }



    }
}
