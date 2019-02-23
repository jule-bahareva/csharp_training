using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if  (driver.Url == baseURL + "/addressbook/")
            {
                //Thread.Sleep(10000);
                return;
            }

            //Thread.Sleep(10000);
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                 && IsElementPresent(By.Name("new")))
            {
                //Thread.Sleep(10000);
                return;
            }

            //Thread.Sleep(10000);
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
