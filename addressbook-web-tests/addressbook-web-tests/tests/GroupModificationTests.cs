﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("edited_group_name");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify( newData);
        }
    }
}
