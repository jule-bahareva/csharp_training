using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "white"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            System.Console.Out.WriteLine(oldGroups);
            System.Console.Out.WriteLine(newGroups);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
