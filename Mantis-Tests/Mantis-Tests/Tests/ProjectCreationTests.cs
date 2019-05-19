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


            //List<ProjectData> oldProjectsList = app.Projects.GetProjectsList();

            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(20)
            };
 
            app.Projects.Create(project);

            //Assert.AreEqual(oldProjectsList.Count + 1, app.Projects.GetProjectsCount());

            // List<ProjectData> newProjectsList = app.Projects.GetGroupList();
            // oldProjectsList.Add(group);
            // newProjectsList.Sort();
            // oldProjectsList.Sort();

            // Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}


