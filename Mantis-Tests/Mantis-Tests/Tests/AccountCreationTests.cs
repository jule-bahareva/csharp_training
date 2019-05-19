using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace Mantis_Tests
{

     [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config/config_inc.php");
            using (Stream localFile = File.Open("/config/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config/config_inc.php", localFile);
            }


        }


        [Test]
        public void AccountRegistrationTest()
        {

            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain",
           
            };

            app.Registration.Register(account);
        }

        [TearDown]

        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
 

        }

    }
}
