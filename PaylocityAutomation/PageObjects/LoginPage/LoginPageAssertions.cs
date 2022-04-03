using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class LoginPageAssertions
    {
        private readonly LoginPageMap _map;

        public LoginPageAssertions(LoginPageMap map)
        {
            _map = map;
        }

        public void AssertUsernameEntered(string expectedUsername)
        {
            Assert.AreEqual(expectedUsername, _map.UsernameTextBox.GetAttribute("value"));
        }
    }
}
