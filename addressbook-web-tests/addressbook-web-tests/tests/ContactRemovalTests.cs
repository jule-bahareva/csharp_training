using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //prepare
            if (!app.Contacts.IsContactExists())

            {
                ContactData anyContact = new ContactData("AnyFirstName", "AnyLastName");
                anyContact.Bday = "1";
                anyContact.Bmonth = "May";
                anyContact.Byear = "2000";
                anyContact.Aday = "2";
                anyContact.Amonth = "November";
                anyContact.Ayear = "2010";

                app.Contacts.Create(anyContact);
            }


            //action

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemovedContact = oldContacts[0];


            app.Contacts.Remove(toBeRemovedContact);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemovedContact.Id);
            }
        }
    }
}
