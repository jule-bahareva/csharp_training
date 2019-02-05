using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {      
        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("group_name1");
            group.Header = "group_header1";
            group.Footer = "group_footer1";


            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";


            app.Groups.Create(group);
        }
    }
}
