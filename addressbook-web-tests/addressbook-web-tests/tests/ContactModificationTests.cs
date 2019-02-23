using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("Edited_Firstname", "Edited_Lastname");
            newContact.Middlename = null;
            newContact.Nickname = null;
            newContact.Title = null;
            newContact.Company = null;
            newContact.Address = null;
            newContact.Home = null;
            newContact.Mobile = null;
            newContact.Work = null;
            newContact.Fax = null;
            newContact.Email = null;
            newContact.Email2 = null;
            newContact.Email3 = null;
            newContact.Homepage = null;
            newContact.Address2 = null;
            newContact.Phone2 = null;
            newContact.Notes = null;
             
           app.Contacts.Modify(newContact);

        }
    }
}
