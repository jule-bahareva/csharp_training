using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Firstname1", "Lastname1");

            contact.Company = "Company1";
            contact.Address = "City1";
            contact.Home = "Home1";
            contact.Mobile = "123456789";
            contact.Work = "1234567899";
            contact.Email = "email@test.test";
            contact.Bday = "1";
            contact.Bmonth = "May";
            contact.Byear = "2000";
            contact.Aday = "2";
            contact.Amonth = "November";
            contact.Ayear = "2010";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);


        }
    }
}
