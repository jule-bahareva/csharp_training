using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("edited_group_name");
            newData.Header = "edited_group_header";
            newData.Footer = "edited_group_footer";

            app.Groups.Modify(1, newData);
        }
    }
}
