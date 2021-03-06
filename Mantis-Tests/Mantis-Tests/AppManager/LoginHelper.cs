﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantis_Tests
{
    public class LoginHelper : HelperBase
    {
        
        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
                                                                                                                                                                                                                                                                      
        }
        
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn())
                {
                    return;
                }

                Logout();
            }


            Type(By.Name("username"), account.Name);
           
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();

            Type(By.Name("password"), account.Password);

            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();


        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.LinkText("Выход")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("i.fa.fa-user.home-icon.active"));
        }

    }
}
