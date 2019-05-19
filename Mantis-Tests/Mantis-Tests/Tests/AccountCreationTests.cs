﻿using System;
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
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("D:/csharp-training/csharp_training/Mantis-Tests/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
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
            app.Ftp.RestoreBackupFile("/config_inc.php");
 

        }

    }
}
