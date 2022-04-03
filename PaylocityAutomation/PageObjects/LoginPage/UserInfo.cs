using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class UserInfo
    {
        public UserInfo(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool ShouldLogin { get; set; } = false;
    }
}
