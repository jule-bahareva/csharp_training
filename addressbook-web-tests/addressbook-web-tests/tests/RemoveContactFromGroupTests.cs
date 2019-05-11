using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroupTest()
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

             if (group.GetContacts().Count < 1)
            {
                app.Contacts.AddContactToGroup(ContactData.GetAll().First(), group);
            }


            List<ContactData> oldList = group.GetContacts();



            //action
            app.Contacts.RemoveContactFromGroup(group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}