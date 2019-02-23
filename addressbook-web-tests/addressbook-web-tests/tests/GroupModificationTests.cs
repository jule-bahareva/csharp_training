using System;
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
            GroupData group = new GroupData("group_name1");
            group.Header = "group_header1";
            group.Footer = "group_footer1";

            GroupData newData = new GroupData("edited_group_name");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify( newData, group);
        }
    }
}
