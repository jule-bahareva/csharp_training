﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count < 2)
            {
                app.Groups.Add(new GroupData()
                { Name = "AnyGroup"
                });

                oldGroups = app.Groups.GetGroupList();
            }

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
  
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
