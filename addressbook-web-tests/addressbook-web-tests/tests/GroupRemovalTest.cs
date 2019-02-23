using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void RemovalGroupTest()
        {
            GroupData group = new GroupData("group_name1");
            group.Header = "group_header1";
            group.Footer = "group_footer1";

            app.Groups.Remove(group);

        }
    }
}
