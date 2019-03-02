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
            newContact.Bday = "10";
            newContact.Bmonth = "June";
            newContact.Byear = "2001";
            newContact.Aday = "20";
            newContact.Amonth = "June";
            newContact.Ayear = "2005";

            app.Contacts.Modify(newContact);

        }
    }
}
