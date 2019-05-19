using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;


namespace Mantis_Tests
{
    public class ProjectManagementHelper  : HelperBase

    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Menu.OpenProjectManagementPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            manager.Menu.OpenProjectManagementPage();
            return this;
        }

        private void SubmitProjectCreation()
        {

            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();

        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
        }

        private void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div/form/fieldset/button")).Click();
        }

        public ProjectManagementHelper Remove()
        {
            manager.Menu.OpenProjectManagementPage();
            SelectProject();
            SubmitRemovalProject();
            manager.Menu.OpenProjectManagementPage();
            return this;
        }

        private void SubmitRemovalProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void SelectProject()
        {
            driver.FindElements(By.TagName("td"))[0]
                .FindElement(By.TagName("a")).Click();
        }
    }
}
