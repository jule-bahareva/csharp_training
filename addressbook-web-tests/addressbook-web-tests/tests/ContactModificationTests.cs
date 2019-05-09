using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactModificationTests : ContactTestBase
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


            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData oldDataContact = oldContacts[0]; 

            app.Contacts.Modify(oldDataContact,newContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;

     
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldDataContact.Id)
                {
                    Assert.AreEqual(oldDataContact.Lastname, contact.Lastname);
                }

            }

        }
    }
}
