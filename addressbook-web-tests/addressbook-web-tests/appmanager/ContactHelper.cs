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



        public ContactData GetContactInfoFromTable(int index)
        {
            manager.Navigator.GoToContactsPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;

            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };

        }



        public string GetContactInfoFromDetails(int index)
        {
            manager.Navigator.GoToContactsPage();
            OpenContactDetails(0);

            return Regex.Replace(driver.FindElement(By.Id("content")).Text, @" ?\(.*?\)", String.Empty);
        }

        public ContactData GetContactInfoFromEditForm(int index)
        {
            manager.Navigator.GoToContactsPage();
            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");

            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
   
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");


            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday  = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {

                Middlename = middlename,
                Nickname = nickname,
                Title = title,
                Company = company,


                Address = address,

                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,

                Fax = fax,

                Email = email,
                Email2 = email2,
                Email3 = email3,

                Homepage = homepage,

                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,

                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,

            };

        }



        public ContactHelper Remove()
        {
            manager.Navigator.GoToContactsPage();

            SelectContact();
            InitContactModification(0);
            RemoveContact();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();

            SelectContact(contact.Id); 
            InitContactModification(0);
            RemoveContact();
            manager.Auth.Logout();
            return this;
        }



        public ContactHelper Modify(ContactData newContact)
        {
            manager.Navigator.GoToContactsPage();

            SelectContact();
            InitContactModification(0);
            FillContactForm(newContact);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Modify(ContactData oldDataContact, ContactData newContact)
        {
            manager.Navigator.GoToContactsPage();

            SelectContact(oldDataContact.Id);
            InitContactModification(0);
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



        public ContactHelper OpenContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }


        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
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
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactsCache = null;
            return this;
        }

        public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToContactsPage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }

        public ContactHelper RemoveContactFromGroup(GroupData group)
        {
            manager.Navigator.GoToContactsPage();
            SelectGroupFilter(group.Name);
            SelectContact();
            SubmitRemoveFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }

        public void SubmitRemoveFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);

        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
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
