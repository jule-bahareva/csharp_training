using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {


            //prepare 
            if (!app.Groups.IsGroupExists())

            {
                GroupData anyGroup = new GroupData("addedGroup1");
                app.Groups.Create(anyGroup);
            }

            //action 
            GroupData newData = new GroupData("edited_group_name");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
