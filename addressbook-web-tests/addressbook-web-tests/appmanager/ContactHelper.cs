using System;
using System.Collections.Generic;
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
            manager.Navigator.GoToContactsPage();

            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove()
        {
            manager.Navigator.GoToContactsPage();

            SelectContact();
            InitContactModification();
            RemoveContact();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper Modify(ContactData newContact)
        {
            manager.Navigator.GoToContactsPage();

            SelectContact();
            InitContactModification();
            FillContactForm(newContact);
            SubmitContactModification();
            return this;
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToContactsPage();
            return driver.FindElements(By.Name("entry")).Count;
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
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactsCache = null;
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
            contactsCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            contactsCache = null;
            return this;
        }

        public bool IsContactExists()
        {
            manager.Navigator.GoToContactsPage();
            return IsElementPresent(By.Name("selected[]"));
        }

        private List<ContactData> contactsCache = null;

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();

            if (contactsCache == null)
            {

                contactsCache = new List<ContactData>();

                manager.Navigator.GoToContactsPage();

                ICollection<IWebElement> rows = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in rows)
                {
                   

                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    ContactData contactInList = new ContactData(cells[2].Text, cells[1].Text);
                    contactInList.Id = element.FindElement(By.TagName("input")).GetAttribute("id");

                    contactsCache.Add(contactInList);
                }

                return new List<ContactData>(contactsCache);

            }
            return contacts;

        }

    }

}
