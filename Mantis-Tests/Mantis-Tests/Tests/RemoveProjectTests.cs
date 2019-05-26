using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace Mantis_Tests
{
    [TestFixture]
    public class RemoveProjectTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProjectsList = app.API.GetAllProjects(account);

            if (oldProjectsList.Count < 1)

            {
                ProjectData anyProject = new ProjectData()
                {
                    Name = GenerateRandomString(20)
                };

                app.API.AddProject(account, anyProject);
            }

            oldProjectsList = app.API.GetAllProjects(account);

            ProjectData projectToRemove = oldProjectsList[0];

            app.API.RemoveProject(account, projectToRemove);

            Assert.AreEqual(oldProjectsList.Count - 1, app.API.GetAllProjects(account).Count);

            List<ProjectData> newProjectsList = app.API.GetAllProjects(account);
            oldProjectsList.RemoveAt(0);
            newProjectsList.Sort();
            oldProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}
