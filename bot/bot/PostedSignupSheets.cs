using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot
{

    public class PostedSignupSheets
    {
        public List<SignupSheet> SignupSheets { get; set; }
        public PostedSignupSheets()
        {
            SignupSheets = new List<SignupSheet>();
        }
        public void AddSignupSheet(SignupSheet signupSheet)
        {
            SignupSheets.Add(signupSheet);

        }

    }
    public class SignupSheet
    {
        public ulong MessagesId { get; set; }
        public ulong ChannelsId { get; set; }
        public ulong GuildsID { get; set; }

        public SignupSheet(ulong messagesId, ulong channelsId, ulong guildsId)
        {
            MessagesId = messagesId;
            ChannelsId = channelsId;
            GuildsID = guildsId;
        }

    }
}
