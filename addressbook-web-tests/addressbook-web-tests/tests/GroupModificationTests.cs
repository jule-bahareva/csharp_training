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

    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldData.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }

            }
        }
    }
}
