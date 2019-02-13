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
    public class ContactHelper : HelperBase
    {

        public ContactHelper Create(ContactData contact)
        {

            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();

            manager.Auth.Logout();
            return this;
        }

        public ContactHelper Remove(int v)
        {
    
            SelectContact();
            InitContactModification();
            RemoveContact();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newContact)
        {
            SelectContact();
            InitContactModification();
            FillContactForm(newContact);
            SubmitContactModification();

            manager.Auth.Logout();

            return this;
        }

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[16]")).Click();
            //driver.FindElement(By.Name("bmonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[46]")).Click();
            //driver.FindElement(By.Name("byear")).Click();
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            //driver.FindElement(By.Name("aday")).Click();
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[20]")).Click();
            //driver.FindElement(By.Name("amonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[46]")).Click();
            //driver.FindElement(By.Name("ayear")).Click();
            //driver.FindElement(By.Name("ayear")).Clear();
            //driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click(); ;
            return this;
        }
    }
}
