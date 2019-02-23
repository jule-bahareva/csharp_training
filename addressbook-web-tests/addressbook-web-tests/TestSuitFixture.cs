using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuitFixture
    {
        public static ApplicationManager app;

        [SetUp]
        public void InitApplicationManager()
        {
            app = new ApplicationManager();
        }
        [TearDown]
        public void StopApplicationManager()
        {

        }
    }
}
