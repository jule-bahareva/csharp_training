using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGrouptests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            if (GroupData.GetAll().Count < 1)
            {
                GroupData anyGroup = new GroupData("addedGroup1");
                app.Groups.Create(anyGroup);
            }

            if (ContactData.GetAll().Count < 1)
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


            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> allContacts = ContactData.GetAll();


            if (allContacts.Count == oldList.Count)
            {
                ContactData newContact = new ContactData("NEWFirstName", "NEWLastName");
                newContact.Bday = "1";
                newContact.Bmonth = "May";
                newContact.Byear = "2000";
                newContact.Aday = "2";
                newContact.Amonth = "November";
                newContact.Ayear = "2010";
  
                app.Contacts.Create(newContact);

            }

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //action                                 
            app.Contacts.AddContactToGroup(contact, group);
            
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
