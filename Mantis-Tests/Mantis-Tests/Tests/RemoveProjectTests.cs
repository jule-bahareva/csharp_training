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
  
            if (!app.Projects.IsProjectExist())

            {
                ProjectData anyProject = new ProjectData()
                {
                    Name = GenerateRandomString(20)
                };

                app.Projects.Create(anyProject);
            }



            List<ProjectData> oldProjectsList = app.Projects.GetProjects();

            app.Projects.Remove();
        
            Assert.AreEqual(oldProjectsList.Count - 1, app.Projects.GetProjects().Count);

            List<ProjectData> newProjectsList = app.Projects.GetProjects();
            oldProjectsList.RemoveAt(0); 
            newProjectsList.Sort(); 
            oldProjectsList.Sort();  
            Assert.AreEqual(oldProjectsList, newProjectsList);
            }
        }

    }
