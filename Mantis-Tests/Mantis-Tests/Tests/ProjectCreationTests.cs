using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;



namespace Mantis_Tests

{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {


        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProjectsList = app.API.GetAllProjects(account);

            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(20)
            };

            app.API.AddProject(account, project);

            Assert.AreEqual(oldProjectsList.Count + 1, app.API.GetAllProjects(account).Count);

            List<ProjectData> newProjectsList = app.Projects.GetProjects();
            oldProjectsList.Add(project);
            newProjectsList.Sort();
            oldProjectsList.Sort();

            Assert.AreEqual(oldProjectsList, newProjectsList);

        }
    }

}



