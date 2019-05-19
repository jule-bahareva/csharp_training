using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Mantis_Tests
{
   public class AuthTestBase : TestBase
    {
        [SetUp]

        public void SetupLogin()
        {
            app.Auth.Login 
                (new AccountData { Name = "administrator", Password = "root"} 
                );
        }

    }
}
